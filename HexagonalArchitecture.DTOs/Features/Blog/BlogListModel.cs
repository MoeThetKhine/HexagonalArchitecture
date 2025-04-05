using HexagonalArchitecture.DTOs.PageSetting;

namespace HexagonalArchitecture.DTOs.Features.Blog;

public class BlogListModel
{
	public IEnumerable<BlogModel> DataLst { get; set; }
	public PageSettingModel PageSetting { get; set; }
}
