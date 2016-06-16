using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class TemplateService
    {
        private DataAccess mDataAccess;

		public static TemplateService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<TemplateService>(info);
		}
		
        private TemplateService() { }

        internal static TemplateService Create(DataAccess da)
        {
            return new TemplateService { mDataAccess = da };
        }

        public AMAPI.Template Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Template.SelectTemplate<LMTemplate>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Template", id);

            return MappingHelper.MapLMDataObject<LMTemplate, AMAPI.Template>(mDataAccess, record, fields);  
        }
    }
}
