using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class TagService
    {
        private DataAccess mDataAccess;

		public static TagService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<TagService>(info);
		}
		
        private TagService() { }

        internal static TagService Create(DataAccess da)
        {
            return new TagService { mDataAccess = da };
        }

        public AMAPI.Tag Get(Int16 id, string[] fields)
        {            
            var record = mDataAccess.Agency.SelectTag<LMTag>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Tag", id);

            return MappingHelper.MapLMDataObject<LMTag, AMAPI.Tag>(mDataAccess, record, fields);  
        }
    }
}
