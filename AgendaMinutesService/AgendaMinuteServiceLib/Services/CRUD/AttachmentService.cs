using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class AttachmentService
    {
        private DataAccess mDataAccess;

		public static AttachmentService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<AttachmentService>(info);
		}
		
        private AttachmentService() { }

        internal static AttachmentService Create(DataAccess da)
        {
            return new AttachmentService { mDataAccess = da };
        }

        public AMAPI.Attachment Get(Int64 id, string[] fields)
        {            
            var record = mDataAccess.Attachment.SelectAttachment<LMAttachment>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Attachment", id);

            return MappingHelper.MapLMDataObject<LMAttachment, AMAPI.Attachment>(mDataAccess, record, fields);  
        }
    }
}
