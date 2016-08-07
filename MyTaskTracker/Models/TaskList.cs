using MyTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTaskTracker.Models
{
    public partial class TaskList
    {
        public static IEnumerable<TaskList> GetTasksByUser(string usrName, TaskTrackerDataContext db)
        {
            var usrTask = from tskUsr in db.TaskOwners
                          join tsk in db.TaskLists on tskUsr.TaskId equals tsk.TaskID
                          where tskUsr.UserName == usrName
                          select tsk;

            return usrTask;
        }

        public static void CreateTask(TaskList tasklist, string usrName, TaskTrackerDataContext db)
        {
            db.TaskLists.InsertOnSubmit(tasklist);
            db.SubmitChanges();

            var id = (from t in db.TaskLists
                      where t.TaskName == tasklist.TaskName
                      select t.TaskID).FirstOrDefault();

            TaskOwner tskUsr = new Models.TaskOwner();
            tskUsr.UserName = usrName;
            tskUsr.TaskId = id;

            db.TaskOwners.InsertOnSubmit(tskUsr);
            db.SubmitChanges();
        }

        public static void EditTask(TaskList tasklist, TaskTrackerDataContext db)
        {
            var orgTaskList = (from t in db.TaskLists
                               where t.TaskID == tasklist.TaskID
                               select t).FirstOrDefault();

            orgTaskList.TaskName = tasklist.TaskName;
            db.SubmitChanges();
        }

        public static TaskList GetTaskById(int? id, TaskTrackerDataContext db)
        {
            TaskList tasklist = (from t in db.TaskLists
                                 where t.TaskID == id
                                 select t).FirstOrDefault();

            return tasklist;
        }
    }
}