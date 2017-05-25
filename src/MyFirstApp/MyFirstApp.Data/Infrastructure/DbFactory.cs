namespace MyFirstApp.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private MyFirstAppContext dbContext;

        public MyFirstAppContext Init()
        {
            return dbContext ?? (dbContext = new MyFirstAppContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}