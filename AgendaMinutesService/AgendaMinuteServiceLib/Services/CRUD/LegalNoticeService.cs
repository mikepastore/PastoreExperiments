using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class LegalNoticeService
    {
        private DataAccess mDataAccess;

		public static LegalNoticeService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<LegalNoticeService>(info);
		}
		
        private LegalNoticeService() { }

        internal static LegalNoticeService Create(DataAccess da)
        {
            return new LegalNoticeService { mDataAccess = da };
        }

        public AMAPI.LegalNotice Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Notice.SelectLegalNotice<LMLegalNotice>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("LegalNotice", id);

            return MappingHelper.MapLMDataObject<LMLegalNotice, AMAPI.LegalNotice>(mDataAccess, record, fields);  
        }
    }
}
