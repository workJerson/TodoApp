using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Context;
using TodoApp.Models;
using TodoApp.Utils.Common;

namespace TodoApp.Repositories
{
    public interface IUserRepository : IMaintainable<User>
    {

    }

    public class UserRepository : IUserRepository
    {
        private readonly ITodoAppContext context;

        public UserRepository(ITodoAppContext context)
        {
            this.context = context;
        }

        public async Task<(User, string[])> Create(User modelObject)
        {
            var transaction = await context.Transaction();
            try
            {
                context.Users.Add(modelObject);
                var result = await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return (modelObject, null);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return (null, new[] { "Error on creating user object. Data rollbacked"});
            }
        }

        public async Task<(List<User>, string[])> Create(List<User> modelObjects)
        {
            var transaction = await context.Transaction();

            try
            {
                await context.Users.AddRangeAsync(modelObjects);
                await transaction.CommitAsync();
                return (modelObjects, null);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (null, new[] { "Error on creating users. Data rollbacked", ex.GetBaseException().ToString()});
            }
        }

        public async Task<(int, string[])> Delete(Guid Guid)
        {
            var result = await context.Users
                .SingleOrDefaultAsync(u => u.Guid == Guid);

            if (result == null)
            {
                return (0, new[] { "Invalid user" });
            }

            var transaction = await context.Transaction();

            try
            {
                result.Status = "Deleted";
                int updateResult = await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return (updateResult, null);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return (0, new[] { "Error on deleting user object. Delete rollbacked" });
            }
        }

        public async Task<List<User>> List()
        {
            var result = await (from u in context.Users
                                where u.Status == "Active"
                          select u)
                          .AsNoTracking()
                          .ToListAsync();

            return result;
        }

        public async Task<(User, string[])> Show(Guid Guid)
        {
            var result = await context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Guid == Guid);

            return (result, null);
        }

        public async Task<(User, string[])> Update(User modelObject)
        {

            var result = await context.Users
                .SingleOrDefaultAsync(u => u.Guid == modelObject.Guid);

            if (result == null)
            {
                return (null, new[] { "Invalid user" });
            }

            var transaction = await context.Transaction();

            try
            {
                result.LoginAttempts = modelObject.LoginAttempts;
                result.Status = modelObject.Status;
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
                return (result, null);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return (null, new[] { "Error on creating user object. Update rollbacked" });
            }
        }
    }
}
