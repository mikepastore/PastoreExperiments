using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class ResolutionService
    {
        private DataAccess mDataAccess;

		public static ResolutionService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<ResolutionService>(info);
		}
		
        private ResolutionService() { }

        internal static ResolutionService Create(DataAccess da)
        {
            return new ResolutionService { mDataAccess = da };
        }

        public AMAPI.Resolution Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Resolution.SelectResolution<LMResolution>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Resolution", id);

            return MappingHelper.MapLMDataObject<LMResolution, AMAPI.Resolution>(mDataAccess, record, fields);  
        }
    }
}
