using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTaskTracker.Models
{
    public partial class TaskTracker
    {
        public static IEnumerable<TaskTracker> GetTasksByUser(string usrName, TaskTrackerDataContext db)
        {
            var usrTask = from tskUsr in db.TaskOwners
                           join tsk in db.TaskLists on tskUsr.TaskId equals tsk.TaskID
                           where tskUsr.UserName == usrName
                           select tsk;

            return usrTask;
        }
    }
}