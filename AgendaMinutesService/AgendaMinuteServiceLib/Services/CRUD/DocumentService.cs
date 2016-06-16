using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class DocumentService
    {
        private DataAccess mDataAccess;

		public static DocumentService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<DocumentService>(info);
		}
		
        private DocumentService() { }

        internal static DocumentService Create(DataAccess da)
        {
            return new DocumentService { mDataAccess = da };
        }

        public AMAPI.Document Get(Int64 id, string[] fields)
        {            
            var record = mDataAccess.Document.SelectDocument<LMDocument>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Document", id);

            return MappingHelper.MapLMDataObject<LMDocument, AMAPI.Document>(mDataAccess, record, fields);  
        }
    }
}
