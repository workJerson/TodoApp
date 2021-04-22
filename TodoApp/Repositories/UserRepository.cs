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
                .Include(u => u.UserDetail)
                .Include(u => u.AddressDetails)
                    .ThenInclude(a => a.Country)
                .Include(u => u.ContactDetails)
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Guid == Guid);

           //var resultLinq = await (from u in context.Users
           //                 join d in context.UserDetails on u.UserId equals d.UserId
           //                 join a in context.AddressDetails on u.UserId equals a.Userid into addressList
           //                 from ad in addressList.DefaultIfEmpty()
           //                 join c in context.ContactDetails on u.UserId equals c.UserId into contactList
           //                 from cd in contactList.DefaultIfEmpty()
           //                 select new {
           //                     u.Guid,
           //                     u.LoginAttempts,
           //                     u.Status,
           //                     u.CreatedAt,
           //                     u.CreatedBy,
           //                     u.UpdatedAt,
           //                     u.UpdatedBy,
           //                     UserDetail = new  {
           //                         d.FirstName,
           //                         d.LastName,
           //                         d.MiddleName,
           //                         d.Gender,
           //                         d.Occupation,
           //                         d.Nationality
           //                     },
           //                     AddressDetails = (from ad in u.AddressDetails
           //                                       join c in context.Countries on ad.CountryId equals c.CountryId
           //                                       select new { 
           //                                           ad.Street,
           //                                           ad.City,
           //                                           ad.Province,
           //                                           ad.Postal,
           //                                           Country = new
           //                                           {
           //                                               c.CountryCode,
           //                                               c.Name,
           //                                               c.CurrencyCode
           //                                           }
           //                                       }).ToList(),
           //                     ContactDetails = (from cds in u.ContactDetails select cds).ToList()
           //                 }).FirstOrDefaultAsync(u => u.Guid == Guid);

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
                result.Username = modelObject.Username;
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
