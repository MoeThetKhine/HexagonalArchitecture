namespace HexagonalArchitecture.Domain.Features.Blog;

public interface IBlogPort
{
	Task<Result<BlogListModelV1>> GetBlogListAsync(int pageNo, int pageSize,CancellationToken cancellationToken);
	Task<Result<BlogModel>> GetBlogByIdAsync(int id, CancellationToken cancellationToken);
	Task<Result<BlogModel>> CreateBlogAsync(BlogRequestModel blogRequest, CancellationToken cancellationToken);
}
