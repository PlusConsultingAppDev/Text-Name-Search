using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using FindEmployee.Models;
using FindEmployee.Data;

namespace FindEmployee.Controllers
{
    public class EmpDataController : ApiController
    {
        private ApplicationUserManager _userManager;

        public EmpDataController()
        {
        }

        public EmpDataController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/EmpData
        public List<GetEmpoyeeModel> Get()
        {
            return EmpSampleData.GetEmployeesList();
        }

    }
}