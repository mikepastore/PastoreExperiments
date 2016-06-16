using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMAPI;

namespace AgendaMinutesServiceLib
{
    public class AgendaService
    {
        private DataAccess mDataAccess;

		public static AgendaService Create(ConnectionInfo info) 
		{
			return ServiceFactory.Create<AgendaService>(info);
		}
		
        private AgendaService() { }

        internal static AgendaService Create(DataAccess da)
        {
            return new AgendaService { mDataAccess = da };
        }

        public AMAPI.Agenda Get(Int32 id, string[] fields)
        {            
            var record = mDataAccess.Agenda.SelectAgenda<LMAgenda>(id, null).FirstOrDefault();
            if (record == null)
                throw new RecordNotFoundException("Agenda", id);

            return MappingHelper.MapLMDataObject<LMAgenda, AMAPI.Agenda>(mDataAccess, record, fields);  
        }
    }
}
