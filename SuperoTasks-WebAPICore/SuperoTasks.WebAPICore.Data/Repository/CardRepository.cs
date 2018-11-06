using SuperoTasks.WebAPICore.Data.Base;
using SuperoTasks.WebAPICore.Domain;
using SuperoTasks.WebAPICore.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperoTasks.WebAPICore.Data.Repository
{
    public class CardRepository : SuperoTasksRepositoryBase<Card>, ICardRepository
    {
        public CardRepository()
        {
        }
    }
}
