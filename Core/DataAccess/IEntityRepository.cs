using System.Linq.Expressions;
namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // bu da boş geçilebilir yani p=>p.ıd gibi bi kod yazılmayabilir yani
        T Get(Expression<Func<T,bool>>filter); //Expression<Func<T,bool>> şu kod bloğu bize p=>p.ıd gibi bi kod yazma imkanı sunacak filter yerine yazacaz 
    }
}
