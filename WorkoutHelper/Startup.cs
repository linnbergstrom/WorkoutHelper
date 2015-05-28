using Microsoft.Owin;
using Owin;
using WorkoutHelper;

[assembly: OwinStartup(typeof(Startup))]
namespace WorkoutHelper
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
