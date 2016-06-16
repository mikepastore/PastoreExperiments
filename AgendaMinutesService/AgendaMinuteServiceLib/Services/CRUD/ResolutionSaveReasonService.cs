using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class ResolutionSaveReasonService
    {
        private DataAccess mDataAccess;

		public static ResolutionSaveReasonService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<ResolutionSaveReasonService>(info);
		}
		
        private ResolutionSaveReasonService() { }

        internal static ResolutionSaveReasonService Create(DataAccess da)
        {
            return new ResolutionSaveReasonService { mDataAccess = da };
        }

        public AMAPI.ResolutionSaveReason Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Resolution.SelectResolutionSaveReason<LMResolutionSaveReason>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("ResolutionSaveReason", id);

            return MappingHelper.MapLMDataObject<LMResolutionSaveReason, AMAPI.ResolutionSaveReason>(mDataAccess, record, fields);  
        }
    }
}
