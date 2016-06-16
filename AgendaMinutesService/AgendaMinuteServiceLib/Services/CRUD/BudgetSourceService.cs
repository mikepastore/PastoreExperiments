using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class BudgetSourceService
    {
        private DataAccess mDataAccess;

		public static BudgetSourceService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<BudgetSourceService>(info);
		}
		
        private BudgetSourceService() { }

        internal static BudgetSourceService Create(DataAccess da)
        {
            return new BudgetSourceService { mDataAccess = da };
        }

        public AMAPI.BudgetSource Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Agency.SelectBudgetSource<LMBudgetSource>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("BudgetSource", id);

            return MappingHelper.MapLMDataObject<LMBudgetSource, AMAPI.BudgetSource>(mDataAccess, record, fields);  
        }
    }
}
