using HexagonalArchitecture.DTOs.Features.Blog;
using HexagonalArchitecture.Utils;

namespace HexagonalArchitecture.Domain.Features.Blog;

public interface IBlogPort
{
	Task<Result<BlogListModelV1>> GetBlogListAsync(int pageNo, int pageSize,CancellationToken cancellationToken);
}
