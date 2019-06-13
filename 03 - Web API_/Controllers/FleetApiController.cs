using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FinalProject
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class FleetApiController : ApiController
    {
        private FleetLogic logic = new FleetLogic();

        [HttpGet]
        [Route("fleet")]
        public HttpResponseMessage GetEntireFleet()
        {
            try
            {
                List<FleetModel> fleet = logic.GetEntireFleet();
                return Request.CreateResponse(HttpStatusCode.OK, fleet);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorHelper.GetError(e));
            }
        }
    }
}
