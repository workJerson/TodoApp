using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Context
{
    public interface ITodoAppContext
    {
       DbSet<AddressDetail> AddressDetails { get; set; }
       DbSet<ContactDetail> ContactDetails { get; set; }
       DbSet<Country> Countries { get; set; }
       DbSet<User> Users { get; set; }
       DbSet<UserDetail> UserDetails { get; set; }
       Task<int> SaveChangesAsync();
       Task<IDbContextTransaction> Transaction();

    }

    public partial class TodoAppContext : ITodoAppContext
    {
        public Task<int> SaveChangesAsync()
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync();
        }

        public Task<IDbContextTransaction> Transaction()
        {
            return base.Database.BeginTransactionAsync();
        }
        private void UpdateAuditEntities(Type[] types = null, string username = null)
        {
            // https://medium.com/@unhandlederror/deleting-it-softly-with-ef-core-5f191db5cf72
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

            foreach (var entry in modifiedEntries)
            {
                dynamic entity = entry.Entity;

                var now = DateTime.UtcNow;
                if (entry.State != EntityState.Deleted)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = now;
                        entity.CreatedBy = username;
                    }

                    entity.UpdatedAt = now;
                    entity.UpdatedBy = username;
                }
                else
                {
                    // if you want to hard delete entities
                    if (types != null)
                    {
                        var type = entry.Entity.GetType();
                        if (types.Contains(type))
                            continue;
                    }
                    // if deleted state, change to Modified
                    //entry.State = EntityState.Modified;
                    //entity.IsDeleted = true;
                    //entity.DeletedOn = now;
                    //entity.DeletedBy = username;
                }
            }
        }
    }
}
