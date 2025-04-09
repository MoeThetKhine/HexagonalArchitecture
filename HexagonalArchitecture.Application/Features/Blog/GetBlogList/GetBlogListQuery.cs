using HexagonalArchitecture.DTOs.Features.Blog;
using HexagonalArchitecture.Utils;
using MediatR;

namespace HexagonalArchitecture.Application.Features.Blog.GetBlogList;

#region GetBlogListQuery

public class GetBlogListQuery :  IRequest<Result<BlogListModelV1>>
{
	public int PageNo {  get; set; }
	public int PageSize { get; set; }

	public GetBlogListQuery(int pageNo, int pageSize)
	{
		PageNo = pageNo;
		PageSize = pageSize;
	}
}

#endregion