using SuperoTasks.WebAPICore.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperoTasks.WebAPICore.Domain
{
    public class Board : SuperoTasksEntityBase
    {
        public string Name { get; set; }
        public virtual IList<Card> Cards { get; set; }
    }
}
