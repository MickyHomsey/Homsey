using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homsey.Core.Contract
{
  public interface ILanguage
  {
    Guid LanguageID { get; }

    string Locale { get; }
    string VirtualDirectory { get; }
  }
}
