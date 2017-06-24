using NHibernate;

namespace CustomSecurity.Common
{
    public interface ICurrentSessionContextAdapter
    {
        bool HasBind(ISessionFactory sessionFactory);
        ISession Unbind(ISessionFactory sessionFactory);
    }
}