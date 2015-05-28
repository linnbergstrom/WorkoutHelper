using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Postal;
using WorkoutHelper.Domain.Data;
using WorkoutHelper.Domain.Models;

namespace WorkoutHelper.Domain.Services
{
	public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
	{
		public class EmailService : IIdentityMessageService
		{
			public Task SendAsync(IdentityMessage message)
			{
				// Plug in your email service here to send an email.
				//return Task.FromResult(0);
				//var mailFrom = Convert.ToString(ConfigurationManager.AppSettings["FromMailAdress"]);
				return Task.Run(() =>
				{
					dynamic email = new Email("RegEmail");

					email.Subject = message.Subject;
					email.Link = message.Body;
					email.To = message.Destination;
					//email.Sender = mailFrom;
					email.Send();
				});
			}
		}

		public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
			: base(userManager, authenticationManager)
		{
		}

		public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
		{
			return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
		}

		public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
		{
			return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
		}
	}

	// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
	public class ApplicationUserManager : UserManager<ApplicationUser>
	{
		public ApplicationUserManager(IUserStore<ApplicationUser> store)
			: base(store)
		{ }

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
		{
			//var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
			var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<WorkoutHelperContext>()));
			manager.UserValidator = new UserValidator<ApplicationUser>(manager)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};

			manager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 4,
				RequireNonLetterOrDigit = false,
				RequireDigit = false,
				RequireLowercase = false,
				RequireUppercase = false,
			};

			// Configure user lockout defaults
			manager.UserLockoutEnabledByDefault = false;

			manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
			{
				Subject = "Security Code",
				BodyFormat = "Your security code is {0}"
			});
			manager.EmailService = new ApplicationSignInManager.EmailService();
			//manager.SmsService = new SmsService();
			var dataProtectionProvider = options.DataProtectionProvider;
			if (dataProtectionProvider != null)
			{
				manager.UserTokenProvider =
					new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
			}
			return manager;
		}
	}
}