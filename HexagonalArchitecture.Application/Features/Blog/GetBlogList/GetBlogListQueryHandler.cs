using HexagonalArchitecture.Domain.Features.Blog;

namespace HexagonalArchitecture.Application.Features.Blog.GetBlogList;

public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<BlogListModelV1>>
{
	private readonly IBlogPort _blogPort;

	public GetBlogListQueryHandler(IBlogPort blogPort)
	{
		_blogPort = blogPort;
	}

	#region Handle

	public async Task<Result<BlogListModelV1>> Handle(GetBlogListQuery request, CancellationToken cancellationToken)
	{
		Result<BlogListModelV1> result;

		try
		{
			if (request.PageNo <= 0)
			{
				result = Result<BlogListModelV1>.Fail(MessageResource.InvalidPageNo);
				goto result;
			}

			if (request.PageSize <= 0)
			{
				result = Result<BlogListModelV1>.Fail(MessageResource.InvalidPageSize);
				goto result;
			}

			result = await _blogPort.GetBlogListAsync(request.PageNo, request.PageSize, cancellationToken);

		}
		catch (Exception ex)
		{
			result = Result<BlogListModelV1>.Failure(ex);
		}
	result:
		return result;
	}

	#endregion

}