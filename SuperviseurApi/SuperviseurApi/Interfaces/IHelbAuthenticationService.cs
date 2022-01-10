
using SuperviseurApi.Models;
using SuperviseurApi.Models.HelbModel;

namespace SuperviseurApi.Services
{
    public interface IHelbAuthenticationService
    {
        Task<string?> RetrieveToken(UserLogin userLogin);
    }
}