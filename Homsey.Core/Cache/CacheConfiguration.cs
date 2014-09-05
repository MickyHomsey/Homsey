using System.Configuration;
using Homsey.Core.Configuration;

namespace Homsey.Core.Cache
{
  internal static class CacheConfiguration
  {
    private static CacheSettings _cacheConfiguration;

    static CacheConfiguration()
    {
      _cacheConfiguration = (CacheSettings)ConfigurationManager.GetSection("cacheSettings");
    }

    public static bool IsEnabled
    {
      get { return _cacheConfiguration.IsEnable; }
    }

    public static int GetPageCacheTimer
    {
      get { return _cacheConfiguration.PageCache.TimeOut; }
    }

    public static int GetMenuCacheTimer
    {
      get { return _cacheConfiguration.MenuCache.TimeOut; }
    }

    public static int GetCategoryCacheTimer
    {
      get { return _cacheConfiguration.CategoryCache.TimeOut; }
    }

    public static int GetBlogCacheTimer
    {
      get { return _cacheConfiguration.BlogCache.TimeOut; }
    }

    public static int GetQuotationCacheTimer
    {
      get { return _cacheConfiguration.QuotationCache.TimeOut; }
    }

    public static int GetCommentCacheTimer
    {
      get { return _cacheConfiguration.CommentCache.TimeOut; }
    }

    public static int GetTwitterCacheTimer
    {
      get { return _cacheConfiguration.TwitterCache.TimeOut; }
    }
  }
}
