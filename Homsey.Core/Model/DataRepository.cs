using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homsey.Core.Cache;
using Homsey.Core.Contract;
using Ninject;

namespace Homsey.Core.Entities
{
  internal class DataRepository : IDataRepository
  {
    #region Comment Data
    public ICollection<IComment> GetCommentsByArticle(Guid languageID, Guid blogID)
    {     
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.Comments.Where(comment => comment.LanguageID == languageID
                                                      && comment.BlogID == blogID)
                                       .OrderByDescending(comment => comment.DateStamp)
                                       .ToArray();
      }
    }

    public ICollection<IComment> GetComments()
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.Comments.ToArray();
      }
    }

    public void AddComment(string name, string email, string remark, Guid blogID, Guid languageID)
    {
      Comment comment = new Comment();
      comment.CommentID = Guid.NewGuid();
      comment.BlogID = blogID;
      comment.LanguageID = languageID;
      comment.Name = name;
      comment.Email = email;
      comment.Remark = remark;
      comment.DateStamp = DateTime.Now;

      using (var databaseContext = new DatabaseConnection())
      {
        databaseContext.Comments.Add(comment);
        databaseContext.SaveChanges();
      }
    }
    #endregion

    #region Page Data
    public ICollection<IPageContentView> GetPage(Guid blogId)
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.PageContentView.Where(x => x.BlogID == blogId).ToArray();
      }
    }

    public ICollection<IPageContentView> GetPage(ILanguage language)
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.PageContentView.Where(x => x.LanguageID == language.LanguageID).ToArray();
      }
    }
    
    public IPageContentView GetPage(string title)
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.PageContentView.SingleOrDefault(x => x.Title == title);
      }
    }

    public ICollection<IPageContentView> GetPages()
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.PageContentView.ToArray();
      }
    }
    #endregion

    #region Quotation
    public ICollection<IQuotation> GetQuotes(ILanguage language)
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.Quotations.Where(x => x.LanguageID == language.LanguageID).ToArray();
      }
    }

    public ICollection<IQuotation> GetQuotes()
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.Quotations.ToArray();
      }
    }
    #endregion

    #region Menu Data
    public ICollection<IMenuData> GetBaseMenuItems()
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.MenuData.Where(x => (x.ParentID == null) &&  (x.Visible))
                                       .OrderBy(y => y.Position)
                                       .ToArray();
      }
    }

    public ICollection<IMenuData> GetMenuChildItems(IMenuData menuData)
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.MenuData.Where(x => x.ParentID == menuData.ParentID
                                               &&  x.Visible
                                               &&  x.URL != null)
                                       .OrderBy(y => y.Position)
                                       .ToArray();
      }
    }
    #endregion

    #region Category Data
    public ICollection<ICategory> GetCategories()
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.Category.ToArray();
      }
    }
    #endregion

    #region Language Data
    public ICollection<ILanguage> GetLanguages()
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.Languages.ToArray();
      }
    }

    public ILanguage GetLanugage(string virtualDirectory)
    {
      using (var databaseContext = new DatabaseConnection())
      {
        return databaseContext.Languages.SingleOrDefault(x => x.VirtualDirectory == virtualDirectory);
      }
    }
    #endregion
  }
}
