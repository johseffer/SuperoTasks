using SuperoTasks.WebAPICore.Domain;
using SuperoTasks.WebAPICore.Domain.DTO;
using SuperoTasks.WebAPICore.Domain.Interfaces.Service;
using SuperoTasks.WebAPICore.Services.Base;
using System;
using System.Linq;

namespace SuperoTasks.WebAPICore.Services.Service
{
    public class CardService : SuperoTasksServiceBase<Card>, ICardService
    {

        private readonly BoardService boardService = new BoardService();
        public CardService()
        {

        }

        public override Card Add<V>(Card obj)
        {
            obj.CreationDate = DateTime.Now;
            return base.Add<V>(obj);
        }

        public Card UpdateCardBoard(UpdateCardBoardDTO dto)
        {
            Card card = this.GetById(dto.CardId);
            card.BoardId = dto.BoardId;
            return Update(card);
        }

        public override Card Update<V>(Card obj)
        {
            if (obj.BoardId == boardService.Get().Where(x => x.Name == "In Progress").FirstOrDefault().Id)
            {
                obj.StartedDate = DateTime.Now;
            }
            else if (obj.BoardId == boardService.Get().Where(x => x.Name == "Done").FirstOrDefault().Id)
            {
                obj.FinishedDate = DateTime.Now;
            }

            return base.Update<V>(obj);
        }

        public override void Delete(int? id)
        {
            base.Delete(id);
        }
    }
}
