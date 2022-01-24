using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Domain.DataAccess.EntityFramework
{
    public interface IGenericRepository<T, TContext>
            where T : class
            where TContext : DbContext
    {
        void MarkAs(object entity, EntityState state);
    

        long Count();
       
        long Count(Expression<Func<T, bool>> predicate);
    

        bool Exists(Expression<Func<T, bool>> predicate);
       

        TResult Min<TResult>(Expression<Func<T, TResult>> selector);
        

        TResult Min<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);


        TResult Max<TResult>(Expression<Func<T, TResult>> selector);
        

        TResult Max<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);
       
        Task<T> Get(object id, CancellationToken cancellation);
        

        IList<T> GetAll();
        

        IList<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);
        

        T First();
        

        T First(Expression<Func<T, bool>> predicate);
        

        T First(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
        

        T Last();
        

        T Last(Expression<Func<T, bool>> predicate);
       

        T Last(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
        

        IList<T> Find(Expression<Func<T, bool>> predicate);
       

        IList<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
        

        IList<T> Take(int count);
       

        IList<T> Take<TKey>(Expression<Func<T, TKey>> orderBy, int count);
        

        IList<T> Take<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy, int count);
        

        Task Add(T item, CancellationToken cancellation);
        

        Task AddAsync(T item, CancellationToken cancellation);
       

        void Update(T item);
        

        void Remove(T item);
        
        void RemoveRange(Expression<Func<T, bool>> predicate);

        void Attach(T item);
        

        void Detach(T item);
        
        int Commit();

        int ExecuteSql(string sqlCommand, params object[] parameters);

        Task<int> ExecuteSqlAsync(string sqlCommand, params object[] parameters);
    }
}