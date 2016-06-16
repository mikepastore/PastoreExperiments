using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class MeetingLocationService
    {
        private DataAccess mDataAccess;

		public static MeetingLocationService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<MeetingLocationService>(info);
		}
		
        private MeetingLocationService() { }

        internal static MeetingLocationService Create(DataAccess da)
        {
            return new MeetingLocationService { mDataAccess = da };
        }

        public AMAPI.MeetingLocation Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Meeting.SelectMeetingLocation<LMMeetingLocation>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("MeetingLocation", id);

            return MappingHelper.MapLMDataObject<LMMeetingLocation, AMAPI.MeetingLocation>(mDataAccess, record, fields);  
        }
    }
}
