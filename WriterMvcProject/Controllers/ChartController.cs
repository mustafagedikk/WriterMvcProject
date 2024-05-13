using BusinessLayer.Concrete;
using DataAccesLayer;
using DataAccesLayer.EntitiyFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WriterMvcProject.Models;

namespace WriterMvcProject.Controllers
{
    public class ChartController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeadingChart()
        {
            var chartData = HeadingChartList();
            return Json(chartData, JsonRequestBehavior.AllowGet);
        }

        public List<HeadingChart> HeadingChartList()
        {
            List<HeadingChart> list = new List<HeadingChart>();
            using (var db = new Context())
            {
                list = db.Headings.Select(x => new HeadingChart
                {
                    HeadingName = x.HeadingName,
                    HeadingCount = x.Contents.Select(y => y.ContentValue).Count()
                }).ToList();
            }

            return list;
        }
        public ActionResult WriterIndex()
        {
            return View();
        }

        public ActionResult WriterChart()
        {
            var chartData = WriterChartList();
            return Json(chartData, JsonRequestBehavior.AllowGet);
        }

        public List<WriterChart> WriterChartList()
        {
            List<WriterChart> list = new List<WriterChart>();
            using (var db = new Context())
            {
                list = db.Writers.Select(x => new WriterChart
                {
                    WriterName = x.WriterName,
                    YorumSayısı = x.Contents.Where(y => !string.IsNullOrEmpty(y.ContentValue)).Count()
                }).ToList();
            }

            return list;
        }

        /////////////////////////////////////////////////////////
        ///
        public ActionResult WriterHeadingIndex()
        {
            return View();
        }

        public ActionResult WriterHeadingChart()
        {
            var chartData = WriterHeadingChartList();
            return Json(chartData, JsonRequestBehavior.AllowGet);
        }

        public List<WriterByHeading> WriterHeadingChartList()
        {
            List<WriterByHeading> list = new List<WriterByHeading>();
            using (var db = new Context())
            {
                list = db.Headings.GroupBy(x => x.Writer.WriterName)
                                  .Select(g => new WriterByHeading
                                  {
                                      WriterName = g.Key,
                                      HeadingCount = g.Count()
                                  })
                                  .ToList();
            }

            return list;
        }

    }
}