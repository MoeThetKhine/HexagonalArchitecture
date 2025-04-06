using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HexagonalArchitecture.Domain.Features.Blog;

#region Tbl_Blog

[Table("Tbl_Blog")]
public class Tbl_Blog
{
	[Key]
	public int BlogId { get; set; }
	public string BlogTitle { get; set; }
	public string BlogAuthor { get; set; }
	public string BlogContent { get; set; }
}

#endregion