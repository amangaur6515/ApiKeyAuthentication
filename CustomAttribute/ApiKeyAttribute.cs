using ApiKeyAuthentication.CustomFilter;
using Microsoft.AspNetCore.Mvc;

namespace ApiKeyAuthentication.CustomAttribute
{
    public class ApiKeyAttribute:ServiceFilterAttribute
    {
        public ApiKeyAttribute():base(typeof(ApiKeyAuthFilter))
        {
            
        }
    }
}
