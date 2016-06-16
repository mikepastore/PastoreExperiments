using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class OrgGroupTypeService
    {
        private DataAccess mDataAccess;

		public static OrgGroupTypeService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<OrgGroupTypeService>(info);
		}
		
        private OrgGroupTypeService() { }

        internal static OrgGroupTypeService Create(DataAccess da)
        {
            return new OrgGroupTypeService { mDataAccess = da };
        }

        public AMAPI.OrgGroupType Get(Int16 id, string[] fields)
        {            
            var record = mDataAccess.Agency.SelectOrgGroupType<LMOrgGroupType>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("OrgGroupType", id);

            return MappingHelper.MapLMDataObject<LMOrgGroupType, AMAPI.OrgGroupType>(mDataAccess, record, fields);  
        }
    }
}
