using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class MeetingTypeService
    {
        private DataAccess mDataAccess;

		public static MeetingTypeService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<MeetingTypeService>(info);
		}
		
        private MeetingTypeService() { }

        internal static MeetingTypeService Create(DataAccess da)
        {
            return new MeetingTypeService { mDataAccess = da };
        }

        public AMAPI.MeetingType Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Meeting.SelectMeetingType<LMMeetingType>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("MeetingType", id);

            return MappingHelper.MapLMDataObject<LMMeetingType, AMAPI.MeetingType>(mDataAccess, record, fields);  
        }
    }
}
