using System;
using System.Collections.Generic;
using System.Linq;

namespace Monsterbutikken.UnitTests
{
    public abstract class FakeDbSet<T> : System.Data.Entity.IDbSet<T> where T : class
    {
        protected readonly List<T> List = new List<T>();

        protected FakeDbSet()
        {
            List = new List<T>();
        }

        protected FakeDbSet(IEnumerable<T> contents)
        {
            List = contents.ToList();
        }

        #region IDbSet<T> Members

        public T Add(T entity)
        {
            List.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            List.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        public abstract T Find(params object[] keyValues);

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public T Remove(T entity)
        {
            List.Remove(entity);
            return entity;
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return List.GetEnumerator();
        }

        #endregion

        #region IQueryable Members

        public Type ElementType
        {
            get { return List.AsQueryable().ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return List.AsQueryable().Expression; }
        }

        public IQueryProvider Provider
        {
            get { return List.AsQueryable().Provider; }
        }

        #endregion
    }
}
