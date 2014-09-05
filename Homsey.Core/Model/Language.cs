using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Homsey.Core.Contract;

namespace Homsey.Core.Entities
{
  [Table("Language", Schema = "PageData")]
  internal class Language : ILanguage
  {
    [Key]
    public Guid LanguageID { get; set; }

    public string Locale { get; set; }
    public string VirtualDirectory { get; set; }
  }
}
