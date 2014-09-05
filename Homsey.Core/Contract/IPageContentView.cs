using System;

namespace Homsey.Core.Contract
{
  public interface IPageContentView
  {
    string Title { get; }
    string Author { get; }
    string Synopsis { get; }
    string Article { get; }
    string Image { get; }
    string ImageTitle { get; }
    string Description { get; }
    string CategoryName { get; }

    int Hits { get; }
    
    DateTime CreationDate { get; }

    Guid BlogID { get; }
    Guid LanguageID { get; }
  }
}
