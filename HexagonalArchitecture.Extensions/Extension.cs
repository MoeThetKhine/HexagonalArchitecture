using HexagonalArchitecture.DbService.AppDbContextModels;
using HexagonalArchitecture.DTOs.Features.Blog;

namespace HexagonalArchitecture.Extensions
{
	public static class Extension
	{
		public static BlogModel ToModel(this TblBlog dataModel)
		{
			return new BlogModel
			{
				BlogId = dataModel.BlogId,
				BlogTitle = dataModel.BlogTitle,
				BlogAuthor = dataModel.BlogAuthor,
				BlogContent = dataModel.BlogContent,
				DeleteFlag = dataModel.DeleteFlag
			};
		}

	}
}
