using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Homsey.Core.Configuration
{
  public sealed class CacheSettings : ConfigurationSection
  {
    [ConfigurationProperty("enable", IsRequired = true)]
    public bool IsEnable
    {
      get { return (bool)this["enable"]; }
      set { this["enable"] = value; }
    }

    [ConfigurationProperty("pageCache", IsRequired = true)]
    public TimeOutElement PageCache
    {
      get { return (TimeOutElement)this["pageCache"]; }
      set { this["pageCache"] = value; }
    }

    [ConfigurationProperty("menuCache", IsRequired = true)]
    public TimeOutElement MenuCache
    {
      get { return (TimeOutElement)this["menuCache"]; }
      set { this["menuCache"] = value; }
    }

    [ConfigurationProperty("categoryCache", IsRequired = true)]
    public TimeOutElement CategoryCache
    {
      get { return (TimeOutElement)this["categoryCache"]; }
      set { this["categoryCache"] = value; }
    }

    [ConfigurationProperty("blogCache", IsRequired = true)]
    public TimeOutElement BlogCache
    {
      get { return (TimeOutElement)this["blogCache"]; }
      set { this["blogCache"] = value; }
    }
    
    [ConfigurationProperty("quotationCache", IsRequired = true)]
    public TimeOutElement QuotationCache
    {
      get { return (TimeOutElement)this["quotationCache"]; }
      set { this["quotationCache"] = value; }
    }
    
    [ConfigurationProperty("commentCache", IsRequired = true)]
    public TimeOutElement CommentCache
    {
      get { return (TimeOutElement)this["commentCache"]; }
      set { this["commentCache"] = value; }
    }

    [ConfigurationProperty("twitterCache", IsRequired = true)]
    public TimeOutElement TwitterCache
    {
      get { return (TimeOutElement)this["twitterCache"]; }
      set { this["twitterCache"] = value; }
    }
  }

  public sealed class TimeOutElement : ConfigurationElement
  {
    [ConfigurationProperty("timeout", IsRequired = true)]
    public int TimeOut
    {
      get { return (int)this["timeout"]; }
      set { this["timeout"] = value; }
    }
  }
}
