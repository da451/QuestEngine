using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestEngine.Services;
using QuestEngine.ViewModels;

namespace QuestEngine.Controllers
{
    [Authorize(Users = "Administrator")]
    public class AdminController : Controller
    {

        private static bool _isOk = false;

        private static string _error;

        private static int _progressCount;

        private static int _statisticsCount;
        // GET: Admin
        public ActionResult Index()
        {
            AdminResultViewModel model = new AdminResultViewModel()
            {
                IsOk = _isOk,
                StatisticsCount = _statisticsCount,
                Error = _error,
                ProgressCount = _progressCount
            };
            return View(model);
        }
        
        // GET: Admin/Delete/5
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {
                _isOk = true;
                _error=String.Empty;
                var adminService = new AdminService();
                _progressCount = adminService.ClearProgress();
                _statisticsCount = adminService.ClearStatistics();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                _isOk = false;
                _error = e.ToString();
                return RedirectToAction("Index");
            }
        }
    }
}
