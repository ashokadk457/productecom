using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TeleCure.Shared;


namespace TeleCure.ProductAPI
{
    public class AuthorizeTokenAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasToken = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var tokenHeader);
            var token = tokenHeader.ToString().Replace("Bearer ", "");

            if (!hasToken || !StaticUserStore.IsValidToken(token))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }

}
