using Microsoft.EntityFrameworkCore;
using SuperoTasks.WebAPICore.Data.Context;
using SuperoTasks.WebAPICore.Domain.Base;
using System.Linq;

namespace SuperoTasks.WebAPICore.Data.Base
{
    public class SuperoTasksRepositoryBase<T> : ISuperoTasksRepositoryBase<T> where T : SuperoTasksEntityBase
    {
        private SuperoTasksContext context = new SuperoTasksContext();

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Remove(int? id)
        {
            context.Set<T>().Remove(SelectById(id));
            context.SaveChanges();
        }
       
        public IQueryable<T> SelectAll()
        {
            return context.Set<T>().AsNoTracking().AsQueryable();
        }

        public T SelectById(int? id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
