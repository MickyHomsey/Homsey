using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Homsey.Core.Contract;

namespace Homsey.Core.Entities
{
  [Table("Comment", Schema = "PageData")]
  internal class Comment : IComment
  {
    [Key]
    public Guid CommentID { get; set; }
    public Guid BlogID { get; set; }
    public Guid LanguageID { get; set; }

    public string Name { get; set; }
    public string Remark { get; set; }
    public string Email { get; set; }

    public DateTime DateStamp { get; set; }
  }
}
