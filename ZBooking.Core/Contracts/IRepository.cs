using System.Linq;
using ZBooking.Core.Models;

namespace ZBooking.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void update(T t);
    }
}