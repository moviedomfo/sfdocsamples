using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using Fwk.Configuration;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.ActiveDirectory;
using Fwk.Exceptions;
using System.DirectoryServices.AccountManagement;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// Wrapper base de para interactuar con Servicios de Directorio
    /// 
    /// </summary>
    public class LogonProviderHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpszUsername"></param>
        /// <param name="lpszDomain"></param>
        /// <param name="lpszPassword"></param>
        /// <param name="dwLogonType"></param>
        /// <param name="dwLogonProvider"></param>
        /// <param name="phToken"></param>
        /// <returns></returns>
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern int GetLastError();

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        protected DirectoryEntry _directoryEntrySearchRoot;
        /// <summary>
        /// 
        /// </summary>
        protected string _LDAPPath;
        /// <summary>
        /// Domain DC name
        /// </summary>
        protected string _LDAPDomain;
        /// <summary>
        /// 
        /// </summary>
        protected string _LDAPUser;
        /// <summary>
        /// 
        /// </summary>
        protected string _LDAPPassword;

        /// <summary>
        /// Domain name ej Pelsoft-ar
        /// </summary>
        protected string _LDAPDomainName;
        /// <summary>
        /// Domain name ej Pelsoft-ar
        /// </summary>
        public string LDAPDomainName
        {
            get { return _LDAPDomainName; }

        }
        /// <summary>
        ///Ej: 
        ///LDAP://domain/DC=xxx,DC=com
        ///LDAP://CORRSF71NT13.Datacom.org/DC=Datacom,DC=org
        ///LDAP://Pc1.alcoDatacom.com.ar/OU=Datacom Sabattini,dc=alcoDatacom,dc=com,dc=ar
        /// </summary>
        public String LDAPPath
        {
            get
            {
                return _LDAPPath;
            }

        }


        /// <summary>
        ///LDAPUser property
        /// </summary>
        public String LDAPUser
        {
            get
            {
                return _LDAPUser;
            }

        }

        /// <summary>
        /// LDAPPassword property
        ///This property is reading the LDAP Password from the config file.
        /// </summary>
        public String LDAPPassword
        {
            get
            {
                return _LDAPPassword;
            }

        }


        /// <summary>
        /// Dominio
        /// </summary>
        public String LDAPDomain
        {
            get
            {
                return _LDAPDomain;
            }

        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberOf"></param>
        /// <returns></returns>
        public static List<string> GetGroupFromMemberOf(string memberOf)
        {
            int i = 0;
            string[] propAux;
            List<String> list = new List<String>();
            foreach (string prop in memberOf.Split(','))
            {
                propAux = prop.Split('=');

                if (propAux[0].CompareTo("CN") == 0)
                {
                    list.Add(propAux[1]);
                    i++;
                }

            }
            return list;
        }

      


     
       
    }
    /// <summary>
    /// Proporciona una clase base para implementaciones de identificadores Win32 seguros en las que el valor 0 ó -1 indica un identificador no válido.
    /// </summary>
    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }
}
