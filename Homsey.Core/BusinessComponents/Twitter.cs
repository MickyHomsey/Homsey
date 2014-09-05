using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Homsey.Configuration;

using LinqToTwitter;

namespace Homsey.BusinessComponents
{
  public class Twitter
  {
    private static ITwitterAuthorizer _twitterAuthorizer;
    private static TwitterSettings _twitterSettings;

    private bool HasTwitterAuthorizer
    {
      get { return _twitterAuthorizer != null; }
    }

    private bool HasTwitterSettings
    {
      get { return _twitterSettings != null; } 
    }

    public Twitter()
    {
      if (!this.HasTwitterSettings)
      {
        _twitterSettings = (TwitterSettings) ConfigurationManager.GetSection("twitterSettings");
      }
    }

    public ITwitterAuthorizer GetTwitterAuthorizer
    {
      get
      {
        if (!this.HasTwitterAuthorizer)
        {
          this.GenerateTwitterAuthorizer();
        }

        return _twitterAuthorizer;
      }
    }

    private void GenerateTwitterAuthorizer()
    {
      _twitterAuthorizer = new ApplicationOnlyAuthorizer()
      {
        Credentials = new InMemoryCredentials()
        {
          ConsumerKey = _twitterSettings.ConsumerKey.Value,
          ConsumerSecret = _twitterSettings.ConsumerSecret.Value,
          AccessToken = _twitterSettings.AccessToken.Value
        }
      };

      _twitterAuthorizer.Authorize();
    }
  }
}
