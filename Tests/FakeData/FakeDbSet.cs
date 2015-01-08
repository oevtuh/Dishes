using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace Tests.FakeData
{
    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private readonly ObservableCollection<T> _data;
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public T Add(T entity)
        {
            _data.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            _data.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get { return _data; }
        }

        public T Remove(T entity)
        {
            _data.Remove(entity);
            return entity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public Type ElementType
        {
            get { return _query.ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return _query.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _query.Provider; }
        }
    }
}