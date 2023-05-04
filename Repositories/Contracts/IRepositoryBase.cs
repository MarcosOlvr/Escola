namespace Escola.Repositories.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity Get(int id);
        void Delete(int id);
        void Add(TEntity obj);
        void Update(TEntity obj);
    }
}
