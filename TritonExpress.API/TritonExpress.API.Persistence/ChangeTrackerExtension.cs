using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using TritonExpress.API.Domain.Entities.Base;

namespace TritonExpress.API.Persistence
{
    public static class ChangeTrackerExtensions
    {
        public static void SetAuditProperties(this ChangeTracker changeTracker, ICurrentUserService currentUserService)
        {
            changeTracker.DetectChanges();
            IEnumerable<EntityEntry> entities =
                changeTracker
                    .Entries()
                    .Where(t => t.Entity is IEntityBase &&
                    (
                        t.State == EntityState.Deleted
                        || t.State == EntityState.Added
                        || t.State == EntityState.Modified
                    ));

            if (entities.Any())
            {
                DateTimeOffset timestamp = DateTimeOffset.UtcNow;

                string user = currentUserService.GetCurrentUser().LoginName;

                foreach (EntityEntry entry in entities)
                {
                    IEntityBase entity = (IEntityBase)entry.Entity;

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedOn = timestamp;
                            entity.CreatedBy = user;
                            entity.UpdatedOn = timestamp;
                            entity.UpdatedBy = user;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedOn = timestamp;
                            entity.UpdatedBy = user;
                            break;

                    }
                }
            }
        }
    }
}