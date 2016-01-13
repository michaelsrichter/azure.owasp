using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace azure.owasp.web.adgroups.Models
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext()
            : base("ad")
        {
        }

        public DbSet<IssuingAuthorityKey> IssuingAuthorityKeys { get; set; }

        public DbSet<Tenant> Tenants { get; set; }
    }

    public class IssuingAuthorityKey
    {
        public string Id { get; set; }
    }

    public class Tenant
    {
        public string Id { get; set; }
    }
}