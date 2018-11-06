using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperoTasks.WebAPICore.Domain.Base
{

    public interface ISuperoTasksServiceBase<T> where T : SuperoTasksEntityBase
    {
        T Add<V>(T obj) where V : AbstractValidator<T>;

        T Update<V>(T obj) where V : AbstractValidator<T>;

        void Delete(int? id);

        T GetById(int? id);

        IQueryable<T> Get();

    }
}
