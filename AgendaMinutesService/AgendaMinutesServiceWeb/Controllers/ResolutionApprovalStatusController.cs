using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AMAPI;
using AgendaMinutesServiceLib;


namespace AgendaMinutesServiceWeb.Controllers
{
    public class ResolutionApprovalStatusController : ApiController
    {
        [HttpGet]
        public Lookup[] Get()
        {
			return Lookup.FromEnums<AMAPI.ResolutionApprovalStatus>();
        }
    }
}
