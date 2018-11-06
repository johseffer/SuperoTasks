using SuperoTasks.WebAPICore.Domain;
using SuperoTasks.WebAPICore.Domain.Interfaces.Service;
using SuperoTasks.WebAPICore.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperoTasks.WebAPICore.Services.Service
{
    public class BoardService : SuperoTasksServiceBase<Board>, IBoardService
    {
        public BoardService()
        {

        }
    }
}
