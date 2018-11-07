using SuperoTasks.WebAPICore.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperoTasks.WebAPICore.Domain.DTO
{
    public class UpdateCardBoardDTO 
    {
        public int BoardId { get; set; }
        public int CardId { get; set; }
     
    }
}
