using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperoTasks.WebAPICore.Domain;
using SuperoTasks.WebAPICore.Microservices.Base;
using SuperoTasks.WebAPICore.Services.Service;
using SuperoTasks.WebAPICore.Services.Validator;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SuperoTasks.WebAPICore.Microservices.Controllers
{
    [Route("api/[controller]")]
    public class BoardController : SuperoTasksControllerBase<BoardService, Board>
    {
        private BoardService service = new BoardService();
      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Board item)
        {
            try
            {
                if (item == null)
                {
                    return NotFound();
                }

                service.Add<BoardValidator>(item);

                return new ObjectResult(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Board item)
        {
            try
            {
                if (item == null)
                {
                    return NotFound();
                }

                //item.BoardTechnologies.ToList().ForEach(x =>
                //                {
                //                    if (serviceBoardTechnology.Get().Any(y => y.IdBoard == x.IdBoard && y.IdTechnology == x.IdTechnology))
                //                    {
                //                        var dbBoardTechnology = serviceBoardTechnology.Get().SingleOrDefault(y => y.IdBoard == x.IdBoard && y.IdTechnology == x.IdTechnology);
                //                        dbBoardTechnology.Points = x.Points;
                //                        serviceBoardTechnology.Update<BoardTechnologyValidator>(dbBoardTechnology);
                //                    }
                //                    else
                //                        serviceBoardTechnology.Add<BoardTechnologyValidator>(x);
                //                });

                //serviceBoardTechnology.Get()
                //    .Where(y => !item.BoardTechnologies.ToList().Any(z => z.IdTechnology == y.IdTechnology)).ToList()
                //    .ForEach(x =>
                //    {
                //        serviceBoardApplicationTechnology.Get().Where(y => y.IdBoardTechnology == x.Id).ToList().ForEach(u =>
                //        {
                //            serviceBoardApplicationTechnology.Delete(u.Id);
                //        });
                //        serviceBoardTechnology.Delete(x.Id);
                //    });

                service.Update<BoardValidator>(item);

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
                return new ObjectResult(service.Get().Include(x => x.Cards).ToList());
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