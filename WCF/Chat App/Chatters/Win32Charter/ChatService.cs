﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.832
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common
{
    using System.Runtime.Serialization;


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject
    {

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        private string ImageURLField;

        private string NameField;

        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImageURL
        {
            get
            {
                return this.ImageURLField;
            }
            set
            {
                this.ImageURLField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IChat", CallbackContract = typeof(IChatCallback), SessionMode = System.ServiceModel.SessionMode.Required)]
public interface IChat
{

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsInitiating = false, Action = "http://tempuri.org/IChat/Say")]
    void Say(string msg);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsInitiating = false, AsyncPattern = true, Action = "http://tempuri.org/IChat/Say")]
    System.IAsyncResult BeginSay(string msg, System.AsyncCallback callback, object asyncState);

    void EndSay(System.IAsyncResult result);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsInitiating = false, Action = "http://tempuri.org/IChat/Whisper")]
    void Whisper(string to, string msg);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsInitiating = false, AsyncPattern = true, Action = "http://tempuri.org/IChat/Whisper")]
    System.IAsyncResult BeginWhisper(string to, string msg, System.AsyncCallback callback, object asyncState);

    void EndWhisper(System.IAsyncResult result);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IChat/Join", ReplyAction = "http://tempuri.org/IChat/JoinResponse")]
    Common.Person[] Join(Common.Person name);

    [System.ServiceModel.OperationContractAttribute(AsyncPattern = true, Action = "http://tempuri.org/IChat/Join", ReplyAction = "http://tempuri.org/IChat/JoinResponse")]
    System.IAsyncResult BeginJoin(Common.Person name, System.AsyncCallback callback, object asyncState);

    Common.Person[] EndJoin(System.IAsyncResult result);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsTerminating = true, IsInitiating = false, Action = "http://tempuri.org/IChat/Leave")]
    void Leave();

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, IsTerminating = true, IsInitiating = false, AsyncPattern = true, Action = "http://tempuri.org/IChat/Leave")]
    System.IAsyncResult BeginLeave(System.AsyncCallback callback, object asyncState);

    void EndLeave(System.IAsyncResult result);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IChatCallback
{

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IChat/Receive")]
    void Receive(Common.Person sender, string message);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, AsyncPattern = true, Action = "http://tempuri.org/IChat/Receive")]
    System.IAsyncResult BeginReceive(Common.Person sender, string message, System.AsyncCallback callback, object asyncState);

    void EndReceive(System.IAsyncResult result);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IChat/ReceiveWhisper")]
    void ReceiveWhisper(Common.Person sender, string message);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, AsyncPattern = true, Action = "http://tempuri.org/IChat/ReceiveWhisper")]
    System.IAsyncResult BeginReceiveWhisper(Common.Person sender, string message, System.AsyncCallback callback, object asyncState);

    void EndReceiveWhisper(System.IAsyncResult result);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IChat/UserEnter")]
    void UserEnter(Common.Person person);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, AsyncPattern = true, Action = "http://tempuri.org/IChat/UserEnter")]
    System.IAsyncResult BeginUserEnter(Common.Person person, System.AsyncCallback callback, object asyncState);

    void EndUserEnter(System.IAsyncResult result);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/IChat/UserLeave")]
    void UserLeave(Common.Person person);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, AsyncPattern = true, Action = "http://tempuri.org/IChat/UserLeave")]
    System.IAsyncResult BeginUserLeave(Common.Person person, System.AsyncCallback callback, object asyncState);

    void EndUserLeave(System.IAsyncResult result);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IChatChannel : IChat, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class ChatClient : System.ServiceModel.DuplexClientBase<IChat>, IChat
{

    public ChatClient(System.ServiceModel.InstanceContext callbackInstance)
        :
            base(callbackInstance)
    {
    }

    public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName)
        :
            base(callbackInstance, endpointConfigurationName)
    {
    }

    public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress)
        :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public ChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
        :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public ChatClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
        :
            base(callbackInstance, binding, remoteAddress)
    {
    }

    public void Say(string msg)
    {
        base.Channel.Say(msg);
    }

    public System.IAsyncResult BeginSay(string msg, System.AsyncCallback callback, object asyncState)
    {
        return base.Channel.BeginSay(msg, callback, asyncState);
    }

    public void EndSay(System.IAsyncResult result)
    {
        base.Channel.EndSay(result);
    }

    public void Whisper(string to, string msg)
    {
        base.Channel.Whisper(to, msg);
    }

    public System.IAsyncResult BeginWhisper(string to, string msg, System.AsyncCallback callback, object asyncState)
    {
        return base.Channel.BeginWhisper(to, msg, callback, asyncState);
    }

    public void EndWhisper(System.IAsyncResult result)
    {
        base.Channel.EndWhisper(result);
    }

    public Common.Person[] Join(Common.Person name)
    {
        return base.Channel.Join(name);
    }

    public System.IAsyncResult BeginJoin(Common.Person name, System.AsyncCallback callback, object asyncState)
    {
        return base.Channel.BeginJoin(name, callback, asyncState);
    }

    public Common.Person[] EndJoin(System.IAsyncResult result)
    {
        return base.Channel.EndJoin(result);
    }

    public void Leave()
    {
        base.Channel.Leave();
    }

    public System.IAsyncResult BeginLeave(System.AsyncCallback callback, object asyncState)
    {
        return base.Channel.BeginLeave(callback, asyncState);
    }

    public void EndLeave(System.IAsyncResult result)
    {
        base.Channel.EndLeave(result);
    }
}
