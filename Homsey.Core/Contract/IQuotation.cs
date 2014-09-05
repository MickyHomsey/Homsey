using System;

namespace Homsey.Core.Contract
{
  public interface IQuotation
  {
    Guid LanguageID { get; }

    string Quote { get; }
    string Author { get; }
  }
}
