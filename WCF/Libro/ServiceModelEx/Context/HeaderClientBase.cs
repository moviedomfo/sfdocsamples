﻿// © 2008 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ServiceModelEx;
using System.Reflection;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ServiceModelEx
{
   public abstract class HeaderClientBase<T,H> : InterceptorClientBase<T> where T : class
   {
      protected H Header
      {get;set;}

      public HeaderClientBase() : this(default(H))
      {}

      public HeaderClientBase(string endpointName) : this(default(H),endpointName)
      {}

      public HeaderClientBase(string endpointName,string remoteAddress) : this(default(H),endpointName,remoteAddress)
      {}

      public HeaderClientBase(string endpointName,EndpointAddress remoteAddress) : this(default(H),endpointName,remoteAddress)
      {}

      public HeaderClientBase(Binding binding,EndpointAddress remoteAddress) : this(default(H),binding,remoteAddress)
      {}

      public HeaderClientBase(H header)
      {
         Header = header;
      }

      public HeaderClientBase(H header,string endpointName) : base(endpointName)
      {
         Header = header;
      }

      public HeaderClientBase(H header,string endpointName,string remoteAddress) : base(endpointName,remoteAddress)
      {
         Header = header;
      }

      public HeaderClientBase(H header,string endpointName,EndpointAddress remoteAddress) : base(endpointName,remoteAddress)
      {
         Header = header;
      }

      public HeaderClientBase(H header,Binding binding,EndpointAddress remoteAddress) : base(binding,remoteAddress)
      {
         Header = header;
      }
      protected override void PreInvoke(ref Message request)
      {
         GenericContext<H> context = new GenericContext<H>(Header);
         MessageHeader<GenericContext<H>> genericHeader = new MessageHeader<GenericContext<H>>(context);
         request.Headers.Add(genericHeader.GetUntypedHeader(GenericContext<H>.TypeName,GenericContext<H>.TypeNamespace));
      }
   }
}