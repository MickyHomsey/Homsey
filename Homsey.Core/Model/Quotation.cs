using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Homsey.Core.Contract;

namespace Homsey.Core.Entities
{
  [Table("Quotation", Schema = "PageData")]
  internal class Quotation : IQuotation
  {
    [Key]
    public Guid QuotationID { get; set; }
    public Guid LanguageID { get; set; }

    public string Quote { get; set; }
    public string Author { get; set; }
  }
}
