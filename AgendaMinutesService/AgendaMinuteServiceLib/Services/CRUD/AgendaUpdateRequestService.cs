using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class AgendaUpdateRequestService
    {
        private DataAccess mDataAccess;

		public static AgendaUpdateRequestService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<AgendaUpdateRequestService>(info);
		}
		
        private AgendaUpdateRequestService() { }

        internal static AgendaUpdateRequestService Create(DataAccess da)
        {
            return new AgendaUpdateRequestService { mDataAccess = da };
        }

        public AMAPI.AgendaUpdateRequest Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Agenda.SelectAgendaUpdateRequest<LMAgendaUpdateRequest>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("AgendaUpdateRequest", id);

            return MappingHelper.MapLMDataObject<LMAgendaUpdateRequest, AMAPI.AgendaUpdateRequest>(mDataAccess, record, fields);  
        }
    }
}
