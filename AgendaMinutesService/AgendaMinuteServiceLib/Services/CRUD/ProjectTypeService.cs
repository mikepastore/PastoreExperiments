using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class ProjectTypeService
    {
        private DataAccess mDataAccess;

		public static ProjectTypeService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<ProjectTypeService>(info);
		}
		
        private ProjectTypeService() { }

        internal static ProjectTypeService Create(DataAccess da)
        {
            return new ProjectTypeService { mDataAccess = da };
        }

        public AMAPI.ProjectType Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Project.SelectProjectType<LMProjectType>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("ProjectType", id);

            return MappingHelper.MapLMDataObject<LMProjectType, AMAPI.ProjectType>(mDataAccess, record, fields);  
        }
    }
}
