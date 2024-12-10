using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.AuthApp;

namespace PhoneBook.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserLogin()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.LoginProp,
                    model.Password,
                    false,
                    lockoutOnFailure: false);

                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "PhoneContact");
                }

                ModelState.AddModelError("", "Пользователь не найден");
            }

            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new UserRegistration());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "PhoneContact");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManageUsers()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("ManageUsers");
        }

        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                // Создаем нового пользователя
                var user = new User { UserName = model.LoginProp };
                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    // Проверяем, существует ли роль в базе
                    var roleExist = await _roleManager.RoleExistsAsync(model.Role);
                    if (!roleExist)
                    {
                        // Если роль не существует, создаем ее
                        var roleResult = await _roleManager.CreateAsync(new IdentityRole(model.Role));
                        if (!roleResult.Succeeded)
                        {
                            // Обработка ошибок при создании роли
                            foreach (var identityError in roleResult.Errors)
                            {
                                ModelState.AddModelError("", identityError.Description);
                            }
                            return View(model);
                        }
                    }

                    // Назначаем пользователю выбранную роль
                    var roleAssignResult = await _userManager.AddToRoleAsync(user, model.Role);
                    if (!roleAssignResult.Succeeded)
                    {
                        foreach (var identityError in roleAssignResult.Errors)
                        {
                            ModelState.AddModelError("", identityError.Description);
                        }
                        return View(model);
                    }

                    // Входим в систему после успешной регистрации
                    await _signInManager.SignInAsync(user, false);
                    TempData["SuccessMessage"] = "Вы успешно зарегистрированы!";
                    return RedirectToAction("Index", "PhoneContact");
                }
                else
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }

            return View(model);
        }

    }
}
