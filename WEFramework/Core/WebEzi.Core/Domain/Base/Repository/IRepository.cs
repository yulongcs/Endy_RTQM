using System.Data;
using WebEzi.Base.DefinedData;
using WebEzi.Core.Domain.Base.Model;

namespace WebEzi.Core.Domain.Base.Repository
{
    public interface IRepository
    {
        void Insert(IAggregateRoot model);

        void Update(IAggregateRoot model);

        void Delete(WEKey key);
    }

    public interface IRepository<T> : IRepository
        where T : IAggregateRoot
    {
        void Insert(T model);

        void Update(T model);
    }
}
