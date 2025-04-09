namespace HexagonalArchitecture.Application.Features.Blog.UpdateBlog;

#region UpdateBlogCommand

public class UpdateBlogCommand : IRequest<Result<BlogModel>>
{
	public BlogRequestModel requestModel { get; set; }
	public int BlogId {  get; set; }

	public UpdateBlogCommand(BlogRequestModel requestModel, int blogId)
	{
		this.requestModel = requestModel;
		BlogId = blogId;
	}
}

#endregion