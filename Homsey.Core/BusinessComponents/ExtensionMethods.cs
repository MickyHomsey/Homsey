using System;

namespace Homsey.Core.BusinessComponents
{
  public static class ExtensionMethods
  {
    public static bool IsNullOrTrimmedEmpty(this string value)
    {
      if (value == null)
      {
        return true;
      }

      if (String.Compare(String.Empty, value.Trim(), true) == 0)
      {
        return true;
      }

      return false;
    }
  }
}
