using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Contact_Extractor.DTOs;
using System.Text.Json;

namespace Web_Contact_Extractor.Controllers
{
    [Route("api/Contact-Extractor")]
    [ApiController]
    public class ContactExtractorController : BaseApiController
    {
        private readonly ILogger<ContactExtractorController> _logger;
        private IContactExtractorContract _contract;

        public ContactExtractorController(ILogger<ContactExtractorController> logger, IContactExtractorContract contract) : base()
        {
            _logger = logger;
            _contract = contract;
        }

        [HttpGet]
        [Route("Url")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ContactDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CrawlContactInfo([FromQuery]string[] url)
        {
            
            // _logger.LogInformation(document.DocumentElement.OuterHtml);
            List<string> urls = url.ToList<string>();
            // url.To
            // for (var i = 0; i < url.Length; i++)
            // {
            //     urls.Add(url[i]);
            // }
            return Ok(await _contract.CrawlContactInfo(urls));
        }
    }
}
