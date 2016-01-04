using System;
using System.IdentityModel.Services;
using System.Web.Mvc;

namespace azure.owasp.web.adgroups.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignOut()
        {
            var config = FederatedAuthentication.FederationConfiguration.WsFederationConfiguration;

            // Redirect to SignOutCallback after signing out.
            var callbackUrl = Url.Action("SignOutCallback", "Account", null, Request.Url.Scheme);
            var signoutMessage = new SignOutRequestMessage(new Uri(config.Issuer), callbackUrl);
            signoutMessage.SetParameter("wtrealm", IdentityConfig.Realm ?? config.Realm);
            FederatedAuthentication.SessionAuthenticationModule.SignOut();

            return new RedirectResult(signoutMessage.WriteQueryString());
        }

        public ActionResult SignOutCallback()
        {
            if (Request.IsAuthenticated)
            {
                // Redirect to home page if the user is authenticated.
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}