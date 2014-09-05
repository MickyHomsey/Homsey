using System;

namespace Homsey.Core.Contract
{
  public interface IComment
  {
    Guid BlogID { get; }
    Guid LanguageID { get; }

    string Name { get; }
    string Remark { get; }
    string Email { get; }

    DateTime DateStamp { get; }
  }
}
