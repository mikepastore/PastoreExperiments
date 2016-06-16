using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class SpeakerSignupService
    {
        private DataAccess mDataAccess;

		public static SpeakerSignupService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<SpeakerSignupService>(info);
		}
		
        private SpeakerSignupService() { }

        internal static SpeakerSignupService Create(DataAccess da)
        {
            return new SpeakerSignupService { mDataAccess = da };
        }

        public AMAPI.SpeakerSignup Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Speaker.SelectSpeakerSignup<LMSpeakerSignup>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("SpeakerSignup", id);

            return MappingHelper.MapLMDataObject<LMSpeakerSignup, AMAPI.SpeakerSignup>(mDataAccess, record, fields);  
        }
    }
}
