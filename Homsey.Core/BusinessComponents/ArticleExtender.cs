using System;
using System.Text.RegularExpressions;

namespace Homsey.Core.BusinessComponents
{
  public class ArticleExtender
  {
    private Regex _articleFinder = new Regex(@"[^/]+$", RegexOptions.Compiled);

    public string GetArticleTitle(string pageAbsoluteUrl)
    {
      if (!pageAbsoluteUrl.IsNullOrTrimmedEmpty())
      {
        var articleTitle = _articleFinder.Match(pageAbsoluteUrl);

        if (articleTitle.Success)
        {
          return articleTitle.Value.Replace("-", " ");
        }
      }

      return null;
    }

    public string GetArticleByTitleUrl(string articleTitle)
    {
      string title = null;

      if (!articleTitle.IsNullOrTrimmedEmpty())
      {
        title = GetArticleTitle(articleTitle);   
      }

      return title;
    }
  }
}
