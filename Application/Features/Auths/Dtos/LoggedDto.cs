
using Core.Security.JWT;

namespace Application.Features.Auths.Dtos
{
    public class LoggedDto 
    {
        public AccessToken? AccessToken { get; set; }
        public bool IsSucceed { get; set; }

    }
}
