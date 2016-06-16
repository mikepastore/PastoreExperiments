using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class VoteResultService
    {
        private DataAccess mDataAccess;

		public static VoteResultService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<VoteResultService>(info);
		}
		
        private VoteResultService() { }

        internal static VoteResultService Create(DataAccess da)
        {
            return new VoteResultService { mDataAccess = da };
        }

        public AMAPI.VoteResult Get(Int16 id, string[] fields)
        {            
            var record = mDataAccess.Vote.SelectVoteResult<LMVoteResult>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("VoteResult", id);

            return MappingHelper.MapLMDataObject<LMVoteResult, AMAPI.VoteResult>(mDataAccess, record, fields);  
        }
    }
}
