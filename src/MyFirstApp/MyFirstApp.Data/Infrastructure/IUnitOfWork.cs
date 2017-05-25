namespace MyFirstApp.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}