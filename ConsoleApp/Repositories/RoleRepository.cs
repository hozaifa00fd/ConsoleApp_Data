using ConsoleApp.Contexts;
using ConsoleApp.Entities;
using ConsoleApp.Repositories;

internal class RoleRepository : Repo<RoleEntity>
{
    public RoleRepository(DataContext context) : base(context)
    {
    }
}


