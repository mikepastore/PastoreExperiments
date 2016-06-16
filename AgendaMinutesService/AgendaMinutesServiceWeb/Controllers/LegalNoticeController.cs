using AgendaMinutesServiceLib;
using LegMan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgendaMinutesServiceWeb;

namespace AgendaMinutesServiceWeb.Controllers
{
    public class LegalNoticeController : ApiController
    {
	    [HttpGet]
        public AMAPI.LegalNotice Get(Int32 id, string fields=null)
        {
            var connection = new HTTPContextConnectionInfoProvider().GetConnectionInfo();
            var service = LegalNoticeService.Create(connection);
            return service.Get(id,fields.CSVToArray());
        }
    }
}