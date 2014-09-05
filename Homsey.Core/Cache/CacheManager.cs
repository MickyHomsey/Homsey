using System;
using System.Collections.Generic;
using System.Linq;

using Homsey.Core.Contract;
using Homsey.Core.Entities;

namespace Homsey.Core.Cache
{
  internal class CacheManager : IDataRepository
  {
    private ICollection<IComment> _comments;
    protected ICollection<IComment> Comments
    {
      get
      {
        if (_comments == null)
        {
          _comments = _dataRepository.GetComments();
        }

        if (CacheTimer.HasExpired(CacheType.CommentCache))
        {
          lock (_lock)
          {
            if (CacheTimer.HasExpired(CacheType.CommentCache))
            {
              _comments = _dataRepository.GetComments();
            }
          }
        }

        return _comments;
      }
    }

    private ICollection<ICategory> _categories;
    protected ICollection<ICategory> Categories
    {
      get
      {
        if (_categories == null)
        {
          _categories = _dataRepository.GetCategories();
        }

        if (CacheTimer.HasExpired(CacheType.CategoryCache))
        {
          lock (_lock)
          {
            if (CacheTimer.HasExpired(CacheType.CategoryCache))
            {
              _categories = _dataRepository.GetCategories();
            }
          }
        }

        return _categories;
      }
    }

    private ICollection<ILanguage> _languages;
    protected ICollection<ILanguage> Languages
    {
      get
      {
        if (_languages == null)
        {
          lock (_lock)
          {
            if (_languages == null)
            {
              _languages = _dataRepository.GetLanguages();
            }
          }
        }

        return _languages;
      }
    }

    private IDictionary<IMenuData, ICollection<IMenuData>> _menuDatas;
    protected IDictionary<IMenuData, ICollection<IMenuData>> MenuDatas
    {
      get
      {
        if (_menuDatas == null)
        {
          _menuDatas = new Dictionary<IMenuData, ICollection<IMenuData>>();

          foreach (var menuItem in _dataRepository.GetBaseMenuItems())
          {
            var childMenuItem = _dataRepository.GetMenuChildItems(menuItem);

            if (childMenuItem != null)
            {
              _menuDatas.Add(menuItem, childMenuItem);
            }
          }
        }

        if (CacheTimer.HasExpired(CacheType.MenuCache))
        {
          lock (_lock)
          {
            if (CacheTimer.HasExpired(CacheType.MenuCache))
            {
              _menuDatas = new Dictionary<IMenuData, ICollection<IMenuData>>();

              foreach (var menuItem in _dataRepository.GetBaseMenuItems())
              {
                var childMenuItem = _dataRepository.GetMenuChildItems(menuItem);
                
                if (childMenuItem != null)
                {
                  _menuDatas.Add(menuItem, childMenuItem);
                }
              }
            }
          }
        }
        
        return _menuDatas;
      }
    }
    
    private ICollection<IPageContentView> _pages;
    protected ICollection<IPageContentView> Pages
    {
      get
      {
        if (_pages == null)
        {
          _pages = _dataRepository.GetPages();
        }

        if (CacheTimer.HasExpired(CacheType.PageCache))
        {
          lock (_lock)
          {
            if (CacheTimer.HasExpired(CacheType.PageCache))
            {
              _pages = _dataRepository.GetPages();
            }
          }
        }

        return _pages;
      }
    }

    private ICollection<IQuotation> _quotes;
    protected ICollection<IQuotation> Quotes
    {
      get
      {
        if (CacheTimer.HasExpired(CacheType.QuotationCache))
        {
          lock (_lock)
          {
            if (CacheTimer.HasExpired(CacheType.QuotationCache))
            {
              _quotes = _dataRepository.GetQuotes();
            }
          }
        }

        return _quotes;
      }
    }

    private IDataRepository _dataRepository;
    private object _lock = new object();

    public CacheManager(IDataRepository dataRepository)
    {
      _dataRepository = dataRepository;
    }

    #region Comments
    public ICollection<IComment> GetComments()
    {
      return Comments;
    }

    public void AddComment(string name, string email, string remark, Guid blogID, Guid languageID)
    {
      _dataRepository.AddComment(name, email, remark, blogID, languageID);
    }

    public ICollection<IComment> GetCommentsByArticle(Guid blogID, Guid languageID)
    {
      return Comments.Where(comment => comment.BlogID == blogID &&
                                       comment.LanguageID == languageID)
                     .ToArray();
    }
    #endregion

    #region Pages
    public ICollection<IPageContentView> GetPage(Guid blogID)
    {
      return Pages.Where(page => page.BlogID == blogID).ToArray();
    }

    public ICollection<IPageContentView> GetPage(ILanguage languageID)
    {
      return Pages.Where(page => page.LanguageID == languageID.LanguageID).ToArray();
    }

    public IPageContentView GetPage(string title)
    {
      return Pages.SingleOrDefault(page => page.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public ICollection<IPageContentView> GetPages()
    {
      return Pages.ToArray();
    }
    #endregion

    #region Quotes
    public ICollection<IQuotation> GetQuotes(ILanguage language)
    {
      return Quotes.Where(quote => quote.LanguageID == language.LanguageID).ToArray();
    }

    public ICollection<IQuotation> GetQuotes()
    {
      return Quotes.ToArray();
    }
    #endregion

    #region Menu Data
    public ICollection<IMenuData> GetBaseMenuItems()
    {
      return MenuDatas.Keys.ToArray();
    }

    public ICollection<IMenuData> GetMenuChildItems(IMenuData menuData)
    {
      ICollection<IMenuData> childMenuItems;
      
      if (MenuDatas.TryGetValue(menuData, out childMenuItems))
      {
        return childMenuItems;
      }

      return null;
    }
    #endregion

    #region Categories
    public ICollection<ICategory> GetCategories()
    {
      return Categories.ToArray();
    }
    #endregion

    #region Languages
    public ICollection<ILanguage> GetLanguages()
    {
      return Languages.ToArray();
    }
    
    public ILanguage GetLanugage(string locale)
    {
      return Languages.SingleOrDefault(language => language.VirtualDirectory.Equals(locale, StringComparison.OrdinalIgnoreCase));
    }
    #endregion
  }
}
