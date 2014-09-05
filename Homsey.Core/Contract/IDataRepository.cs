using System;
using System.Collections.Generic;

using Homsey.Core.Contract;

namespace Homsey.Core.Entities
{
  public interface IDataRepository
  {
    #region Comments
    void AddComment(string name, string email, string remark, Guid blogId, Guid languageId);
    ICollection<IComment> GetCommentsByArticle(Guid languageId, Guid blogId);
    ICollection<IComment> GetComments();
    #endregion

    #region Page Data
    ICollection<IPageContentView> GetPages();
    ICollection<IPageContentView> GetPage(Guid blogId);
    ICollection<IPageContentView> GetPage(ILanguage languageId);
    IPageContentView GetPage(string title);
    #endregion

    #region Quotation Data
    ICollection<IQuotation> GetQuotes();
    ICollection<IQuotation> GetQuotes(ILanguage language);
    #endregion

    #region Menu Data
    ICollection<IMenuData> GetBaseMenuItems();
    ICollection<IMenuData> GetMenuChildItems(IMenuData menuData);
    #endregion

    #region Category Data
    ICollection<ICategory> GetCategories();
    #endregion

    #region Language Data
    ICollection<ILanguage> GetLanguages();
    ILanguage GetLanugage(string locale);
    #endregion
  }
}
