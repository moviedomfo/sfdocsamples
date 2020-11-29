namespace fwk.template.api.common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApiConfig
    {
        string api_audienceToken { get; set; }
        string api_authServerBaseUrl { get; set; }
        int api_expireTime { get; set; }
        string api_InstanceName { get; set; }
        string api_issuerToken { get; set; }
        api_mail api_mail { get; set; }
        string api_secretKey { get; set; }
        string api_storageBaseUrl { get; set; }
        string logsFolder { get; set; }
        string proxyDomain { get; set; }
        bool proxyEnabled { get; set; }
        string proxyName { get; set; }
        string proxyPassword { get; set; }
        string proxyPort { get; set; }
        string proxyUser { get; set; }
    }
}