using HexagonalArchitecture.DTOs.PageSetting;

namespace HexagonalArchitecture.DTOs.Features.Blog;

public class BlogListModel
{
	public IEnumerable<BlogModel> DataLst { get; set; }
	public PageSettingModel PageSetting { get; set; }
}

public class BlogListModelV1
{
	public IQueryable<BlogModel> DataLst { get; set; }
	public PageSettingModel PageSetting { get; set; }
}