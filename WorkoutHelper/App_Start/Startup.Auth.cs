using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WorkoutHelper.Domain.Data;
using WorkoutHelper.Domain.Models;
using WorkoutHelper.Domain.Services;

namespace WorkoutHelper
{
	public partial class Startup
	{
		public void ConfigureAuth(IAppBuilder app)
		{
			// Configure the db context, user manager and signin manager to use a single instance per request
			//app.CreatePerOwinContext(ApplicationDbContext.Create);
			app.CreatePerOwinContext(WorkoutHelperContext.Create);
			app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
			app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

			// Configure the sign in cookie
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login"),
				Provider = new CookieAuthenticationProvider
				{
					// This is a security feature which is used when you change a password or add an external login to your account.  
					OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
						validateInterval: TimeSpan.FromMinutes(60),
						regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager)),
					OnException = context => { }
				}
			});
			app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

			// Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
			app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

			// Enables the application to remember the second login verification factor such as phone or email.
			// This is similar to the RememberMe option when you log in.
			app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

		}
	}
}