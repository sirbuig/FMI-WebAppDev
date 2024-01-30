using Lab4_24.Models;
using Lab4_24.Models.Base;

namespace Lab4_24.Helpers.Extensions;

public static class OnlyActive
{
    public static IQueryable<User> GetActiveUser(this IQueryable<User> query)
    {
        return query.Where(x => !x.IsDeleted);
    }
}