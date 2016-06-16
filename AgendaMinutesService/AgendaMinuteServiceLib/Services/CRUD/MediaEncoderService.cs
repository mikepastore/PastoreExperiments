using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class MediaEncoderService
    {
        private DataAccess mDataAccess;

		public static MediaEncoderService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<MediaEncoderService>(info);
		}
		
        private MediaEncoderService() { }

        internal static MediaEncoderService Create(DataAccess da)
        {
            return new MediaEncoderService { mDataAccess = da };
        }

        public AMAPI.MediaEncoder Get(Int16 id, string[] fields)
        {            
            var record = mDataAccess.Encoder.SelectMediaEncoder<LMMediaEncoder>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("MediaEncoder", id);

            return MappingHelper.MapLMDataObject<LMMediaEncoder, AMAPI.MediaEncoder>(mDataAccess, record, fields);  
        }
    }
}
