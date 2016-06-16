using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class LegiFileTypeService
    {
        private DataAccess mDataAccess;

		public static LegiFileTypeService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<LegiFileTypeService>(info);
		}
		
        private LegiFileTypeService() { }

        internal static LegiFileTypeService Create(DataAccess da)
        {
            return new LegiFileTypeService { mDataAccess = da };
        }

        public AMAPI.LegiFileType Get(Int16 id, string[] fields)
        {            
            var record = mDataAccess.LegiFile.SelectLegiFileType<LMLegiFileType>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("LegiFileType", id);

            return MappingHelper.MapLMDataObject<LMLegiFileType, AMAPI.LegiFileType>(mDataAccess, record, fields);  
        }
    }
}
