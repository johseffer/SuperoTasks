using FluentValidation;
using SuperoTasks.WebAPICore.Data.Base;
using SuperoTasks.WebAPICore.Domain.Base;
using System;
using System.Linq;

namespace SuperoTasks.WebAPICore.Services.Base
{
    public class SuperoTasksServiceBase<T> : ISuperoTasksServiceBase<T> where T : SuperoTasksEntityBase
    {
        private SuperoTasksRepositoryBase<T> repository = new SuperoTasksRepositoryBase<T>();

        public virtual T Add<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());
            repository.Insert(obj);
            return obj;
        }

        public virtual void Delete(int? id)
        {
            repository.Remove(id);
        }

        public virtual void DeleteOnSubmit(int? id)
        {
            repository.Remove(id);
        }

        public virtual IQueryable<T> Get()
        {
            return repository.SelectAll();
        }

        public virtual T GetById(int? id)
        {
            return repository.SelectById(id);
        }

        public virtual T Update(T obj) 
        {
            repository.Update(obj);
            return obj;
        }

        public virtual T Update<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());
            repository.Update(obj);
            return obj;
        }

        protected virtual void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
            {
                throw new Exception("Registros não detectados!");
            }

            validator.ValidateAndThrow(obj);
        }

    }
}
