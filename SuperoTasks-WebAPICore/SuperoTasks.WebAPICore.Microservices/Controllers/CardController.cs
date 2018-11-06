using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperoTasks.WebAPICore.Domain;
using SuperoTasks.WebAPICore.Domain.DTO;
using SuperoTasks.WebAPICore.Microservices.Base;
using SuperoTasks.WebAPICore.Services.Service;
using SuperoTasks.WebAPICore.Services.Validator;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperoTasks.WebAPICore.Microservices.Controllers
{
    [Route("api/[controller]")]
    public class CardController : SuperoTasksControllerBase<CardService, Card>
    {
        private CardService service = new CardService();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Card item)
        {
            try
            {
                if (item == null)
                {
                    return NotFound();
                }

                service.Add<CardValidator>(item);

                return new ObjectResult(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Card item)
        {
            try
            {
                if (item == null)
                {
                    return NotFound();
                }

                service.Update<CardValidator>(item);

                return new ObjectResult(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("UpdateBoard")]
        public async Task<IActionResult> UpdateBoard([FromBody] UpdateCardBoardDTO item)
        {
            try
            {
                if (item == null)
                {
                    return NotFound();
                }

                service.UpdateCardBoard(item);

                return new ObjectResult(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }

                service.Delete(id);

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return new ObjectResult(service.Get().Include(x => x.Board).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }

                return new ObjectResult(service.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}