
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShootingRangeManagementApp.Core.UnitOfWork;
using ShootingRangeManagementApp.Dtos.UserDtos;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Web.Controllers
{
    // Antiforgery token koyunca http 400 error veriyo çöz
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly StoreContext _storeContext;
        private readonly UnitOfWork _unitOfWork;



        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, StoreContext storeContext, UnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _storeContext = storeContext;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View(new UserCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto userCreateDto)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Email = userCreateDto.Email,
                    UserName = userCreateDto.Username,

                };


                var identityResult = await _userManager.CreateAsync(user, userCreateDto.Password);
                if (identityResult.Succeeded)
                {
                    var memberRole = await _roleManager.FindByNameAsync("Member");
                    if (memberRole == null)
                    {
                        await _roleManager.CreateAsync(new()
                        {
                            Name = "Member"
                        });
                    }

                    await _userManager.AddToRoleAsync(user, "Member");

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(userCreateDto);
        }
        public IActionResult SignIn()
        {
            return View(new UserLoginDto());
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(userLoginDto.Username);
                var signInResult = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, userLoginDto.RememberMe, true);
                if (signInResult.Succeeded)
                {

                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if(roles.Contains("Member"))
                    {
                        var storeId = user.StoreId;
                        return RedirectToAction("Index", "Store", new { @id = storeId }); // Buraya Store ID EKLENECEK STORE ID ADMİN TARAFINDAN VERİLECEK
                    }
                    else if (roles.Contains("LocaleAdmin"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    //giriş başarılı
                }
                else if (signInResult.IsNotAllowed)
                {
                    // isNotAllowed yollayıp store id girene kadar giriş yapmayı engellemeyi yap   // AppUsera Store ilişkisi verip is null durumuna göre is not allowed durumuna düşür.
                }
                else if (signInResult.IsLockedOut)
                {
                    var lockOutEnd = await _userManager.GetLockoutEndDateAsync(user);

                    ModelState.AddModelError("", $"Too many incorrect password entries.Your account has been temporarily locked.Account will be opened in {(lockOutEnd.Value.UtcDateTime - DateTime.UtcNow).Minutes} minutes.");
                }
                else
                {
                    var message = string.Empty;

                    if (user != null)
                    {
                        var failedCount = await _userManager.GetAccessFailedCountAsync(user);
                        message = $"{(_userManager.Options.Lockout.MaxFailedAccessAttempts - failedCount)} attempts left.";
                    }
                    else
                    {
                        message = "User entered wrong username or password.";
                    }
                    ModelState.AddModelError("", message);
                }

            }


            return View(userLoginDto);
        }
        [Authorize]
        public IActionResult GetUserInfo()
        {
            var userName = User.Identity.Name;
            var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;


            // cshtmlde adminin görmesi gereken yerler  @if(User!null && User.IsInRole("Admin")) if bloğu içine divleri koy
            return View();
        }
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "User");
        }
        public IActionResult UserListDataTable()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            //var query = _userManager.Users;
            //var users = _storeContext.Users.Join(_storeContext.UserRoles, user => user.Id, userRole => userRole.UserId, (user, userRole) => new
            //{
            //    user,
            //    userRole
            //}).Join(_storeContext.Roles, two => two.userRole.RoleId, role => role.Id, (two, role) => new { two.user, two.userRole, role }).Where(x => x.role.Name != "Admin").Select(x => new AppUser
            //{
            //    Id = x.user.Id,
            //    AccessFailedCount = x.user.AccessFailedCount,
            //    ConcurrencyStamp = x.user.ConcurrencyStamp,
            //    Email = x.user.Email,
            //    EmailConfirmed = x.user.EmailConfirmed,
            //    LockoutEnabled = x.user.LockoutEnabled,
            //    LockoutEnd = x.user.LockoutEnd,
            //    NormalizedEmail = x.user.NormalizedEmail,
            //    NormalizedUserName = x.user.NormalizedUserName,
            //    PasswordHash = x.user.PasswordHash,
            //    UserName = x.user.UserName,

            //}).ToList();

            //var users = await _userManager.GetUsersInRoleAsync("Member");
            //return View(users);
            List<AppUser> filteredUsers = new List<AppUser>();
            var users = _userManager.Users.ToList();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (!roles.Contains("Admin")&&!roles.Contains("LocaleAdmin"))
                {
                    filteredUsers.Add(user);
                }
            }
            return View(filteredUsers);
        }

        public async Task<IActionResult> LocaleAdminList()
        {
            
            List<AppUser> filteredUsers = new List<AppUser>();
            var users = _userManager.Users.ToList();
            
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("LocaleAdmin"))
                {
                    filteredUsers.Add(user);
                }
            }
            return View(filteredUsers);
        }

        public IActionResult CreateUser()
        {
            return View(new UserAdminCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserAdminCreateDto userAdminCreateDto)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = userAdminCreateDto.Email,
                    UserName = userAdminCreateDto.Username,
                };
                var result =
                await _userManager.CreateAsync(user, userAdminCreateDto.Username);
                if (result.Succeeded)
                {
                    var memberRole = await _roleManager.FindByNameAsync("Member");
                    if (memberRole == null)
                    {
                        await _roleManager.CreateAsync(new()
                        {
                            Name = "Member"
                        });
                    }

                    await _userManager.AddToRoleAsync(user, "Member");


                    return RedirectToAction("UserList", "User");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(userAdminCreateDto);
        }
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id == id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();
            RoleAssignSendDto roleAssignSendDto = new RoleAssignSendDto();
            List<RoleAssignListDto> list = new List<RoleAssignListDto>();
            foreach (var role in roles)
            {
                list.Add(new()
                {
                    Name = role.Name,
                    RoleId = role.Id,
                    Exist = userRoles.Contains(role.Name)
                });
            }
            roleAssignSendDto.Roles = list;
            roleAssignSendDto.UserId = id;
            return View(roleAssignSendDto);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(RoleAssignSendDto roleAssignSendDto)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id == roleAssignSendDto.UserId);

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in roleAssignSendDto.Roles)
            {
                if (role.Exist)
                {
                    if (!userRoles.Contains(role.Name))
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                }
                else
                {
                    if (userRoles.Contains(role.Name))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                }
            }
            return RedirectToAction("UserList", "User");
        }
        public IActionResult AssignStoretoLocaleAdmin(int id)
        {

            var user = _userManager.Users.SingleOrDefault(x => x.Id == id);

            //var userStoress = _userManager.Users.Include(o => o.AppUserStores).FirstOrDefault(x => x.AppUserStores.Contains() == id);
            var UserWithStores = _userManager.Users.Where(z => z.Id == id).Include(o => o.AppUserStores).ToList();
            var UserStores = UserWithStores.Select(o => o.AppUserStores.Select(o => o.StoreId));
            var StoreRepository = _unitOfWork.StoreRepository;

            var storelist = StoreRepository.GetStores();

            //List<int> ids = null;
            List<int> ids = new List<int>();

            if (storelist != null)
            {

                //ids = user.Stores.Where(o => storelist.Any(f => f.StoreId == o.StoreId)).Select(o => o.StoreId).ToList();
                //ids = UserStores.Select(o => (int)o.Select(f=>f.StoreId)).ToList();
                ids = UserStores.FirstOrDefault().ToList();

            }
            else
            {
                //var store=StoreRepository.GetStore(1);
                //ids.Add(store.StoreId);

                //ids = storelist.Select(o => o.StoreId).ToList();
                ids.Clear();

            }
            //var ids = user.Stores.Where(o => storelist.Any(f => f.StoreId == o.StoreId)).Select(o => o.StoreId);
            //var userStores = StoreRepository.GetStoresWithFilterMultiple(ids.ToList());
            AdminStoreAssignSendDto adminStoreAssignSendDto = new AdminStoreAssignSendDto();
            List<AdminStoreAssignListDto> list = new List<AdminStoreAssignListDto>();


            foreach (var store in storelist)
            {
                list.Add(new()
                {
                    StoreName = store.StoreName,
                    StoreId = store.StoreId,
                    //Exist = user.Stores.Any(o => o.StoreId == store.StoreId)
                    //Exist = userStores.Any(o => o.StoreId == store.StoreId),
                    Exist = ids.Contains(store.StoreId),

                });
            }
            adminStoreAssignSendDto.adminStores = list;
            adminStoreAssignSendDto.UserId = id;
            return View(adminStoreAssignSendDto);
        }
        [HttpPost]
        public async Task<IActionResult> AssignStoretoLocaleAdmin(AdminStoreAssignSendDto adminStoreAssignSendDto)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id == adminStoreAssignSendDto.UserId);

            var UserWithStores = _userManager.Users.Where(z => z.Id == adminStoreAssignSendDto.UserId).Include(o => o.AppUserStores).ToList();
            //var UserStores = UserWithStores.Select(o => o.Stores);
            var UserRepository = _unitOfWork.UserRepository;
            var storelist = UserWithStores.Select(o => o.AppUserStores.Select(f => f.StoreId)).ToList();
            var storeRepository = _unitOfWork.StoreRepository;
            var stores = storeRepository.GetStores().ToList();
            var foreachstore = adminStoreAssignSendDto.adminStores.Where(x => x.Exist == true).ToList();
            user.AppUserStores.Clear();
            //if (adminStoreAssignSendDto.adminStores.Any(o => o.Exist == true))
            //{
                foreach (var item in foreachstore)
                {


                    user.AppUserStores.Add(new AppUserStore
                    {
                        StoreId = item.StoreId,



                    });
                }


            
            _unitOfWork.Complete();

            return RedirectToAction("UserList", "User");

        }
        public async Task<IActionResult> AssignStore(int id)
        {
            ViewData["Id"] = id;
            var StoreRepository = _unitOfWork.StoreRepository;
            var storelist = StoreRepository.GetStores();
            SelectList stores = new SelectList(StoreRepository.GetStores().ToList(), "StoreId", "StoreName");

            return View(stores);

            //List<StoreListDto> stores = new List<StoreListDto>();
            //stores = storelist;
            //return View(new SelectList(stores, "StoreId", "Store"));

        }
        [HttpPost]
        public IActionResult AssignStore(StoreListDto storeListDto)
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id == storeListDto.UserId);
            user.StoreId = storeListDto.StoreId;
            _unitOfWork.Complete();
            //userdan gelen Idyle getuserby ıd diyip usera store ıd ata.
            return RedirectToAction("UserList", "User");
        }
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (ModelState.IsValid)
            {
                
                var user = await _userManager.FindByIdAsync(id.ToString());
               
                var rolesForUser = await _userManager.GetRolesAsync(user);

                using (var transaction = _storeContext.Database.BeginTransaction())
                {
                    

                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await _userManager.RemoveFromRoleAsync(user, item);
                        }
                    }

                    await _userManager.DeleteAsync(user);
                    _unitOfWork.Complete();
                    transaction.Commit();
                }

                return RedirectToAction("UserList", "User");
            }
            else
            {
                return RedirectToAction("UserList", "User");
            }
        }
        public async Task<ActionResult> ChangePassword(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> AssignStore(int storeId,string store)
        //{
        //    Bag.Message = "Fruit Name: " + fruitName;
        //    ViewBag.Message += "\\nFruit Id: " + fruitId;
        //    return View();

        //}
        //public async Task<IActionResult> AssignStore(int id)
        //{
        //    var StoreRepository = _unitOfWork.StoreRepository;
        //    var user = _userManager.Users.SingleOrDefault(x => x.Id == id);

        //    var stores = StoreRepository.GetStores();
        //    StoreAssignSendDto storeAssignSendDto = new StoreAssignSendDto();
        //    List<StoreAssignListDto> list = new List<StoreAssignListDto>();
        //    foreach (var store in stores)
        //    {
        //        list.Add(new()
        //        {
        //            StoreName = store.StoreName,
        //            StoreId = store.StoreId,
        //            //Exist=user.Store.Equals(store.StoreId)

        //        });
        //    }
        //    storeAssignSendDto.Store = list;
        //    storeAssignSendDto.UserId = id;
        //    return View(storeAssignSendDto);
        //}
        //[HttpPost]
        //public async Task<IActionResult> AssignStore(StoreAssignSendDto storeAssignSendDto)
        //{
        //    var StoreRepository = _unitOfWork.StoreRepository;
        //    var stores = StoreRepository.GetStores();


        //    var user = _userManager.Users.SingleOrDefault(x => x.Id == storeAssignSendDto.UserId);

        //    //var userRoles = await _userManager.GetRolesAsync(user);


        //    user.StoreId = storeAssignSendDto.StoreId;
        //    //foreach (var store in storeAssignSendDto.Store)
        //    //{
        //    //    if (store.Exist)
        //    //    {
        //    //        if (!stores.Contains(store.StoreName))
        //    //        {
        //    //            await _userManager.AddToRoleAsync(user, role.Name);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        if (userRoles.Contains(role.Name))
        //    //        {
        //    //            await _userManager.RemoveFromRoleAsync(user, role.Name);
        //    //        }
        //    //    }
        //    //}
        //    return RedirectToAction("UserList", "User");
        //}


        public async Task<IActionResult> ResetPassword()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPasword(UserPasswordResetDto userPasswordResetDto)
        {
            var user =await _userManager.FindByNameAsync(User.Identity.Name);
           
            if (ModelState.IsValid)
            {
                //_userManager.ChangePasswordAsync(user, userPasswordResetDto.OldPassword, userPasswordResetDto.Password);
                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, userPasswordResetDto.OldPassword, userPasswordResetDto.Password);
                    if (result.Succeeded)
                    {
                        return View("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(userPasswordResetDto);
                }
                return View("ResetPasswordConfirmation");
            }
            return View(userPasswordResetDto);

        }

    }
}