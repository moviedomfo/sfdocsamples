﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Microsoft.ServiceModel.Samples
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="Microsoft.ServiceModel.Samples.IStreamedEchoService")]
    public interface IStreamedEchoService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IStreamedEchoService/Echo", ReplyAction="http://Microsoft.ServiceModel.Samples/IStreamedEchoService/EchoResponse")]
        System.IO.Stream Echo(System.IO.Stream data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IStreamedEchoServiceChannel : Microsoft.ServiceModel.Samples.IStreamedEchoService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class StreamedEchoServiceClient : System.ServiceModel.ClientBase<Microsoft.ServiceModel.Samples.IStreamedEchoService>, Microsoft.ServiceModel.Samples.IStreamedEchoService
    {
        
        public StreamedEchoServiceClient()
        {
        }
        
        public StreamedEchoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public StreamedEchoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public StreamedEchoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public StreamedEchoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.IO.Stream Echo(System.IO.Stream data)
        {
            return base.Channel.Echo(data);
        }
    }
}
