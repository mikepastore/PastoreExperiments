using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class CommunicationService
    {
        private DataAccess mDataAccess;

		public static CommunicationService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<CommunicationService>(info);
		}
		
        private CommunicationService() { }

        internal static CommunicationService Create(DataAccess da)
        {
            return new CommunicationService { mDataAccess = da };
        }

        public AMAPI.Communication Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Communication.SelectCommunication<LMCommunication>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Communication", id);

            return MappingHelper.MapLMDataObject<LMCommunication, AMAPI.Communication>(mDataAccess, record, fields);  
        }
    }
}
