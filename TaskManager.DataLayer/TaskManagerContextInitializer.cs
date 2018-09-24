using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.EntityModel;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.Entity;


namespace TaskManager.DataLayer
{
    class TaskManagerContextInitializer:DropCreateDatabaseAlways<TaskManagerContext>
    {
        public override void InitializeDatabase(TaskManagerContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}
