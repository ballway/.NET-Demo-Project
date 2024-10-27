using Autofac;
using BookProject.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.WebAPI.Controllers
{
    [Route("crawler")]
    [ApiController]
    public class CrawlerController : ControllerBase
    {
        private readonly ILogger<CrawlerController> _logger;

        public CrawlerController(IComponentContext componentContext, ILogger<CrawlerController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 取得指定網址的內容。
        /// </summary>
        [HttpGet("/crawler/get")]
        public IActionResult GetContent(string url)
        {
            var result = WebRequestUtility.GetResponse(url);

            return Ok(result);
        }
    }
}
