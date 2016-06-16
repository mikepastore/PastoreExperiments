using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class CommunicationTypeService
    {
        private DataAccess mDataAccess;

		public static CommunicationTypeService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<CommunicationTypeService>(info);
		}
		
        private CommunicationTypeService() { }

        internal static CommunicationTypeService Create(DataAccess da)
        {
            return new CommunicationTypeService { mDataAccess = da };
        }

        public AMAPI.CommunicationType Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Communication.SelectCommunicationType<LMCommunicationType>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("CommunicationType", id);

            return MappingHelper.MapLMDataObject<LMCommunicationType, AMAPI.CommunicationType>(mDataAccess, record, fields);  
        }
    }
}
