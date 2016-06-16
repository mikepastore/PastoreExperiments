using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class DistributionListService
    {
        private DataAccess mDataAccess;

		public static DistributionListService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<DistributionListService>(info);
		}
		
        private DistributionListService() { }

        internal static DistributionListService Create(DataAccess da)
        {
            return new DistributionListService { mDataAccess = da };
        }

        public AMAPI.DistributionList Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Agency.SelectDistributionList<LMDistributionList>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("DistributionList", id);

            return MappingHelper.MapLMDataObject<LMDistributionList, AMAPI.DistributionList>(mDataAccess, record, fields);  
        }
    }
}
