using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class RecipientService
    {
        private DataAccess mDataAccess;

		public static RecipientService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<RecipientService>(info);
		}
		
        private RecipientService() { }

        internal static RecipientService Create(DataAccess da)
        {
            return new RecipientService { mDataAccess = da };
        }

        public AMAPI.Recipient Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Agency.SelectRecipient<LMRecipient>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Recipient", id);

            return MappingHelper.MapLMDataObject<LMRecipient, AMAPI.Recipient>(mDataAccess, record, fields);  
        }
    }
}
