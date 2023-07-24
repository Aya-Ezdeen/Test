using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Test.web.Data;
using Test.web.Models;
using Test.web.ViewModel;

namespace Test.web.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<User> _UserManger;
        private RoleManager<IdentityRole> _UserRoles;
        public UserController(ApplicationDbContext db, UserManager<User> UserManger, RoleManager<IdentityRole> UserRoles)
        {
            _db = db;
            _UserManger = UserManger;
            _UserRoles = UserRoles;

        }

        public IActionResult Index()
        {
            var users = _db.Users.Where(x => !x.IsDelete).Select(x => new UserViewModel()
            {
          
                UserName = x.UserName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
               
            }).ToList();

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel input)
        {
            if (ModelState.IsValid)
            {
                //save in db
                var user = new User();
               
                user.Email = input.Email;
                user.PhoneNumber = input.Phone;
                user.UserName = input.UserName;

                IdentityResult result = await _UserManger.CreateAsync(user, input.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");

            
            }

            return View(input);
        }

    }
}
