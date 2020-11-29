using System.Threading.Tasks;

namespace fwk.template.api.common.jwt
{
    public interface ITokenManager
    {
        Task DesactivateCurrentAsynv();
        Task DesActiveAsync(string token);
        Task<bool> IsActiveAsync(string token);
        Task<bool> IsCurrentActiveToken();
    }
}