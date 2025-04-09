namespace HexagonalArchitecture.Application.Features.Blog.DeleteBlog;

#region DeleteBlogCommandHandler

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Result<BlogModel>>
{
	private readonly IBlogPort _blogPort;

	public DeleteBlogCommandHandler(IBlogPort blogPort)
	{
		_blogPort = blogPort;
	}

	#region Handle

	public async Task<Result<BlogModel>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		if(request.BlogId <= 0)
		{
			result = Result<BlogModel>.Fail(MessageResource.InvalidId);
			goto result;
		}

		result = await _blogPort.DeleteBlogAsync(request.BlogId, cancellationToken);

		result:
		return result;
	}

	#endregion
}

#endregion