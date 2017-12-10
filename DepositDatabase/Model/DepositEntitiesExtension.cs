﻿using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DepositDatabase.Model
{
    public static class DepositDbContextExtension
    {
        public static bool HasUnsavedChanges(this DepositDbContext dbContext)
        {
            return dbContext.ChangeTracker.Entries().Any(e => e.State == EntityState.Added
                                           || e.State == EntityState.Modified
                                           || e.State == EntityState.Deleted);
        }
        
        public static DepositDbContext GetInstance()
        {
            var instance = (DepositDbContext) HttpContext.Current.Items[typeof (DepositDbContext)];
            if (instance == null)
            {
                instance = new DepositDbContext();
                HttpContext.Current.Items[typeof (DepositDbContext)] = instance;
                HttpContext.Current.AddOnRequestCompleted(OnRequestCompleted);
            }
            return instance;
        }

        private static void OnRequestCompleted(HttpContext context)
        {
            var instance = (DepositDbContext)HttpContext.Current.Items[typeof(DepositDbContext)];
            if (instance != null)
            {
                if (instance.HasUnsavedChanges()) instance.SaveChanges();
                instance.Dispose();
            }
        }
    }
}
