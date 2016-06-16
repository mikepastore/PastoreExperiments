using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class MediaEventService
    {
        private DataAccess mDataAccess;

		public static MediaEventService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<MediaEventService>(info);
		}
		
        private MediaEventService() { }

        internal static MediaEventService Create(DataAccess da)
        {
            return new MediaEventService { mDataAccess = da };
        }

        public AMAPI.MediaEvent Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Media.SelectMediaEvent<LMMediaEvent>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("MediaEvent", id);

            return MappingHelper.MapLMDataObject<LMMediaEvent, AMAPI.MediaEvent>(mDataAccess, record, fields);  
        }
    }
}
