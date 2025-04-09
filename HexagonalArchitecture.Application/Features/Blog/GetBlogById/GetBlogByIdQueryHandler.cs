namespace HexagonalArchitecture.Application.Features.Blog.GetBlogById;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, Result<BlogModel>>
{
	private readonly IBlogPort _blogPort;

	public GetBlogByIdQueryHandler(IBlogPort blogPort)
	{
		_blogPort = blogPort;
	}

	public async Task<Result<BlogModel>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		if(request.BlogId <= 0)
		{
			result = Result<BlogModel>.Fail(MessageResource.InvalidId);
			goto result;
		}

		result = await _blogPort.GetBlogByIdAsync(request.BlogId, cancellationToken);

		result:
		return result;

	}
}
