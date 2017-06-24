using NHibernate;
using NHibernate.Context;

namespace CustomSecurity.Common
{
    public class CurrentSessionContextAdapter : ICurrentSessionContextAdapter
    {
        public bool HasBind(ISessionFactory sessionFactory)
        {
            return CurrentSessionContext.HasBind(sessionFactory);
        }

        public ISession Unbind(ISessionFactory sessionFactory)
        {
            return CurrentSessionContext.Unbind(sessionFactory);
        }
    }
}