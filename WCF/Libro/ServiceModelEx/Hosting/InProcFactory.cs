// � 2008 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Runtime.CompilerServices;

namespace ServiceModelEx
{
   public static class InProcFactory
   {
      struct HostRecord
      {
         public HostRecord(ServiceHost host,string address)
         {
            Host = host;
            Address = new EndpointAddress(address);
         }
         public readonly ServiceHost Host;
         public readonly EndpointAddress Address;
      }

      static readonly Uri BaseAddress = new Uri("net.pipe://localhost/" + Guid.NewGuid().ToString());

      static readonly Binding Binding;

      static Dictionary<Type,HostRecord> m_Hosts = new Dictionary<Type,HostRecord>();
      static Dictionary<Type,ServiceThrottlingBehavior> m_Throttles = new Dictionary<Type,ServiceThrottlingBehavior>();
      static Dictionary<Type,object> m_Singletons = new Dictionary<Type,object>();

      static InProcFactory()
      {
         NetNamedPipeBinding binding;
         try
         {
            binding = new NetNamedPipeContextBinding("InProcFactory");
         }
         catch
         {
            binding = new NetNamedPipeContextBinding();
         }

         binding.TransactionFlow = true;

         Binding = binding;

         AppDomain.CurrentDomain.ProcessExit += delegate
                                                {
                                                   foreach(HostRecord hostRecord in m_Hosts.Values)
                                                   {
                                                      hostRecord.Host.Close();
                                                   }
                                                };
      }

      /// <summary>
      /// Can only call SetThrottle() before creating any instance of the service
      /// </summary>
      /// <typeparam name="S">Service type</typeparam>
      /// <param name="throttle">Throttle to use</param>
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static void SetThrottle<S>(ServiceThrottlingBehavior throttle)
      {
         if(m_Throttles.ContainsKey(typeof(S)))
         {
            m_Throttles[typeof(S)] = throttle;
         }
         else
         {
            m_Throttles.Add(typeof(S),throttle);
         }
      }
      /// <summary>
      /// Can only call SetThrottle() before creating any instance of the service
      /// </summary>
      public static void SetThrottle<S>(int maxCalls,int maxSessions,int maxInstances)
      {
         ServiceThrottlingBehavior throttle = new ServiceThrottlingBehavior();
         throttle.MaxConcurrentCalls = maxCalls;
         throttle.MaxConcurrentSessions = maxSessions;
         throttle.MaxConcurrentInstances = maxInstances;
         SetThrottle<S>(throttle);
      }
      /// <summary>
      /// Can only call SetSingleton() before creating any instance of the service
      /// </summary>
      /// <typeparam name="S"></typeparam>
      /// <param name="singleton"></param>
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static void SetSingleton<S>(S singleton)
      {
         if(m_Singletons.ContainsKey(typeof(S)))
         {
            m_Singletons[typeof(S)] = singleton;
         }
         else
         {
            m_Singletons.Add(typeof(S),singleton);
         }
      }

      [MethodImpl(MethodImplOptions.Synchronized)]
      public static I CreateInstance<S,I>() where I : class
                                            where S : class,I
      {
         HostRecord hostRecord = GetHostRecord<S,I>();
         ChannelFactory<I> factory = new ChannelFactory<I>(Binding,hostRecord.Address);
         return factory.CreateChannel();
      }
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static I CreateInstance<S,I,C>(InstanceContext<C> context) where I : class
                                                                             where S : class,I
      {
         HostRecord hostRecord = GetHostRecord<S,I>();
         return  DuplexChannelFactory<I,C>.CreateChannel(context,Binding,hostRecord.Address);
      }
      [MethodImpl(MethodImplOptions.Synchronized)]
      public static I CreateInstance<S,I,C>(C callback) where I : class
                                                             where S : class,I
      {
         DuplexClientBase<I,C>.VerifyCallback();
         InstanceContext<C> context = new InstanceContext<C>(callback);
         return CreateInstance<S,I,C>(context);
      }
      static HostRecord GetHostRecord<S,I>() where I : class
                                             where S : class,I
      {
         HostRecord hostRecord;
         if(m_Hosts.ContainsKey(typeof(S)))
         {
            hostRecord = m_Hosts[typeof(S)];
         }
         else
         {
            ServiceHost<S> host;
            if(m_Singletons.ContainsKey(typeof(S)))
            {
               S singleton = m_Singletons[typeof(S)] as S;
               Debug.Assert(singleton != null);
               host = new ServiceHost<S>(singleton,BaseAddress);
            }
            else
            {
               host = new ServiceHost<S>(BaseAddress);
            }    
          
            string address =  BaseAddress.ToString() + Guid.NewGuid().ToString();

            hostRecord = new HostRecord(host,address);
            m_Hosts.Add(typeof(S),hostRecord);
            host.AddServiceEndpoint(typeof(I),Binding,address);

            if(m_Throttles.ContainsKey(typeof(S)))
            {
               host.SetThrottle(m_Throttles[typeof(S)]);
            }
            host.Open();
         }
         return hostRecord;
      }
      public static void CloseProxy<I>(I instance) where I : class
      {
         ICommunicationObject proxy = instance as ICommunicationObject;
         Debug.Assert(proxy != null);
         proxy.Close();
      }
   }
}