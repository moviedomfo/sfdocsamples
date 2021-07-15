using System;
using System.Collections.Generic;
using System.Linq;

namespace pelsoft.auth.common
{

   

    public class SecurityProviders : List<SecurityProvider>
    {
       
        public SecurityProviders()
        {

            
        }
       

        public static SecurityProvider Get(string name, SecurityProviders providers)
        {
            var prov =  providers.Where(p => p.Name.ToLowerInvariant().Equals(name.ToLowerInvariant())).FirstOrDefault();

            if (prov == null)
                throw new Exception("No existe el proveedor " + name);

            return prov;
        }
        
    }

    public class SecurityProvider
    {
        public string Name { get; set; }
        public string AudienceId { get; set; }
        public string Issuer { get; set; }
        public string RsaPrivateKey { get; set; }
        public string RsaPublicKey { get; set; }
        
        public string SecurityModelContext { get; set; }
        public int TokenExpires { get; set; }
        public int RefreshTokenExpires { get; set; }
    }
}
