using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTaskTracker.Models;

namespace MyTaskTracker.Controllers
{
    public class TaskTrackerController : Controller
    {
        TaskTrackerDataContext db = new TaskTrackerDataContext();

        // GET: TaskTracker
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetTaskList()
        {
            var user = User.Identity.Name;

            var taskList = TaskTracker.GetTasksByUser(user, db);

            return View(taskList);
        }
    }
}