using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTaskTracker.Models;
using System.Net;

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

            var taskList = TaskList.GetTasksByUser(user, db);

            return View(taskList);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create([Bind(Include = "TaskName")] TaskList tasklist)
        {
            if (ModelState.IsValid)
            {
                TaskList.CreateTask(tasklist, User.Identity.Name, db);
                return RedirectToAction("GetTaskList");
            }
            return View(tasklist);
        }
    }
}