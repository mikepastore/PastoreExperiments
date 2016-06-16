using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class PublicHearingService
    {
        private DataAccess mDataAccess;

		public static PublicHearingService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<PublicHearingService>(info);
		}
		
        private PublicHearingService() { }

        internal static PublicHearingService Create(DataAccess da)
        {
            return new PublicHearingService { mDataAccess = da };
        }

        public AMAPI.PublicHearing Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Hearing.SelectPublicHearing<LMPublicHearing>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("PublicHearing", id);

            return MappingHelper.MapLMDataObject<LMPublicHearing, AMAPI.PublicHearing>(mDataAccess, record, fields);  
        }
    }
}
