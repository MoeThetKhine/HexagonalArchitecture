namespace HexagonalArchitecture.Infrastructure.Features.Blog;

public class BlogAdapter : IBlogPort
{
	private readonly AppDbContext _appDbContext;

	public BlogAdapter(AppDbContext appDbContext)
	{
		_appDbContext = appDbContext;
	}

	public Task<Result<BlogModel>> CreateBlogAsync(BlogRequestModel blogRequest, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result<BlogModel>> DeleteBlogAsync(int id, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	#region GetBlogAsync

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

	#endregion

	public async Task<Result<BlogModel>> GetBlogByIdAsync(int id, CancellationToken cancellationToken)
	{
		Result<BlogModel> result;

		try
		{
			var blog = await _appDbContext.TblBlogs.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

			if(blog is null)
			{
				result = Result<BlogModel>.NotFound();
				goto result;
			}

			result = Result<BlogModel>.Success(new BlogModel()
			{
				BlogId = blog.BlogId,
				BlogTitle = blog.BlogTitle,
				BlogAuthor = blog.BlogAuthor,
				BlogContent = blog.BlogContent,
			});
		}

		catch(Exception ex)
		{
			result = Result<BlogModel>.Failure(ex);
		}

		result:
		return result;
	}

	public Task<Result<BlogListModelV1>> GetBlogListAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result<BlogModel>> PatchBlogAsync(int id, BlogRequestModel requestModel, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result<BlogModel>> UpdateBlogAsync(int id, BlogRequestModel requestModel, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}
