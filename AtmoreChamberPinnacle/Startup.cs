using AtmoreChamberPinnacle.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtmoreChamberPinnacle.Startup))]
namespace AtmoreChamberPinnacle
{

    
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }


            if (UserManager.Find("director@atmorechamber.com", "Testpassword1!") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "director@atmorechamber.com";
                user.Email = "director@atmorechamber.com";
                string userPWD = "Testpassword1!";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }


            if (!roleManager.RoleExists("Member"))
            {
                var role = new IdentityRole();
                role.Name = "Member";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Visitor"))
            {
                var role = new IdentityRole();
                role.Name = "Visitor";
                roleManager.Create(role);
            }
        }
    }
}







    //public partial class Startup
    //{


    //    public void Configuration(IAppBuilder app)
    //    {
    //        ConfigureAuth(app);
    //        createRolesandUsers();
    //    }


    //    // create default User roles and Admin user for login  
    //    private void createRolesandUsers()
    //    {
    //        ApplicationDbContext context = new ApplicationDbContext();

    //        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
    //        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


    //        // creating first Admin Role and creating a default Admin User   
    //        if (!roleManager.RoleExists("Admin"))
    //        {
    //            roleManager.Create(new IdentityRole { Name = "Admin" });
    //            var admin = new ApplicationUser { Email = "director@atmorechamber.com", UserName = "director@atmorechamber.com" };
    //            string password = "Testpassword1!";

    //            var result = UserManager.Create(admin, password);
    //            if (result.Succeeded)
    //            {
    //                UserManager.AddToRole(admin.Id, "Admin");
    //            }
    //        }

    //        // Creating Member role   
    //        if (!roleManager.RoleExists("Member"))
    //        {
    //            var role = new IdentityRole();
    //            role.Name = "Member";
    //            roleManager.Create(role);

    //        }

    //        // Creating Visitor role   
    //        if (!roleManager.RoleExists("Visitor"))
    //        {
    //            var role = new IdentityRole();
    //            role.Name = "Visitor";
    //            roleManager.Create(role);

    //        }
    //    }
    //}

