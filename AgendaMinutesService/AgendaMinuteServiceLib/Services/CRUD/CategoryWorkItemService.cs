using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class CategoryWorkItemService
    {
        private DataAccess mDataAccess;

		public static CategoryWorkItemService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<CategoryWorkItemService>(info);
		}
		
        private CategoryWorkItemService() { }

        internal static CategoryWorkItemService Create(DataAccess da)
        {
            return new CategoryWorkItemService { mDataAccess = da };
        }

        public AMAPI.CategoryWorkItem Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Category.SelectCategoryWorkItem<LMCategoryWorkItem>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("CategoryWorkItem", id);

            return MappingHelper.MapLMDataObject<LMCategoryWorkItem, AMAPI.CategoryWorkItem>(mDataAccess, record, fields);  
        }
    }
}
