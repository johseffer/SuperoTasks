using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperoTasks.WebAPICore.Domain.Base
{
    public interface ISuperoTasksRepositoryBase<T> where T : SuperoTasksEntityBase
    {
        void Insert(T obj);

        void Update(T obj);

        void Remove(int? id);

        T SelectById(int? id);

        IQueryable<T> SelectAll();
    }
}
