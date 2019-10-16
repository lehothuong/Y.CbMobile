using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CbMobile.Domain.Models
{
    public static class BaseRepository 
    {
        public static IQueryable<T> GetNotDeleted<T>(this DbSet<T> models) where T : BaseEntity
        {
            return models.Where(p => p.Deleted == false);
        }

        public static IEnumerable<T> GetNotDeleted<T>(this IEnumerable<T> models) where T : BaseEntity
        {
            return models.Where(p => p.Deleted == false);
        }

        public static IQueryable<T> GetPublished<T>(this DbSet<T> models) where T : BaseEntity
        {
            return models.Where(p => p.Deleted == false && p.Published);
        }

        public static IEnumerable<T> GetPublished<T>(this IEnumerable<T> models) where T : BaseEntity
        {
            return models.Where(p => p.Deleted == false && p.Published);
        }
    }
}
