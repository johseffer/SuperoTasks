using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuperoTasks.WebAPICore.Domain.Base
{
    public class SuperoTasksEntityBase
    {
        [Key]
        public int? Id { get; set; }
    }
}
