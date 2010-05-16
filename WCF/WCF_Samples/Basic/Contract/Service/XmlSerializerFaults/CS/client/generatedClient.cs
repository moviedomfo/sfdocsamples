﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "3.0.4506.2010")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Microsoft.ServiceModel.Samples")]
public partial class MathFault
{
    
    private string operationField;
    
    private string problemTypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=0)]
    public string Operation
    {
        get
        {
            return this.operationField;
        }
        set
        {
            this.operationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=1)]
    public string ProblemType
    {
        get
        {
            return this.problemTypeField;
        }
        set
        {
            this.problemTypeField = value;
        }
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="ICalculator")]
public interface ICalculator
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ICalculator/Add", ReplyAction="http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    int Add(int n1, int n2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ICalculator/Subtract", ReplyAction="http://Microsoft.ServiceModel.Samples/ICalculator/SubtractResponse")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    int Subtract(int n1, int n2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ICalculator/Multiply", ReplyAction="http://Microsoft.ServiceModel.Samples/ICalculator/MultiplyResponse")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    int Multiply(int n1, int n2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ICalculator/Divide", ReplyAction="http://Microsoft.ServiceModel.Samples/ICalculator/DivideResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(MathFault), Action="http://Microsoft.ServiceModel.Samples/ICalculator/DivideMathFaultFault", Name="MathFault")]
    [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
    int Divide(int n1, int n2);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
{
    
    public CalculatorClient()
    {
    }
    
    public CalculatorClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public CalculatorClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int Add(int n1, int n2)
    {
        return base.Channel.Add(n1, n2);
    }
    
    public int Subtract(int n1, int n2)
    {
        return base.Channel.Subtract(n1, n2);
    }
    
    public int Multiply(int n1, int n2)
    {
        return base.Channel.Multiply(n1, n2);
    }
    
    public int Divide(int n1, int n2)
    {
        return base.Channel.Divide(n1, n2);
    }
}
