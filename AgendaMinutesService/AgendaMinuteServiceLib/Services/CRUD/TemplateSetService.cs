using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class TemplateSetService
    {
        private DataAccess mDataAccess;

		public static TemplateSetService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<TemplateSetService>(info);
		}
		
        private TemplateSetService() { }

        internal static TemplateSetService Create(DataAccess da)
        {
            return new TemplateSetService { mDataAccess = da };
        }

        public AMAPI.TemplateSet Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Template.SelectTemplateSet<LMTemplateSet>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("TemplateSet", id);

            return MappingHelper.MapLMDataObject<LMTemplateSet, AMAPI.TemplateSet>(mDataAccess, record, fields);  
        }
    }
}
