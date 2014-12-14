namespace ForumSystem.Data.Common.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public interface IRepository<T> : IDisposable where T : class
    {
        DbContext Context { get; set; }

        IQueryable<T> All();

        T GetById(int id);

        T GetById(string id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

        void Delete(string id);

        void Detach(T entity);

        int SaveChanges();
    }
}
