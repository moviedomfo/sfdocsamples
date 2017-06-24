using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using IdentitySample.Models;

namespace IdentitySample.Common
{
    /// <summary>
    /// Para controlar la persistencia se usa esta clase 
    /// Perform the basic CRUD operations on our groups
    /// We have no control over the relationships between the classes.
    /// What it does NOT do is handle the complexities introduced by the relationships between Groups, Users, and Roles
    /// </summary>
    public class ApplicationGroupStore : IDisposable
    {
        private bool _disposed;
        private GroupStoreBase _groupStore;


        public ApplicationGroupStore(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.Context = context;
            this._groupStore = new GroupStoreBase(context);
        }


        public IQueryable<ApplicationGroup> Groups
        {
            get
            {
                return this._groupStore.EntitySet;
            }
        }

        public DbContext Context
        {
            get;
            private set;
        }


        public virtual void Create(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Create(group);
            this.Context.SaveChanges();
        }


        public virtual async Task CreateAsync(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Create(group);
            await this.Context.SaveChangesAsync();
        }


        public virtual async Task DeleteAsync(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Delete(group);
            await this.Context.SaveChangesAsync();
        }


        public virtual void Delete(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Delete(group);
            this.Context.SaveChanges();
        }


        public Task<ApplicationGroup> FindByIdAsync(string roleId)
        {
            this.ThrowIfDisposed();
            return this._groupStore.GetByIdAsync(roleId);
        }


        public ApplicationGroup FindById(string roleId)
        {
            this.ThrowIfDisposed();
            return this._groupStore.GetById(roleId);
        }


        public Task<ApplicationGroup> FindByNameAsync(string groupName)
        {
            this.ThrowIfDisposed();
            return QueryableExtensions
                .FirstOrDefaultAsync<ApplicationGroup>(this._groupStore.EntitySet,
                    (ApplicationGroup u) => u.Name.ToUpper() == groupName.ToUpper());
        }


        public virtual async Task UpdateAsync(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Update(group);
            await this.Context.SaveChangesAsync();
        }


        public virtual void Update(ApplicationGroup group)
        {
            this.ThrowIfDisposed();
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }
            this._groupStore.Update(group);
            this.Context.SaveChanges();
        }


        // DISPOSE STUFF: ===============================================

        public bool DisposeContext
        {
            get;
            set;
        }


        private void ThrowIfDisposed()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(this.GetType().Name);
            }
        }


        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (this.DisposeContext && disposing && this.Context != null)
            {
                this.Context.Dispose();
            }
            this._disposed = true;
            this.Context = null;
            this._groupStore = null;
        }
    }
}