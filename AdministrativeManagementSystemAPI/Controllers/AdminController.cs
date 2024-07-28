using AdministrativeManagementSystem;
using AdministrativeManagementSystemModels;
using AdministrativeManagementSystemServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AdministrativeManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        AccountGetServices _accountGetServices;
        AccountRecordServices _accountRecordServices;

        public AdminController()
        {
            _accountGetServices = new AccountGetServices();
            _accountRecordServices = new AccountRecordServices();
        }

        [HttpGet]
        public IEnumerable<Account> GetUsers()
        {
            var account = _accountGetServices.GetAllUsers();
            List<Account> accounts = new List<Account>();

            foreach (var Accounts in account)
            {
                accounts.Add(new AdministrativeManagementSystemAPI.Account { email = Accounts.email, username = Accounts.username, password = Accounts.password, userID = Accounts.userID, contactnumber = Accounts.contactnumber });
            }
            return accounts;
        }

        [HttpPost]
        public JsonResult AddUser(Account identity)
        {
            var result = _accountRecordServices.CreateUser(identity.email, identity.username, identity.password, identity.userID, identity.contactnumber);
            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUser(Account identity)
        {
            var result = _accountRecordServices.UpdateUser(identity.email, identity.username, identity.password, identity.userID, identity.contactnumber);
            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteUser(Account identity)
        {
            var deleteuserID = new AdministrativeManagementSystemModels.Account
            {
                userID = identity.userID
            };

            var result = _accountRecordServices.DeleteUser(deleteuserID);
            return new JsonResult(result);
        }
    }
}
