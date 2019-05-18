namespace DatabaseApp
{
    public interface IDataSeeder
    {
        void Seed(AppDbContext dbContext);
    }
}