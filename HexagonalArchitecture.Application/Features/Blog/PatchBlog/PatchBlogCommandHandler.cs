namespace HexagonalArchitecture.Application.Features.Blog.PatchBlog;

public class PatchBlogCommandHandler : IRequestHandler<PatchBlogCommand, Result<BlogModel>>
{
	private readonly IBlogPort _blogPort;

	public PatchBlogCommandHandler(IBlogPort blogPort)
	{
		_blogPort = blogPort;
	}

	#region Handle

	public async Task<Result<BlogModel>> Handle(PatchBlogCommand request, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		if (request.BlogId <= 0)
		{
			result = Result<BlogModel>.Fail(MessageResource.InvalidId);
			goto result;
		}

		result = await _blogPort.PatchBlogAsync(request.BlogRequestModel, request.BlogId, cancellationToken);

	result:
		return result;
	}

	#endregion

}
