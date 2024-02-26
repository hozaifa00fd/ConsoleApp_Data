using ConsoleApp.Contexts;
using ConsoleApp.Entities;
using ConsoleApp.Repositories;

internal class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}


