using MicroserviceTemplate.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace MicroserviceTemplate.Query.Api.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public ItemController()
        {
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Item>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([Required] string tenant)
        {
            // Execute your query here
            var items = new List<Item>();
            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get([Required] string id, [Required] string tenant)
        {
            // Execute your query here
            var item = new Item();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
    }
}