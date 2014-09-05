using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Homsey.Core.Contract;

namespace Homsey.Core.Entities
{
  [Table("MenuData", Schema = "PageData")]
  internal class MenuData : IMenuData
  {
    [Key]
    public Guid MenuID { get; set; }
    public Guid LanguageID { get; set; }

    public Nullable<Guid> ParentID { get; set; }

    public int Position { get; set; }

    public string Label { get; set; }
    public string URL { get; set; }
    public string AbsoluteURL { get; set; }

    public bool Visible { get; set; }
    
    public virtual Language Language { get; set; }
  }
}
