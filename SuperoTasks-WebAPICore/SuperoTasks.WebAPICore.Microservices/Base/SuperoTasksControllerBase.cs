using SuperoTasks.WebAPICore.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperoTasks.WebAPICore.Microservices.Base
{
    public class SuperoTasksControllerBase<TService, TEntity> : Controller where TEntity : class where TService : class
    {

    }
}
