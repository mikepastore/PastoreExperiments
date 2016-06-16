using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class MediaEventTypeService
    {
        private DataAccess mDataAccess;

		public static MediaEventTypeService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<MediaEventTypeService>(info);
		}
		
        private MediaEventTypeService() { }

        internal static MediaEventTypeService Create(DataAccess da)
        {
            return new MediaEventTypeService { mDataAccess = da };
        }

        public AMAPI.MediaEventType Get(Int16 id, string[] fields)
        {            
            var record = mDataAccess.Media.SelectMediaEventType<LMMediaEventType>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("MediaEventType", id);

            return MappingHelper.MapLMDataObject<LMMediaEventType, AMAPI.MediaEventType>(mDataAccess, record, fields);  
        }
    }
}
