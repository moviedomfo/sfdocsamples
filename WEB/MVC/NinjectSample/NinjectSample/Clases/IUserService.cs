using System;
using NinjectSample.Clases.BE;
namespace NinjectSample.Clases.Svc
{
    interface IUserService
    {
        UserData Get(string name);
    }
}
