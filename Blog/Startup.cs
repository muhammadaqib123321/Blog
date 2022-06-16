using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blog.Startup))]
namespace Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));



            if (!roleManager.RoleExists("PowerShell"))
            {
                //----------Same Roles full power------
                var role = new IdentityRole();
                role.Name = "PowerShell";
                roleManager.Create(role);
                //-------------------------------------

                //------admin with limited access------
                var role2 = new IdentityRole();
                role2.Name = "Admin";
                roleManager.Create(role2);

                //----------------create powershell user----------------------



                var user = new ApplicationUser();
                user.Email = "1@powerShell.com";
                user.UserName = user.Email;
                string userPWD = "123456789";
                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "PowerShell");
                }

                var user1 = new ApplicationUser();
                user1.Email = "admin@hms.com";
                user1.UserName = user1.Email;
                string user1PWD = "Pakistan@123";
                var chkUser1 = UserManager.Create(user1, user1PWD);
                if (chkUser1.Succeeded)
                {
                    var result = UserManager.AddToRole(user1.Id, "Admin");
                }
            }
        }
    }
}
