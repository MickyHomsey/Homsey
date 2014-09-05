using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Homsey.Core.Contract;

namespace Homsey.Core.Entities
{
  [Table("Category", Schema = "PageData")]
  internal class Category : ICategory
  {
    [Key]
    public Guid CategoryID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
