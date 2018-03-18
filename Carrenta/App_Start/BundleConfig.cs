﻿using System.Web;
using System.Web.Optimization;

namespace Carrenta
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
                "~/Scripts/respond.js",
                "~/Scripts/slick.min.js",
                "~/Scripts/jquery.dataTables.min.js",
                //"~/Scripts/dataTables.bootstrap.min.js",
                "~/Scripts/dataTables.bootstrap.min.js",
                //"~/Scripts/datepicker.min.js",
                "~/Scripts/bootstrap-datepicker.min.js",
                "~/Scripts/script.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap-flatly.min.css",
                "~/Content/slick.css",
                "~/Content/slick-theme.css",
                //"~/Content/dataTables.bootstrap.min.css",
                "~/Content/datatables.min.css",
                //"~/Content/datepicker.css",
                "~/Content/bootstrap-datepicker.min.css",
                "~/Content/site.css"));
    }
  }
}
