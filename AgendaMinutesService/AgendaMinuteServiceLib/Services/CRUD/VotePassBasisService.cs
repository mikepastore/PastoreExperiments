using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class VotePassBasisService
    {
        private DataAccess mDataAccess;

		public static VotePassBasisService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<VotePassBasisService>(info);
		}
		
        private VotePassBasisService() { }

        internal static VotePassBasisService Create(DataAccess da)
        {
            return new VotePassBasisService { mDataAccess = da };
        }

        public AMAPI.VotePassBasis Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Vote.SelectVotePassBasis<LMVotePassBasis>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("VotePassBasis", id);

            return MappingHelper.MapLMDataObject<LMVotePassBasis, AMAPI.VotePassBasis>(mDataAccess, record, fields);  
        }
    }
}
