using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class MediaService
    {
        private DataAccess mDataAccess;

		public static MediaService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<MediaService>(info);
		}
		
        private MediaService() { }

        internal static MediaService Create(DataAccess da)
        {
            return new MediaService { mDataAccess = da };
        }

        public AMAPI.Media Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Media.SelectMedia<LMMedia>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Media", id);

            return MappingHelper.MapLMDataObject<LMMedia, AMAPI.Media>(mDataAccess, record, fields);  
        }
    }
}
