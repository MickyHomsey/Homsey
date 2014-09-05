using System.Text.RegularExpressions;

using Homsey.Core.Contract;
using Homsey.Core.Entities;

namespace Homsey.Core.BusinessComponents
{
  public class EnvironmentSettings
  {
    private Regex _languageFinder = new Regex(@"(?<=.au/)\w{2}", RegexOptions.Compiled);
    private IDataRepository _dataRepository;

    public EnvironmentSettings(IDataRepository dataRepository)
    {
      _dataRepository = dataRepository;
    }

    public ILanguage GetCurrentLanguage(string url)
    {
      var language = _languageFinder.Match(url);

      if (language.Success)
      {
        return _dataRepository.GetLanugage(language.Value);
      }

      return _dataRepository.GetLanugage("EN");
    }
  }
}
