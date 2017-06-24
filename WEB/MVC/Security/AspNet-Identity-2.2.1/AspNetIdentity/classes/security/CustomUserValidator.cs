using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace IdentitySample.Common
{
    /// <summary>
    /// <example>
    /// //Rest of code is removed for brevity
    ///Configure validation logic for usernames
    ///appUserManager.UserValidator = new CustomUserValidator(appUserManager)
    ///{
    ///    AllowOnlyAlphanumericUserNames = true,
    ///    RequireUniqueEmail = true
    ///};
    /// </example>
    /// </summary>
    public class CustomUserValidator : UserValidator<ApplicationUser>
    {

        //List<string> _allowedEmailDomains = new List<string> { "outlook.com", "hotmail.com", "gmail.com", "yahoo.com" };

        private readonly ApplicationUserManager _userManager;

        public CustomUserValidator(ApplicationUserManager appUserManager) : base(appUserManager)
        {
            _userManager = appUserManager;
        }
       
        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            var errors = new List<string>();
            //IdentityResult result = await base.ValidateAsync(user);

            if (_userManager != null)
            {
                //check username availability. and add a custom error message to the returned errors list.
                var existingAccount = await _userManager.FindByNameAsync(user.UserName);
                if (existingAccount != null && existingAccount.Id != user.Id)
                    errors.Add("El usuario ya existe");
            }

            //var emailDomain = user.Email.Split('@')[1];

            //if (!_allowedEmailDomains.Contains(emailDomain.ToLower()))
            //{
            //    var errors = result.Errors.ToList();

            //    errors.Add(String.Format("Email domain '{0}' is not allowed", emailDomain));

            //    result = new IdentityResult(errors);
            //}
            return errors.Any()
               ? IdentityResult.Failed(errors.ToArray())
               : IdentityResult.Success;
           
        }
    }


    /// <summary>
    /// Para agregarlo :
    /// <code><example>
    ///Rest of code is removed for brevity
    /// Configure validation logic for passwords
    ///appUserManager.PasswordValidator = new CustomPasswordValidator
    ///{
    ///    RequiredLength = 6,
    ///    RequireNonLetterOrDigit = true,
    ///    RequireDigit = false,
    ///    RequireLowercase = true,
    ///    RequireUppercase = true,
    ///};</example></code>
    /// </summary>
    public class CustomPasswordValidator : PasswordValidator
    {
        int minSpChar = 0;
        public int MinEspesialCharactersChar
        {
            get { return minSpChar; }
            set { minSpChar = value; }
        }
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            
            //var errors = result.Errors.ToList();
            var errors = new List<string>();
            if (this.RequiredLength < password.Length)
            {
                errors.Add(String.Format("El password debe contener {0} o mas caracteres", this.RequiredLength.ToString()));
            }
            //if (this.RequireDigit )
            //{
            //    if(password.con)
            //    errors.Add("El password debe incluir al menos 1 o mas numeros");
            //}
            //Check for Digits and Special Characters
            if (minSpChar != 0)
            {
                int splCharCount = 0;
                foreach (char c in password)
                {
                    if (Regex.IsMatch(c.ToString(), @"[!#$%&'()*+,-.:;<=>?@[\\\]{}^_`|~]")) splCharCount++;
                }

                if (splCharCount < minSpChar)
                {
                   errors.Add(String.Format("El password debe contener como mínimo {0} caracteres especiales", this.RequiredLength.ToString()));
                }
            }
            if (password.Contains(" "))
            {
                errors.Add("El password no puede contener espacios en blanco");

            }
            if (password.Contains("abcdef") || password.Contains("123456"))
            {
                errors.Add("El password no puede contener una secuencia de caracteres");

            }
            IdentityResult result = await base.ValidateAsync(password);
            return errors.Any()
                        ? IdentityResult.Failed(errors.ToArray())
                        : result;


        }
    }
    //public class CustomUserValidator<TUser> : IIdentityValidator<TUser>     where TUser : class, Microsoft.AspNet.Identity.IUser
    //{
    //    private readonly UserManager<TUser> _userManager;


    //    public CustomUserValidator(UserManager<TUser> manager)
    //    {
    //        _userManager = manager;
            
             
    //    }

    //    public async Task<IdentityResult> ValidateAsync(TUser user)
    //    {
    //        var errors = new List<string>();

    //        if (_userManager != null)
    //        {
    //            //check username availability. and add a custom error message to the returned errors list.
    //            var existingAccount = await _userManager.FindByNameAsync(user.UserName);
    //            if (existingAccount != null && existingAccount.Id != user.Id)
    //                errors.Add("El usuario ya existe");
    //        }

    //        //set the returned result (pass/fail) which can be read via the Identity Result returned from the CreateUserAsync
    //        return errors.Any()
    //            ? IdentityResult.Failed(errors.ToArray())
    //            : IdentityResult.Success;
    //    }
    //}
}