using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Thibetanus.Models;

namespace Thibetanus.Areas.Identity
{
    public class MySignInManager : SignInManager<ApplicationUser>
    {
        public MySignInManager(MyUserManager userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }
        public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            SignInResult result;
            result = SignInResult.Success;
            ApplicationUser User = await UserManager.FindByNameAsync(userName);

            var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Sid, User.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, User.Name));
            await Context.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));

            return result;
        }
    }
}
