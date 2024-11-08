﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using Starksoft.Net.Proxy;

namespace AE.Net.Mail
{
    public abstract class TextClient : IDisposable
    {
        protected TcpClient _Connection;
        protected Stream _Stream;
        ProxyInfo ProxyInfo;
        public string Host { get; private set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public bool IsConnected { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public bool IsDisposed { get; private set; }
        public System.Text.Encoding Encoding { get; set; }

        public TextClient()
        {
            Encoding = System.Text.Encoding.UTF8;
        }

        internal abstract void OnLogin(string username, string password);
        internal abstract void OnLogout();
        internal abstract void CheckResultOK(string result);

        protected virtual void OnConnected(string result)
        {
            CheckResultOK(result);
        }

        protected virtual void OnDispose() { }

        public void Login(string username, string password)
        {
            if (!IsConnected)
            {
                throw new Exception("You must connect first!");
            }
            IsAuthenticated = false;
            OnLogin(username, password);
            IsAuthenticated = true;
        }

        public void Logout()
        {
            IsAuthenticated = false;
            OnLogout();
        }


        public void Connect(string hostname, int port, bool ssl, bool skipSslValidation)
        {
            System.Net.Security.RemoteCertificateValidationCallback validateCertificate = null;
            if (skipSslValidation)
                validateCertificate = (sender, cert, chain, err) => true;
            Connect(hostname, port, ssl, validateCertificate);
        }
        public void Connect(ProxyInfo proxy, string hostname, int port, bool ssl, bool skipSslValidation)
        {
            System.Net.Security.RemoteCertificateValidationCallback validateCertificate = null;
            if (skipSslValidation)
                validateCertificate = (sender, cert, chain, err) => true;
            Connect(proxy, hostname, port, ssl, validateCertificate);
        }

        /// <summary>
        /// http://www.starksoft.com/prod_proxy.html
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="ssl"></param>
        /// <param name="validateCertificate"></param>
        public void Connect(ProxyInfo proxy, string hostname, int port, bool ssl, System.Net.Security.RemoteCertificateValidationCallback validateCertificate)
        {
            try
            {
                Host = hostname;
                Port = port;
                Ssl = ssl;
                ProxyInfo = proxy;
            
                    _Connection = ConnectViaHTTPProxy();
                _Stream = _Connection.GetStream();
                if (ssl)
                {
                    System.Net.Security.SslStream sslStream;
                    if (validateCertificate != null)
                        sslStream = new System.Net.Security.SslStream(_Stream, false, validateCertificate);
                    else
                        sslStream = new System.Net.Security.SslStream(_Stream, false);
                    _Stream = sslStream;
                    sslStream.AuthenticateAsClient(hostname);
                }

                OnConnected(GetResponse());

                IsConnected = true;
                Host = hostname;
            }
            catch (Exception ex)
            {
                IsConnected = false;
                Utilities.TryDispose(ref _Stream);
                throw ex;
            }
        }

        public void Connect(string hostname, int port, bool ssl, System.Net.Security.RemoteCertificateValidationCallback validateCertificate)
        {
            try
            {
                Host = hostname;
                Port = port;
                Ssl = ssl;

                if (ProxyInfo == null)
                    _Connection = new TcpClient(hostname, port);
                else
                    _Connection = ConnectViaHTTPProxy();

                _Stream = _Connection.GetStream();
                if (ssl)
                {
                    System.Net.Security.SslStream sslStream;
                    if (validateCertificate != null)
                        sslStream = new System.Net.Security.SslStream(_Stream, false, validateCertificate);
                    else
                        sslStream = new System.Net.Security.SslStream(_Stream, false);
                    _Stream = sslStream;
                    sslStream.AuthenticateAsClient(hostname);
                }

                OnConnected(GetResponse());

                IsConnected = true;
                Host = hostname;
            }
            catch (Exception ex)
            {
                IsConnected = false;
                Utilities.TryDispose(ref _Stream);
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetHost"></param>
        /// <param name="targetPort"></param>
        /// <returns></returns>
        TcpClient ConnectViaHTTPProxy(    )
        {
            // create an instance of the client proxy factory 
            ProxyClientFactory factory = new ProxyClientFactory();
            
            // use the proxy client factory to generically specify the type of proxy to create 
            // the proxy factory method CreateProxyClient returns an IProxyClient object 
            IProxyClient proxy = factory.CreateProxyClient(ProxyType.Http, ProxyInfo.Host, ProxyInfo.Port, ProxyInfo.UserName, ProxyInfo.Password);

            // create a connection through the proxy to www.starksoft.com over port 80 
            return proxy.CreateConnection(Host, Port);
        }


        protected void CheckConnectionStatus()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(this.GetType().Name);
            if (!IsConnected)
                throw new Exception("You must connect first!");
            if (!IsAuthenticated)
                throw new Exception("You must authenticate first!");
        }

        protected virtual void SendCommand(string command)
        {
            var bytes = System.Text.Encoding.Default.GetBytes(command + "\r\n");
            _Stream.Write(bytes, 0, bytes.Length);
        }

        protected string SendCommandGetResponse(string command)
        {
            SendCommand(command);
            return GetResponse();
        }

        protected virtual string GetResponse()
        {
            byte b;
            using (var mem = new System.IO.MemoryStream())
            {
                while (true)
                {
                    b = (byte)_Stream.ReadByte();
                    if ((b == 10 || b == 13))
                    {
                        if (mem.Length > 0 && b == 10)
                        {
                            return Encoding.GetString(mem.ToArray());
                        }
                    }
                    else
                    {
                        mem.WriteByte(b);
                    }
                }
            }
        }

        protected void SendCommandCheckOK(string command)
        {
            CheckResultOK(SendCommandGetResponse(command));
        }

        public void Disconnect()
        {
            if (IsAuthenticated)
                Logout();

            Utilities.TryDispose(ref _Stream);
            Utilities.TryDispose(ref _Connection);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disconnect();

                try
                {
                    OnDispose();
                }
                catch (Exception) { }

                IsDisposed = true;
                _Stream = null;
                _Connection = null;
            }
        }
    }

    public class ProxyInfo
    {
        public int Port { get; set; }
        public string Host { get; set; }

        public string UserName { get; set; }
        public String Password { get; set; }
        public string Domain { get; set; }
    }
}
