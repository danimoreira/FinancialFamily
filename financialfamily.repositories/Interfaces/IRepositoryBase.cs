using financialfamily.domain.Interfaces;

namespace financialfamily.repositories.Interfaces
{
    public interface IRepositoryBase<T> where T : IEntityBase
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void Delete(Guid id);
        public T GetById(Guid id);
        public List<T> GetAll();
    }
}