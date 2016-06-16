using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class LegalNoticeTypeService
    {
        private DataAccess mDataAccess;

		public static LegalNoticeTypeService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<LegalNoticeTypeService>(info);
		}
		
        private LegalNoticeTypeService() { }

        internal static LegalNoticeTypeService Create(DataAccess da)
        {
            return new LegalNoticeTypeService { mDataAccess = da };
        }

        public AMAPI.LegalNoticeType Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Notice.SelectLegalNoticeType<LMLegalNoticeType>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("LegalNoticeType", id);

            return MappingHelper.MapLMDataObject<LMLegalNoticeType, AMAPI.LegalNoticeType>(mDataAccess, record, fields);  
        }
    }
}
