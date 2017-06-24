using System;

namespace CustomSecurity.Common.Security
{
    public class MembershipUserWrapper
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}