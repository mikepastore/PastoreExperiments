using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class MinutesService
    {
        private DataAccess mDataAccess;

		public static MinutesService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<MinutesService>(info);
		}
		
        private MinutesService() { }

        internal static MinutesService Create(DataAccess da)
        {
            return new MinutesService { mDataAccess = da };
        }

        public AMAPI.Minutes Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Minutes.SelectMinutes<LMMinutes>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Minutes", id);

            return MappingHelper.MapLMDataObject<LMMinutes, AMAPI.Minutes>(mDataAccess, record, fields);  
        }
    }
}
