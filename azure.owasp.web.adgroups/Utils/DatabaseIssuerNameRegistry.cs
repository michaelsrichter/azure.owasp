using System.IdentityModel.Tokens;
using System.Linq;
using azure.owasp.web.adgroups.Models;

namespace azure.owasp.web.adgroups.Utils
{
    public class DatabaseIssuerNameRegistry : ValidatingIssuerNameRegistry
    {
        public static bool ContainsTenant(string tenantId)
        {
            using (var context = new TenantDbContext())
            {
                return context.Tenants
                    .Where(tenant => tenant.Id == tenantId)
                    .Any();
            }
        }

        public static bool ContainsKey(string thumbprint)
        {
            using (var context = new TenantDbContext())
            {
                return context.IssuingAuthorityKeys
                    .Where(key => key.Id == thumbprint)
                    .Any();
            }
        }

        public static void RefreshKeys(string metadataLocation)
        {
            var issuingAuthority = GetIssuingAuthority(metadataLocation);

            var newKeys = false;
            var refreshTenant = false;
            if (issuingAuthority.Thumbprints.Any(thumbprint => !ContainsKey(thumbprint)))
            {
                newKeys = true;
                refreshTenant = true;
            }

            if (issuingAuthority.Issuers.Any(issuer => !ContainsTenant(GetIssuerId(issuer))))
            {
                refreshTenant = true;
            }

            if (!newKeys && !refreshTenant) return;
            using (var context = new TenantDbContext())
            {
                if (newKeys)
                {
                    context.IssuingAuthorityKeys.RemoveRange(context.IssuingAuthorityKeys);
                    foreach (var thumbprint in issuingAuthority.Thumbprints)
                    {
                        context.IssuingAuthorityKeys.Add(new IssuingAuthorityKey {Id = thumbprint});
                    }
                }

                if (refreshTenant)
                {
                    foreach (var issuer in issuingAuthority.Issuers)
                    {
                        var issuerId = GetIssuerId(issuer);
                        if (!ContainsTenant(issuerId))
                        {
                            context.Tenants.Add(new Tenant {Id = issuerId});
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        private static string GetIssuerId(string issuer)
        {
            return issuer.TrimEnd('/').Split('/').Last();
        }

        protected override bool IsThumbprintValid(string thumbprint, string issuer)
        {
            return ContainsTenant(GetIssuerId(issuer))
                   && ContainsKey(thumbprint);
        }
    }
}