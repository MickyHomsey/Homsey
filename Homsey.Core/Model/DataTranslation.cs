using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Homsey.Core.Contract;

namespace Homsey.Core.Entities
{
  [Table("DataTranslation", Schema = "TranslationData")]
  internal class DataTranslation : IDataTranslation
  {
    [Key]
    public string KeyWord { get; set; }
    public string Translation { get; set; }
    public string Language { get; set; }
  }
}
