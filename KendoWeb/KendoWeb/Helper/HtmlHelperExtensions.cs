using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KendoWeb.Helper
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString NewMenuLink(this HtmlHelper helper, string linkText, string actionName,
                                      string controllerName, object routeValues = null)
        {
            var result = new TagBuilder("a");
            var url = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(routeValues), helper.RouteCollection,
                                            helper.ViewContext.RequestContext, true);
            result.Attributes.Add("href", url);
            result.InnerHtml = "<i class=\"fa fa-file-o\"></i>" + linkText;

            var strResult = "";
            strResult = "<li>" + result.ToString() + "</li>";
            return new MvcHtmlString(strResult);
        }
    }
}