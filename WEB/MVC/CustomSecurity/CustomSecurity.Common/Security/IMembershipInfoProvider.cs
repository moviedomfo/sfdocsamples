using System;

namespace CustomSecurity.Common.Security
{
    public interface IMembershipInfoProvider
    {
        MembershipUserWrapper GetUser(string username);
        MembershipUserWrapper GetUser(Guid userId);
        MembershipUserWrapper CreateUser(string username, string password, string email);
        bool ValidateUser(string username, string password);
        string[] GetRolesForUser(string username);
    }
}