using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class MeetingService
    {
        private DataAccess mDataAccess;

		public static MeetingService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<MeetingService>(info);
		}
		
        private MeetingService() { }

        internal static MeetingService Create(DataAccess da)
        {
            return new MeetingService { mDataAccess = da };
        }

        public AMAPI.Meeting Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Meeting.SelectMeeting<LMMeeting>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Meeting", id);

            return MappingHelper.MapLMDataObject<LMMeeting, AMAPI.Meeting>(mDataAccess, record, fields);  
        }
    }
}
