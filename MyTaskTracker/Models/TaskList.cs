using MyTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTaskTracker.Models
{
    public partial class TaskList
    {

        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //public DateTime? FormattedDate
        //{
        //    get
        //    {
        //        return Convert.ToDateTime(this.DueDate);
        //    }
        //    set
        //    {
        //        this.DueDate = value;
        //    }
        //}

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
            orgTaskList.DueDate = tasklist.DueDate;
            orgTaskList.TaskText = tasklist.TaskText;
            orgTaskList.TaskComplete = tasklist.TaskComplete;
        }

        public static TaskList GetTaskById(int? id, TaskTrackerDataContext db)
        {
            TaskList tasklist = (from t in db.TaskLists
                                 where t.TaskID == id
                                 select t).FirstOrDefault();

            return tasklist;
        }

        public static void DeleteById(int? id, TaskTrackerDataContext db)
        {
            var tasksUsersWithSameId = from tu in db.TaskOwners
                                       where tu.TaskId == id
                                       select tu;

            db.TaskOwners.DeleteAllOnSubmit(tasksUsersWithSameId);
            db.SubmitChanges();

            TaskList tas = (from t in db.TaskLists
                            where t.TaskID == id
                            select t).FirstOrDefault();

            db.TaskLists.DeleteOnSubmit(tas);
            db.SubmitChanges();
        }
    }
}