﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEB
{
    public static class HtmlHelpers
    {
        public static string IsSelected_li(this IHtmlHelper html, List<string> controller = null)
        {
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (controller == null) { controller = new List<string>(); }

            var result = controller.Contains(currentController) ? "active" : String.Empty;
            return result;
        }

        public static string IsSelected_ul(this IHtmlHelper html, List<string> controller = null)
        {
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (controller == null) { controller = new List<string>(); }

            var result = controller.Contains(currentController) ? "active" : String.Empty;
            return result;
        }
        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];


            //return controller == currentController && action == currentAction ?
            //    cssClass : String.Empty;

            var result = controller.Contains(currentController) && action == currentAction ? "active" : String.Empty;
            return result;

        }

        //public static string IsSelected(this IHtmlHelper html, List<string> controller = null, string action = null, string cssClass = null)
        //{
        //    if (String.IsNullOrEmpty(cssClass))
        //        cssClass = "active";

        //    string currentAction = (string)html.ViewContext.RouteData.Values["action"];
        //    string currentController = (string)html.ViewContext.RouteData.Values["controller"];

        //    //if (String.IsNullOrEmpty(controller))
        //    //    controller = currentController;

        //    if (controller == null)
        //    {
        //        controller = new List<string>();
        //    }

        //    if (String.IsNullOrEmpty(action))
        //    {
        //        action = currentAction;
        //    }

        //    //return controller == currentController && action == currentAction ?
        //    //    cssClass : String.Empty;

        //    var result = controller.Contains(currentController) && action == currentAction ? cssClass : String.Empty;
        //    return result;

        //}

        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

    }
}
