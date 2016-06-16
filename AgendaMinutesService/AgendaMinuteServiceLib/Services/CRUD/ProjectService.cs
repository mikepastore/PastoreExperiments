using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class ProjectService
    {
        private DataAccess mDataAccess;

		public static ProjectService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<ProjectService>(info);
		}
		
        private ProjectService() { }

        internal static ProjectService Create(DataAccess da)
        {
            return new ProjectService { mDataAccess = da };
        }

        public AMAPI.Project Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Project.SelectProject<LMProject>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Project", id);

            return MappingHelper.MapLMDataObject<LMProject, AMAPI.Project>(mDataAccess, record, fields);  
        }
    }
}
