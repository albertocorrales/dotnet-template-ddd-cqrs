using MicroserviceTemplate.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace MicroserviceTemplate.Command.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public ItemController()
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateItem(Item request)
        {
            // Execute your command here

            return Accepted();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateItem([Required] Guid id, Item request)
        {
            // Execute your command here

            return Accepted();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteItem([Required] Guid id, [Required] string tenant)
        {
            // Execute your command here

            return Accepted();
        }
    }
}
