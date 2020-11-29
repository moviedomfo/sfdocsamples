using System;
using System.Threading.Tasks;

namespace fwk.template.api.common
{
    public interface IApiLogServices
    {
        Task LogError_asynk(Exception ex);
        Task Log_asynk(ApiEvent apiEvent);
    }
}