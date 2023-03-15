using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace fatec_csharp.source.data
{
    public class DataContext
    {
        // Para evitar o erro CS0246, adicione a referência System.Data.Entity
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Name is intentional")]
        public class DbSet<TEntity> : System.Data.Entity.Infrastructure.DbQuery<TEntity>, System.Collections.Generic.IEnumerable<TEntity>, System.Data.Entity.IDbSet<TEntity>, System.Linq.IQueryable<TEntity> where TEntity : class

        public DbSet<TEntity> Usuarios { get; set; }
    }

}

