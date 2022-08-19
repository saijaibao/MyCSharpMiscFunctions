using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace MyCSharpMiscFunctions.Functions
{
  // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.webutilities.queryhelper
  //
  // This is MyQueryHelper, which is my version of the QueryHelper
  internal static class MyQueryHelper
  {
    internal static string AddQueryString(string baseUri, IDictionary<string, string>dict)
    {
      if (dict.All(x => x.Value == null))
        return baseUri;

      var itemsToRemove = dict.Where(x => x.Value == null).ToArray();
      foreach(var item in itemsToRemove)
        dict.Remove(item.Key);
      
      var uri = new StringBuilder();
      uri.Append(baseUri);
      uri.Append("?");
      var lastItem = dict.LastOrDefault();
      foreach(var item in dict)
      {
        uri.Append($"{item.Key}={item.Value}");
        if (!item.Equals(lastItem))
          uri.Append("&");
      }
      return uri.ToString();
    }
  }
}