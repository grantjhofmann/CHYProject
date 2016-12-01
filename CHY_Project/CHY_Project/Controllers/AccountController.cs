using CHY_Project.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CHY_Project.Messaging;
using System.Data.Entity;

namespace CHY_Project.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private AppDbContext db = new AppDbContext();

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        private AppSignInManager _signInManager;
        private AppUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(AppUserManager userManager, AppSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public AppSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<AppSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)//NOTE: User has been re-directed here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            AuthenticationManager.SignOut();  //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Add fields to user here so they will be saved to the database
                //Create a new user with all the properties you need for the class
                var user = new AppUser { UserName = model.Email, Email = model.Email, FName = model.Fname, LName = model.Lname, StreetAddress = model.StreetAddress, City = model.City, ZipCode = model.ZipCode };


                //Add the new user to the database
                var result = await UserManager.CreateAsync(user, model.Password);

                //TODO: Once you get roles working, you may want to add users to roles upon creation
                //await UserManager.AddToRoleAsync(user.Id, "User"); //adds user to role called "User"
                // --OR--
                //await UserManager.AddToRoleAsync(user.Id, "Employee"); //adds user to role called "Employee"



                if (result.Succeeded) //user was created successfully
                {
                    //sign the user in
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    string username = User.Identity.GetUserName();
                    AppUser currentuser = db.Users.FirstOrDefault(c => c.UserName == username);
                    CreditCard creditcard1 = new CreditCard
                    {
                        CardNumber = model.CreditCard1,
                        Customer = currentuser
                    };

                    if (model.CreditCard1.Length == 15)
                    {
                        creditcard1.Cardtype = Cardtype.AmericanExpress;
                    }

                    else if (model.CreditCard1.StartsWith("54"))
                    {
                        creditcard1.Cardtype = Cardtype.MasterCard;
                    }

                    else if (model.CreditCard1.StartsWith("4"))
                    {
                        creditcard1.Cardtype = Cardtype.Visa;
                    }

                    else if (model.CreditCard1.StartsWith("6"))
                    {
                        creditcard1.Cardtype = Cardtype.Discover;
                    }

                    if (ModelState.IsValid)
                    {
                        db.CreditCards.Add(creditcard1);
                        db.SaveChanges();
                    }
                    if (model.CreditCard2 != null)
                    {
                        CreditCard creditcard2 = new CreditCard
                        {
                            CardNumber = model.CreditCard2,
                            Customer = currentuser
                        };

                        if (model.CreditCard2.Length == 15)
                        {
                            creditcard2.Cardtype = Cardtype.AmericanExpress;
                        }

                        else if (model.CreditCard2.StartsWith("54"))
                        {
                            creditcard2.Cardtype = Cardtype.MasterCard;
                        }

                        else if (model.CreditCard2.StartsWith("4"))
                        {
                            creditcard2.Cardtype = Cardtype.Visa;
                        }

                        else if (model.CreditCard2.StartsWith("6"))
                        {
                            creditcard2.Cardtype = Cardtype.Discover;
                        }
                        db.CreditCards.Add(creditcard2);
                        db.SaveChanges();
                    }

                    //Send a congratulatory email
                    EmailMessaging.SendEmail(user.Email, "Welcome to Longhorn Music - Group 13!","Thank you for signing up with Longhorn Music. You are now a registered user.");

                    //send them to the home page
                    return RedirectToAction("Index", "Home");
                }

                //if there was a problem, add the error messages to what we will display
                AddErrors(result);
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }


        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }


        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }


        //Account/ViewInfo
        public ActionResult ViewInfo()
        {
            string username = User.Identity.GetUserName();
            AppUser currentuser = db.Users.FirstOrDefault(u => u.UserName == username);

            return View(currentuser); 
        }

        //GET: /Account/EditInfo
        [HttpGet]
        public ActionResult EditInfo()
        {
            return View();
        }

        //POST: /Account/EditInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditInfo(EditInfoViewModel model)
        {
            string username = User.Identity.GetUserName();
            AppUser currentuser = db.Users.FirstOrDefault(u => u.UserName == username);

            if (model.Email != null && model.Email != "")
            {
                currentuser.Email = model.Email;
            }

            if (model.Fname != null && model.Fname != "")
            {
                currentuser.FName = model.Fname;
            }

            if (model.Lname != null && model.Lname != "")
            {
                currentuser.LName = model.Lname;
            }

            if (model.StreetAddress != null && model.StreetAddress != "")
            {
                currentuser.StreetAddress = model.StreetAddress;
            }

            if (model.City != null && model.City != "")
            {
                currentuser.City = model.City;
            }

            if (model.ZipCode.ToString() != null && model.ZipCode.ToString() != "")
            {
                currentuser.ZipCode = model.ZipCode;
            }

            if (model.CreditCard1 != null && model.CreditCard1 != "")
            {
                
                if (currentuser.CreditCards.Count() >= 1)
                {
                    CreditCard oldCreditCard = currentuser.CreditCards[0];
                    db.CreditCards.Remove(oldCreditCard);
                }

                CreditCard creditcard1 = new CreditCard
                {
                    CardNumber = model.CreditCard1,
                    Customer = currentuser
                };

                if (model.CreditCard1.Length == 15)
                {
                    creditcard1.Cardtype = Cardtype.AmericanExpress;
                }

                else if (model.CreditCard1.StartsWith("54"))
                {
                    creditcard1.Cardtype = Cardtype.MasterCard;
                }

                else if (model.CreditCard1.StartsWith("4"))
                {
                    creditcard1.Cardtype = Cardtype.Visa;
                }

                else if (model.CreditCard1.StartsWith("6"))
                {
                    creditcard1.Cardtype = Cardtype.Discover;
                }

                if (ModelState.IsValid)
                {
                    db.CreditCards.Add(creditcard1);
                    db.SaveChanges();
                }
            }

            if (model.CreditCard2 != null && model.CreditCard2 != "")
            {
                if (currentuser.CreditCards.Count() >= 2)
                {
                    CreditCard oldCreditCard = currentuser.CreditCards[1];
                    db.CreditCards.Remove(oldCreditCard);
                }

                CreditCard creditcard2 = new CreditCard
                {
                    CardNumber = model.CreditCard2,
                    Customer = currentuser
                };

                if (model.CreditCard2.Length == 15)
                {
                    creditcard2.Cardtype = Cardtype.AmericanExpress;
                }

                else if (model.CreditCard2.StartsWith("54"))
                {
                    creditcard2.Cardtype = Cardtype.MasterCard;
                }

                else if (model.CreditCard2.StartsWith("4"))
                {
                    creditcard2.Cardtype = Cardtype.Visa;
                }

                else if (model.CreditCard2.StartsWith("6"))
                {
                    creditcard2.Cardtype = Cardtype.Discover;
                }
                db.CreditCards.Add(creditcard2);
                db.SaveChanges();
            }



            db.Entry(currentuser).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }


        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}