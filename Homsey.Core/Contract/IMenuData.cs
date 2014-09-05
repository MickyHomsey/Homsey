using System;

namespace Homsey.Core.Contract
{
  public interface IMenuData
  {
    Nullable<Guid> ParentID { get; }

    int Position { get; }

    string Label { get; }
    string URL { get; }
    string AbsoluteURL { get; }
  }
}
