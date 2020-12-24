using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pelsoft.api.models
{
    public class loginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
        public string client_secret { get; set; }
        public string refresh_token { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationcontext)
        {
            var errors = new List<ValidationResult>();

            if (grant_type == "refresh_token")
            {
                if (string.IsNullOrEmpty(refresh_token))
                {
                    errors.Add(new ValidationResult("refresh_token es obligatorio si grant_type es refresh_token"));
                }
            }
            else if (grant_type == null || grant_type == "password")
            {
                if (string.IsNullOrEmpty(username))
                {
                    errors.Add(new ValidationResult("username es obligatorio si grant_type es refresh_token"));
                }

                if (string.IsNullOrEmpty(password))
                {
                    errors.Add(new ValidationResult("password es obligatorio si grant_type es refresh_token"));
                }
            }
            else
            {
                errors.Add(new ValidationResult("grant_type invalido"));
            }

            return errors;
        }
    }

    /// <summary>
    /// kcrm auth result
    /// </summary>
    public class loginResult
    {

        public string token { get; set; }

        public string refresh_token { get; set; }
    }
}
