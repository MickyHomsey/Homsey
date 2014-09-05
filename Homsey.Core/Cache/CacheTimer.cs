using System;
using System.Diagnostics;

namespace Homsey.Core.Cache
{
  internal static class CacheTimer
  {
    private static Stopwatch _menuTimer;
    private static Stopwatch _pageTimer;
    private static Stopwatch _categoryTimer;
    private static Stopwatch _blogTimer;
    private static Stopwatch _quotationTimer;
    private static Stopwatch _commentTimer;
    private static Stopwatch _twitterTimer;

    static CacheTimer()
    {
      _menuTimer = new Stopwatch();
      _menuTimer.Start();

      _pageTimer = new Stopwatch();
      _pageTimer.Start();

      _categoryTimer = new Stopwatch();
      _categoryTimer.Start();

      _blogTimer = new Stopwatch();
      _blogTimer.Start();

      _quotationTimer = new Stopwatch();
      _quotationTimer.Start();

      _commentTimer = new Stopwatch();
      _commentTimer.Start();

      _twitterTimer = new Stopwatch();
      _twitterTimer.Start();
    }

    public static bool HasExpired(CacheType ct)
    {
      switch (ct)
      {
        case CacheType.MenuCache:
          return MenuCacheTimerExpiration;

        case CacheType.PageCache:
          return PageCacheTimerExpiration;

        case CacheType.CategoryCache:
          return CategoryCacheTimerExpiration;

        case CacheType.BlogCache:
          return BlogCacheTimerExpiration;

        case CacheType.QuotationCache :
          return QuotationCacheTimerExpiration;

        case CacheType.CommentCache:
          return CommentCacheTimerExpiration;

        case CacheType.TwitterCache:
          return TwitterCacheTimerExpiration;

        default:
          throw new ArgumentException("Invalid Cache Type", "ct");
      }
    }

    private static bool MenuCacheTimerExpiration
    {
      get
      {
        if (_menuTimer.Elapsed.Minutes >= CacheConfiguration.GetMenuCacheTimer)
        {
          _menuTimer.Restart();
          return true;
        }

        return false;
      }
    }

    private static bool PageCacheTimerExpiration
    {
      get
      {
        if (_pageTimer.Elapsed.Minutes >= CacheConfiguration.GetPageCacheTimer)
        {
          _pageTimer.Restart();
          return true;
        }

        return false;
      }
    }

    private static bool CategoryCacheTimerExpiration
    {
      get
      {
        if (_categoryTimer.Elapsed.Minutes >= CacheConfiguration.GetCategoryCacheTimer)
        {
          _categoryTimer.Restart();
          return true;
        }

        return false;
      }
    }

    private static bool BlogCacheTimerExpiration
    {
      get
      {
        if (_blogTimer.Elapsed.Minutes >= CacheConfiguration.GetBlogCacheTimer)
        {
          _blogTimer.Restart();
          return true;
        }

        return false;
      }
    }

    private static bool QuotationCacheTimerExpiration
    {
      get
      {
        if (_quotationTimer.Elapsed.Minutes >= CacheConfiguration.GetQuotationCacheTimer)
        {
          _quotationTimer.Restart();
          return true;
        }

        return false;
      }
    }

    private static bool CommentCacheTimerExpiration
    {
      get
      {
        if (_commentTimer.Elapsed.Minutes >= CacheConfiguration.GetCommentCacheTimer)
        {
          _commentTimer.Restart();
          return true;
        }

        return false;
      }
    }

    private static bool TwitterCacheTimerExpiration
    {
      get
      {
        if (_twitterTimer.Elapsed.Minutes >= CacheConfiguration.GetTwitterCacheTimer)
        {
          _twitterTimer.Restart();
          return true;
        }

        return false;
      }
    }
  }
}
