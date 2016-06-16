using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class ResolutionCategoryService
    {
        private DataAccess mDataAccess;

		public static ResolutionCategoryService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<ResolutionCategoryService>(info);
		}
		
        private ResolutionCategoryService() { }

        internal static ResolutionCategoryService Create(DataAccess da)
        {
            return new ResolutionCategoryService { mDataAccess = da };
        }

        public AMAPI.ResolutionCategory Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Resolution.SelectResolutionCategory<LMResolutionCategory>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("ResolutionCategory", id);

            return MappingHelper.MapLMDataObject<LMResolutionCategory, AMAPI.ResolutionCategory>(mDataAccess, record, fields);  
        }
    }
}
