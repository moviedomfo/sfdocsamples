using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

using System.Web.Mvc;
using System.Security.Claims;

namespace LocalAccountsApp.app_identity
{
    // Configure the application user manager used in this application. 
    //UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser, Guid>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, Guid> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            //var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));

            var manager = new ApplicationUserManager(new UserStore<ApplicationUser,
                                                ApplicationRole,
                                                Guid,
                                                ApplicationUserLogin,
                                                ApplicationUserRole,
                                                ApplicationUserClaim>
                                                (context.Get<ApplicationDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new CustomUserValidator(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser,Guid>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<ApplicationRole, Guid>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, Guid> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new ApplicationRoleStore(context.Get<ApplicationDbContext>()));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ApplicationGroupManager
    {
        private ApplicationGroupStore _groupStore;
        private ApplicationDbContext _db;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public ApplicationGroupManager()
        {
            _db = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();
            _userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            _roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            _groupStore = new ApplicationGroupStore(_db);
        }


        public IQueryable<ApplicationGroup> Groups
        {
            get
            {
                return _groupStore.Groups;
            }
        }


        public async Task<IdentityResult> CreateGroupAsync(ApplicationGroup group)
        {
            await _groupStore.CreateAsync(group);
            return IdentityResult.Success;
        }

        /// <summary>
        /// Crea  nuevo grupo
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public IdentityResult CreateGroup(ApplicationGroup group)
        {
            _groupStore.Create(group);
            return IdentityResult.Success;
        }

        /// <summary>
        /// Agrega roles a un grupo
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleNames"></param>
        /// <returns></returns>
        public IdentityResult SetGroupRoles(Guid groupId, params string[] roleNames)
        {
            // Clear all the roles associated with this group:
            var thisGroup = this.FindById(groupId);
            thisGroup.ApplicationRoles.Clear();
            _db.SaveChanges();

            // Add the new roles passed in:
            var newRoles = _roleManager.Roles.Where(r => roleNames.Any(n => n == r.Name));
            foreach (var role in newRoles)
            {
                thisGroup.ApplicationRoles.Add(new ApplicationGroupRole
                {
                    ApplicationGroupId = groupId,
                    ApplicationRoleId = role.Id
                });
            }
            _db.SaveChanges();

            // Reset the roles for all affected users:
            foreach (var groupUser in thisGroup.ApplicationUsers)
            {
                this.RefreshUserGroupRoles(groupUser.ApplicationUserId);
            }
            return IdentityResult.Success;
        }

        /// <summary>
        /// Agrega roles a un grupo asincronamente
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="roleNames"></param>
        /// <returns></returns>
        public async Task<IdentityResult> SetGroupRolesAsync(Guid groupId, params string[] roleNames)
        {
            var id = groupId;
            // Clear all the roles associated with this group:
            var thisGroup = await this.FindByIdAsync(id);
            thisGroup.ApplicationRoles.Clear();
            await _db.SaveChangesAsync();

            // Add the new roles passed in:
            var newRoles = _roleManager.Roles
                            .Where(r => roleNames.Any(n => n == r.Name));
            foreach (var role in newRoles)
            {
                thisGroup.ApplicationRoles.Add(new ApplicationGroupRole
                {
                    ApplicationGroupId = id,
                    ApplicationRoleId = role.Id
                });
            }
            await _db.SaveChangesAsync();

            // Reset the roles for all affected users:
            foreach (var groupUser in thisGroup.ApplicationUsers)
            {
                await this.RefreshUserGroupRolesAsync(groupUser.ApplicationUserId);
            }
            return IdentityResult.Success;
        }

        /// <summary>
        /// Esteblece grupos para un usuario (Async)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupIds"></param>
        /// <returns></returns>
        public async Task<IdentityResult> SetUserGroupsAsync(Guid userId, params Guid[] groupIds)
        {
            // Clear current group membership:
            var currentGroups = await this.GetUserGroupsAsync(userId);
            foreach (var group in currentGroups)
            {
                group.ApplicationUsers
                    .Remove(group.ApplicationUsers
                    .FirstOrDefault(gr => gr.ApplicationUserId == userId
                ));
            }
            await _db.SaveChangesAsync();

            // Add the user to the new groups:
            foreach (Guid groupId in groupIds)
            {
                var newGroup = await this.FindByIdAsync(groupId);
                newGroup.ApplicationUsers.Add(new ApplicationUserGroup
                {
                    ApplicationUserId = userId,
                    ApplicationGroupId = groupId
                });
            }
            await _db.SaveChangesAsync();

            await this.RefreshUserGroupRolesAsync(userId);
            return IdentityResult.Success;
        }

        /// <summary>
        ///  Esteblece grupos para un usuario 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="groupIds"></param>
        /// <returns></returns>
        public IdentityResult SetUserGroups(Guid userId, params Guid[] groupIds)
        {
            // Clear current group membership:
            var currentGroups = this.GetUserGroups(userId);
            foreach (var group in currentGroups)
            {
                group.ApplicationUsers
                    .Remove(group.ApplicationUsers
                    .FirstOrDefault(gr => gr.ApplicationUserId == userId
                ));
            }
            _db.SaveChanges();

            // Add the user to the new groups:
            foreach (Guid groupId in groupIds)
            {
                var newGroup = this.FindById(groupId);
                newGroup.ApplicationUsers.Add(new ApplicationUserGroup
                {
                    ApplicationUserId = userId,
                    ApplicationGroupId = groupId
                });
            }
            _db.SaveChanges();

            this.RefreshUserGroupRoles(userId);
            return IdentityResult.Success;
        }

        /// <summary>
        /// Elimina los roles del usuario
        /// Obtienen los group-roles del usuario
        /// Obtiene los rolesName[] y los agrega al usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IdentityResult RefreshUserGroupRoles(Guid userId)
        {
            var user = _userManager.FindById(userId);
            if (user == null)
            {
                throw new ArgumentNullException("User");
            }
            // Remove user from previous roles:
            var oldUserRoles = _userManager.GetRoles(userId);
            if (oldUserRoles.Count > 0)
            {
                _userManager.RemoveFromRoles(userId, oldUserRoles.ToArray());
            }

            // Find the roles this user is entitled to from group membership:
            var newGroupRoles = this.GetUserGroupRoles(userId);


            #region Get the damn role names:
            var allRoles = _roleManager.Roles.ToList();
            var addTheseRoles = allRoles
                .Where(r => newGroupRoles.Any(gr => gr.ApplicationRoleId == r.Id
            ));
            var roleNames = addTheseRoles.Select(n => n.Name).ToArray();
            #endregion

            // Add the user to the proper roles
            _userManager.AddToRoles(userId, roleNames);

            return IdentityResult.Success;
        }


        public async Task<IdentityResult> RefreshUserGroupRolesAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentNullException("User");
            }
            // Remove user from previous roles:
            var oldUserRoles = await _userManager.GetRolesAsync(userId);
            if (oldUserRoles.Count > 0)
            {
                await _userManager.RemoveFromRolesAsync(userId, oldUserRoles.ToArray());
            }

            // Find the roles this user is entitled to from group membership:
            var newGroupRoles = await this.GetUserGroupRolesAsync(userId);

            // Get the damn role names:
            var allRoles = await _roleManager.Roles.ToListAsync();
            var addTheseRoles = allRoles
                .Where(r => newGroupRoles.Any(gr => gr.ApplicationRoleId == r.Id
            ));
            var roleNames = addTheseRoles.Select(n => n.Name).ToArray();

            // Add the user to the proper roles
            await _userManager.AddToRolesAsync(userId, roleNames);

            return IdentityResult.Success;
        }


        public async Task<IdentityResult> DeleteGroupAsync(Guid groupId)
        {
            var group = await this.FindByIdAsync(groupId);
            if (group == null)
            {
                throw new ArgumentNullException("User");
            }

            var currentGroupMembers = (await this.GetGroupUsersAsync(groupId)).ToList();
            // remove the roles from the group:
            group.ApplicationRoles.Clear();

            // Remove all the users:
            group.ApplicationUsers.Clear();

            // Remove the group itself:
            _db.ApplicationGroups.Remove(group);

            await _db.SaveChangesAsync();

            // Reset all the user roles:
            foreach (var user in currentGroupMembers)
            {
                await this.RefreshUserGroupRolesAsync(user.Id);
            }
            return IdentityResult.Success;
        }


        public IdentityResult DeleteGroup(Guid groupId)
        {
            var group = this.FindById(groupId);
            if (group == null)
            {
                throw new ArgumentNullException("User");
            }

            var currentGroupMembers = this.GetGroupUsers(groupId).ToList();
            // remove the roles from the group:
            group.ApplicationRoles.Clear();

            // Remove all the users:
            group.ApplicationUsers.Clear();

            // Remove the group itself:
            _db.ApplicationGroups.Remove(group);

            _db.SaveChanges();

            // Reset all the user roles:
            foreach (var user in currentGroupMembers)
            {
                this.RefreshUserGroupRoles(user.Id);
            }
            return IdentityResult.Success;
        }


        public async Task<IdentityResult> UpdateGroupAsync(ApplicationGroup group)
        {
            await _groupStore.UpdateAsync(group);
            foreach (var groupUser in group.ApplicationUsers)
            {
                await this.RefreshUserGroupRolesAsync(groupUser.ApplicationUserId);
            }
            return IdentityResult.Success;
        }


        public IdentityResult UpdateGroup(ApplicationGroup group)
        {
            _groupStore.Update(group);
            foreach (var groupUser in group.ApplicationUsers)
            {
                this.RefreshUserGroupRoles(groupUser.ApplicationUserId);
            }
            return IdentityResult.Success;
        }


        public IdentityResult ClearUserGroups(Guid userId)
        {
            return this.SetUserGroups(userId, new Guid[] { });
        }


        public async Task<IdentityResult> ClearUserGroupsAsync(Guid userId)
        {
            return await this.SetUserGroupsAsync(userId, new Guid[] { });
        }


        public async Task<IEnumerable<ApplicationGroup>> GetUserGroupsAsync(Guid userId)
        {
            var result = new List<ApplicationGroup>();
            var userGroups = (from g in this.Groups
                              where g.ApplicationUsers
                                .Any(u => u.ApplicationUserId == userId)
                              select g).ToListAsync();
            return await userGroups;
        }


        public IEnumerable<ApplicationGroup> GetUserGroups(Guid userId)
        {
            var result = new List<ApplicationGroup>();
            var userGroups = (from g in this.Groups
                              where g.ApplicationUsers
                                .Any(u => u.ApplicationUserId == userId)
                              select g).ToList();
            return userGroups;
        }


        public async Task<IEnumerable<ApplicationRole>> GetGroupRolesAsync(
            Guid groupId)
        {
            var grp = await _db.ApplicationGroups
                .FirstOrDefaultAsync(g => g.Id == groupId);
            var roles = await _roleManager.Roles.ToListAsync();
            var groupRoles = (from r in roles
                              where grp.ApplicationRoles
                                .Any(ap => ap.ApplicationRoleId == r.Id)
                              select r).ToList();
            return groupRoles;
        }


        public IEnumerable<ApplicationRole> GetGroupRoles(Guid groupId)
        {
            var grp = _db.ApplicationGroups.FirstOrDefault(g => g.Id == groupId);
            var roles = _roleManager.Roles.ToList();
            var groupRoles = from r in roles
                             where grp.ApplicationRoles
                                .Any(ap => ap.ApplicationRoleId == r.Id)
                             select r;
            return groupRoles;
        }


        public IEnumerable<ApplicationUser> GetGroupUsers(Guid groupId)
        {
            var group = this.FindById(groupId);
            var users = new List<ApplicationUser>();
            foreach (var groupUser in group.ApplicationUsers)
            {
                var user = _db.Users.Find(groupUser.ApplicationUserId);
                users.Add(user);
            }
            return users;
        }


        public async Task<IEnumerable<ApplicationUser>> GetGroupUsersAsync(Guid groupId)
        {
            var group = await this.FindByIdAsync(groupId);
            var users = new List<ApplicationUser>();
            foreach (var groupUser in group.ApplicationUsers)
            {
                var user = await _db.Users
                    .FirstOrDefaultAsync(u => u.Id == groupUser.ApplicationUserId);
                users.Add(user);
            }
            return users;
        }


        public IEnumerable<ApplicationGroupRole> GetUserGroupRoles(Guid userId)
        {
            var userGroups = this.GetUserGroups(userId);
            var userGroupRoles = new List<ApplicationGroupRole>();
            foreach (var group in userGroups)
            {
                userGroupRoles.AddRange(group.ApplicationRoles.ToArray());
            }
            return userGroupRoles;
        }


        public async Task<IEnumerable<ApplicationGroupRole>> GetUserGroupRolesAsync(
            Guid userId)
        {
            var userGroups = await this.GetUserGroupsAsync(userId);
            var userGroupRoles = new List<ApplicationGroupRole>();
            foreach (var group in userGroups)
            {
                userGroupRoles.AddRange(group.ApplicationRoles.ToArray());
            }
            return userGroupRoles;
        }


        public async Task<ApplicationGroup> FindByIdAsync(Guid id)
        {
            return await _groupStore.FindByIdAsync(id);
        }


        public ApplicationGroup FindById(Guid id)
        {
            return _groupStore.FindById(id);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Send:
            return securityHelper.SendMailAsynk(message.Subject, message.Body, String.Empty, message.Destination);
        }

        /// <summary>
        /// There are numerous email services available, but Sendgrid is a popular choice in the .NET community. 
        /// Sendgrid offers API support for multiple languages as well as an HTTP-based Web API. Additionally, Sendgrid offers direct integration with Windows Azure.
        /// 
        /// Create sendgrid accoun here: https://sendgrid.com/user/signup
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendAsync_(IdentityMessage message)
        {
            // Credentials:
            var sendGridUserName = "yourSendGridUserName";
            var sentFrom = "whateverEmailAdressYouWant";
            var sendGridPassword = "YourSendGridPassword";

            // Configure the client:
            var client = new System.Net.Mail.SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));

            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            // Creatte the credentials:
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(sendGridUserName, sendGridPassword);

            client.EnableSsl = true;
            client.Credentials = credentials;

            // Create the message:
            var mail = new System.Net.Mail.MailMessage(sentFrom, message.Destination);

            mail.Subject = message.Subject;
            mail.Body = message.Body;

            // Send:
            return client.SendMailAsync(mail);
        }

    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "sadmin";
            const string password = "admin21+";
            const string roleName = "SuperAdmin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            //We want to create the same default user, but then also create a default group. 
            //Then, we will create the default Admin role and assign it to the default group. Finally, we'll add the user to that group.
            var groupManager = new ApplicationGroupManager();
            var newGroup = new ApplicationGroup("SuperAdmins", "Full Access to All");

            groupManager.CreateGroup(newGroup);
            groupManager.SetUserGroups(user.Id, new Guid[] { newGroup.Id });
            groupManager.SetGroupRoles(newGroup.Id, new string[] { role.Name });

            //old code
            // Add user admin to Role Admin if not already added
            //var rolesForUser = userManager.GetRoles(user.Id);
            //if (!rolesForUser.Contains(role.Name)) {
            //    var result = userManager.AddToRole(user.Id, role.Name);
            //}
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, Guid>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
        public override Guid ConvertIdFromString(string id)
        {
            if (string.IsNullOrEmpty(id)) return Guid.Empty;

            return new Guid(id);
        }

        public override string ConvertIdToString(Guid id)
        {
            if (id.Equals(Guid.Empty)) return string.Empty;

            return id.ToString();
        }
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class LoggedOrAuthorizedAttribute : AuthorizeAttribute
    {
        private ApplicationDbContext ContextFactory { get; set; }
        public LoggedOrAuthorizedAttribute()
        {
            View = "error";
            Master = String.Empty;
        }

        public String View { get; set; }
        public String Master { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            CheckIfUserIsAuthenticated(filterContext);
        }

        private void CheckIfUserIsAuthenticated(AuthorizationContext filterContext)
        {
            var reol = Roles[0];
            // If Result is null, we’re OK: the user is authenticated and authorized. 
            if (filterContext.Result == null)
                return;
            if (AuthorizeCore(filterContext.HttpContext))
            {
                //SetCachePolicy(filterContext);
            }
            else if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // auth failed, redirect to login page
                filterContext.Result = new HttpUnauthorizedResult();
            }
            //else if (filterContext.HttpContext.User.IsInRole("SuperUser") || IsOwner(new CurrentRequest(filterContext, this.RouteParameter)))
            //{
            //    //SetCachePolicy(filterContext);
            //}
            else
            {

                //returnUrl
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                { "controller", "Account" },
                { "action", "Login" },
                 { "returnUrl", filterContext.HttpContext.Request.RawUrl }
                });
                filterContext.Controller.TempData["Message"] = "No posee suficientes privilegios para esta operacion. Debe iniciar sesion para poder ver esta pagina o relaizar esta acción";


            }
            // If here, you’re getting an HTTP 401 status code. In particular,
            // filterContext.Result is of HttpUnauthorizedResult type. Check Ajax here. 
            //if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    if (String.IsNullOrEmpty(View))
            //        return;
            //    filterContext.Result = new HttpUnauthorizedResult();

            //    var result = new ViewResult { ViewName = View, MasterName = Master };
            //    filterContext.Result = result;
            //}
        }

        //private bool IsOwner(CurrentRequest requestData)
        //{
        //    using (var dc = this.ContextFactory.GetDataContextWrapper())
        //    {
        //        return dc.Table<User>().Where(p => p.UserName == requestData.Username && p.UserID == requestData.OwnerID).Any();
        //    }
        //}
    }


}
