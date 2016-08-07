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

        [HttpPost]
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

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            TaskList tasklist = TaskList.GetTaskById(id, db);

            return View(tasklist);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit([Bind(Include = "TaskName, TaskID")] TaskList tasklist)
        {
            TaskList.EditTask(tasklist, db);
            return RedirectToAction("GetTaskList");
        }

        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            TaskList tas = TaskList.GetTaskById(id, db);

            return View(tas);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed (int? id)
        {
            TaskList.DeleteById(id, db);
            return RedirectToAction("GetTaskList");
        }
    }
}