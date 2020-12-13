using Microsoft.AspNetCore.Mvc.Filters;

namespace RideShareRestApi.Attributes
{
    public class NeedRoleAttribute : ActionFilterAttribute
    {
        public string Role { get; set; }
    }
}
