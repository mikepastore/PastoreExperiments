using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class FunctionalCategoryService
    {
        private DataAccess mDataAccess;

		public static FunctionalCategoryService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<FunctionalCategoryService>(info);
		}
		
        private FunctionalCategoryService() { }

        internal static FunctionalCategoryService Create(DataAccess da)
        {
            return new FunctionalCategoryService { mDataAccess = da };
        }

        public AMAPI.FunctionalCategory Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Agency.SelectFunctionalCategory<LMFunctionalCategory>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("FunctionalCategory", id);

            return MappingHelper.MapLMDataObject<LMFunctionalCategory, AMAPI.FunctionalCategory>(mDataAccess, record, fields);  
        }
    }
}
