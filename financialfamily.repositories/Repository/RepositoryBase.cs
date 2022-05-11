using System.Globalization;
using financialfamily.domain.Interfaces;
using financialfamily.repositories.Interfaces;

namespace financialfamily.repositories.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : IEntityBase
    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}