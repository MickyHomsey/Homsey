using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Homsey.Core.Contract;

namespace Homsey.Core.Entities
{
  [Table("PageContentView", Schema = "PageData")]
  public class PageContentView : IPageContentView
  {
    [Key]
    public Guid BlogID { get; set; }
    public Guid LanguageID { get; set; }

    public string Article { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Synopsis { get; set; }
    public string Image { get; set; }
    public string ImageTitle { get; set; }
    public string Description { get; set; }
    public string Locale { get; set; }
    public string CategoryName { get; set; }

    public bool Enabled { get; set; }

    public int Hits { get; set; }

    public DateTime CreationDate { get; set; }
  }
}
