using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class DepartmentService
    {
        private DataAccess mDataAccess;

		public static DepartmentService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<DepartmentService>(info);
		}
		
        private DepartmentService() { }

        internal static DepartmentService Create(DataAccess da)
        {
            return new DepartmentService { mDataAccess = da };
        }

        public AMAPI.Department Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Dept.SelectDepartment<LMDepartment>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Department", id);

            return MappingHelper.MapLMDataObject<LMDepartment, AMAPI.Department>(mDataAccess, record, fields);  
        }
    }
}
