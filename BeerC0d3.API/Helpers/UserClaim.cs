using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeerC0d3.API.Helpers
{
    public enum ClaimUser
    {
        UserId,
        role

    }
    public class UserClaim : ControllerBase
    {
        private static UserClaim current = null;
        private HttpContext _httpContext;
       
        public UserClaim(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }

       
        public int UserID
        {
            set { }
            get { return this.getValueClaim(ClaimUser.UserId); }
        }



        private int getValueClaim(ClaimUser claim)
        {


            int value = 0;
            string valueClaim = string.Empty;
            var identity = ((ClaimsIdentity)_httpContext.User.Identity).Claims.Where(x => x.Type == claim.ToString()).FirstOrDefault();
            if (identity != null)
                value = int.Parse(identity.Value);

            return value;
        }
    }
}
