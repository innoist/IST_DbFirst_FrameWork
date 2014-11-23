using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EPMS.Implementation.Identity;
using EPMS.Interfaces.IServices;
using EPMS.Models.DomainModels;
using EPMS.Models.IdentityModels;
using EPMS.Models.MenuModels;
using EPMS.WebBase.UnityConfiguration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Practices.Unity;

namespace EPMS.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Private

        private ApplicationUserManager _userManager;
        private IMenuRightsService menuRightService;

        #endregion

        #region Protected
        // GET: Base
        protected override async void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["FullName"] == null || Session["FullName"] == string.Empty)
                SetUserDetail();
        }

        #endregion

        #region Public

//when isForce =  true it sets the value, no matter session has or not
        public void SetUserDetail()
        {
            Session["FullName"] = Session["LoginID"] = string.Empty;
            if (User.Identity.IsAuthenticated)
            {
                AspNetUser result =
                    HttpContext.GetOwinContext()
                        .GetUserManager<ApplicationUserManager>()
                        .FindByEmail(User.Identity.Name);
                string role =
                    HttpContext.GetOwinContext()
                        .Get<ApplicationRoleManager>()
                        .FindById(result.AspNetRoles.ToList()[0].Id)
                        .Name;
                Session["FullName"] = result.FirstName + " " + result.LastName;
                Session["ProfileImage"] = result.ImageName;
                Session["LoginID"] = result.Id;
                Session["RoleName"] = role;

                menuRightService = UnityWebActivator.Container.Resolve<IMenuRightsService>();

                AspNetUser userResult = UserManager.FindByEmail(User.Identity.Name);
                List<AspNetRole> roles = userResult.AspNetRoles.ToList();
                IList<MenuRight> userRights =
                    menuRightService.FindMenuItemsByRoleId(roles[0].Id).ToList();

                string[] userPermissions = userRights.Select(user => user.Menu.PermissionKey).ToArray();
                Session["UserPermissionSet"] = userPermissions;
                return;
            }

        }



        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        #endregion

    }
}