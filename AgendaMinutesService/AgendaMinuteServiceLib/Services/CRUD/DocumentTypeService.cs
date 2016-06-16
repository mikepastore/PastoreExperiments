using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class DocumentTypeService
    {
        private DataAccess mDataAccess;

		public static DocumentTypeService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<DocumentTypeService>(info);
		}
		
        private DocumentTypeService() { }

        internal static DocumentTypeService Create(DataAccess da)
        {
            return new DocumentTypeService { mDataAccess = da };
        }

        public AMAPI.DocumentType Get(Int16 id, string[] fields)
        {            
            var record = mDataAccess.Document.SelectDocumentType<LMDocumentType>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("DocumentType", id);

            return MappingHelper.MapLMDataObject<LMDocumentType, AMAPI.DocumentType>(mDataAccess, record, fields);  
        }
    }
}
