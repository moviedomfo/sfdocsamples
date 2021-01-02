using System;
using System.Threading.Tasks;

namespace pelsoft.api.common
{
    public interface IApiLogServices
    {
        Task LogError_asynk(Exception ex);
        Task Log_asynk(ApiEvent apiEvent);
    }
}