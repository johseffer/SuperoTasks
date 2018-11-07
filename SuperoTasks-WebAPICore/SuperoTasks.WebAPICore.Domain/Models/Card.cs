using SuperoTasks.WebAPICore.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperoTasks.WebAPICore.Domain
{
    public class Card : SuperoTasksEntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
    }
}
