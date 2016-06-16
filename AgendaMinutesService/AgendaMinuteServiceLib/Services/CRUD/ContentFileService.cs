using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class ContentFileService
    {
        private DataAccess mDataAccess;

		public static ContentFileService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<ContentFileService>(info);
		}
		
        private ContentFileService() { }

        internal static ContentFileService Create(DataAccess da)
        {
            return new ContentFileService { mDataAccess = da };
        }

        public AMAPI.ContentFile Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Content.SelectContentFile<LMContentFile>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("ContentFile", id);

            return MappingHelper.MapLMDataObject<LMContentFile, AMAPI.ContentFile>(mDataAccess, record, fields);  
        }
    }
}
