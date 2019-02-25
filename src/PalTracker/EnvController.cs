using Microsoft.AspNetCore.Mvc;

namespace PalTracker{
    [Route("env")]
    public class EnvController : ControllerBase{

        private readonly CloudFoundryInfo cloudFoundryInfo;
        public EnvController(CloudFoundryInfo info){
            cloudFoundryInfo = info;
        }

        [HttpGet]
        public CloudFoundryInfo Get() => cloudFoundryInfo;

    }
}