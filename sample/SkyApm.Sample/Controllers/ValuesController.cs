namespace SkyApm.Sample.Controllers
{
    using EasyCaching.Core;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEasyCachingProvider _provider;

        public ValuesController(IEasyCachingProvider provider)
        {
            this._provider = provider;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _provider.Set("test-key", "test-value", TimeSpan.FromSeconds(20));
            _provider.Exists("test-key");
            _provider.Get<string>("test-key");

            return new string[] { "value1", "value2" };
        }        
    }
}
