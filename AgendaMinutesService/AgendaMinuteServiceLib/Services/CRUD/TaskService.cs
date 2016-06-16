using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class TaskService
    {
        private DataAccess mDataAccess;

		public static TaskService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<TaskService>(info);
		}
		
        private TaskService() { }

        internal static TaskService Create(DataAccess da)
        {
            return new TaskService { mDataAccess = da };
        }

        public AMAPI.Task Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Task.SelectTask<LMTask>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Task", id);

            return MappingHelper.MapLMDataObject<LMTask, AMAPI.Task>(mDataAccess, record, fields);  
        }
    }
}
