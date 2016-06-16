using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class AttachmentCategoryService
    {
        private DataAccess mDataAccess;

		public static AttachmentCategoryService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<AttachmentCategoryService>(info);
		}
		
        private AttachmentCategoryService() { }

        internal static AttachmentCategoryService Create(DataAccess da)
        {
            return new AttachmentCategoryService { mDataAccess = da };
        }

        public AMAPI.AttachmentCategory Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Attachment.SelectAttachmentCategory<LMAttachmentCategory>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("AttachmentCategory", id);

            return MappingHelper.MapLMDataObject<LMAttachmentCategory, AMAPI.AttachmentCategory>(mDataAccess, record, fields);  
        }
    }
}
