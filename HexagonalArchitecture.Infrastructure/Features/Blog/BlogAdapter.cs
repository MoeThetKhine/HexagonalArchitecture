using HexagonalArchitecture.DbService.AppDbContextModels;
using HexagonalArchitecture.Domain.Features.Blog;
using HexagonalArchitecture.DTOs.Features.Blog;
using HexagonalArchitecture.DTOs.PageSetting;
using HexagonalArchitecture.Shared;
using HexagonalArchitecture.Utils;
using Microsoft.EntityFrameworkCore;

namespace HexagonalArchitecture.Infrastructure.Features.Blog;

public class BlogAdapter : IBlogPort
{
	private readonly AppDbContext _appDbContext;

	public BlogAdapter(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public async Task<Result<BlogListModelV1>> GetBlogAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		Result<BlogListModelV1> result;

		try
		{
			var query = _appDbContext.TblBlogs.OrderByDescending(x => x.BlogId);
			var lst = await query.Paginate(pageNo,pageSize)
				.ToListAsync(cancellationToken: cancellationToken);
			var totalCount = await query.CountAsync(cancellationToken);
			var pageCount = totalCount / pageSize;

			if(totalCount % pageSize > 0)
			{
				pageCount++;
			}

			var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
			var model = new BlogListModelV1()
			{
				DataLst = lst.Select(x => new BlogModel()
				{
					BlogId = x.BlogId,
					BlogTitle = x.BlogTitle,
					BlogAuthor = x.BlogAuthor,
					BlogContent = x.BlogContent,
				}).AsQueryable(),
				PageSetting = pageSettingModel
			};

			result = Result<BlogListModelV1>.Success(model);
		}
		catch (Exception ex)
		{
			result = Result<BlogListModelV1>.Failure(ex);
		}

		return result;
	}
}
