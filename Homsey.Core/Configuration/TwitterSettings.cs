using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Homsey.Configuration
{
  public sealed class TwitterSettings : ConfigurationSection
  {
    [ConfigurationProperty("consumerKey", IsRequired = true)]
    public TwitterElementValue ConsumerKey
    {
      get { return (TwitterElementValue)this["consumerKey"]; }
      set { this["consumerKey"] = value; }
    }

    [ConfigurationProperty("consumerSecret", IsRequired = true)]
    public TwitterElementValue ConsumerSecret
    {
      get { return (TwitterElementValue)this["consumerSecret"]; }
      set { this["consumerSecret"] = value; }
    }

    [ConfigurationProperty("accessToken", IsRequired = true)]
    public TwitterElementValue AccessToken
    {
      get { return (TwitterElementValue)this["accessToken"]; }
      set { this["accessToken"] = value; }
    }

    [ConfigurationProperty("accessTokenSecret", IsRequired = true)]
    public TwitterElementValue AccessTokenSecret
    {
      get { return (TwitterElementValue)this["accessTokenSecret"]; }
      set { this["accessTokenSecret"] = value; }
    }
  }

  public sealed class TwitterElementValue : ConfigurationElement
  {
    [ConfigurationProperty("value", IsRequired = true)]
    public string Value
    {
      get { return (string)this["value"]; }
      set { this["value"] = value; }
    }
  }
}
