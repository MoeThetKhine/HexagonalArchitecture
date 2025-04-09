namespace HexagonalArchitecture.Application.Features.Blog.GetBlogById;

public class GetBlogByIdQuery : IRequest<Result<BlogModel>>
{
	public int BlogId { get; set; }

	public GetBlogByIdQuery(int blogId)
	{
		BlogId = blogId;
	}
}
