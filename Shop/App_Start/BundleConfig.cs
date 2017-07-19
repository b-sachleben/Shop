﻿using System.Web;
using System.Web.Optimization;

namespace Shop
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/site_menu").Include(
                    "~/js/site_menu.js"));

            bundles.Add(new ScriptBundle("~/bundles/img_gallery").Include(
                    "~/js/img_gallery.js"));

            bundles.Add(new StyleBundle("~/Content/shopCss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/shop.css",
                      "~/Content/normalize.css",
                      "~/Content/main.css"));

            bundles.Add(new StyleBundle("~/Content/mainCss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/normalize.css",
                      "~/Content/main.css"));
        }
    }
}
