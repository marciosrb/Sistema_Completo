using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cadastro.Domain.DataAccess.EntityFramework
{

   public class GenericRepository<T, TContext> : IGenericRepository<T, TContext>
           where T : class
           where TContext : DbContext
   {
      #region Properties

      private TContext CurrentContext { get; set; }

      #endregion

      #region Constructor

      public GenericRepository(TContext context)
      {
         //Guard.Against.Null(context, nameof(context));
         CurrentContext = context;
      }

      #endregion

      #region Methods

      public void MarkAs(object entity, EntityState state)
      {
         if (entity is null)
         {
            throw new ArgumentNullException(nameof(entity));
         }

         CurrentContext.Entry(entity).State = state;
      }

      public long Count()
      {
         return CreateSet().Count();
      }

      public long Count(Expression<Func<T, bool>> predicate)
      {
         return CreateSet().Count(predicate);
      }

      public bool Exists(Expression<Func<T, bool>> predicate)
      {
         return Count(predicate) > 0;
      }

      public TResult Min<TResult>(Expression<Func<T, TResult>> selector)
      {
         var query = CreateSet();

         return query.Min(selector);
      }

      public TResult Min<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
      {
         var query = Where(predicate).AsNoTracking();

         return query.Min(selector);
      }

      public TResult Max<TResult>(Expression<Func<T, TResult>> selector)
      {
         var query = CreateSet();

         return query.Max(selector);
      }

      public TResult Max<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
      {
         var query = Where(predicate).AsNoTracking();

         return query.Max(selector);
      }

      public async Task<T> Get(object id, CancellationToken cancellation)
      {
         var keys = new object[1] { id };
         return await CreateSet().FindAsync(keys, cancellation);
      }

      public IList<T> GetAll()
      {
         return CreateSet()
             .DefaultIfEmpty()
             .AsNoTracking()
             .AsParallel()
             .ToList();
      }

      public IList<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
      {
         return SetIncludeExpressions(CreateSet(), includeExpressions)
             .DefaultIfEmpty()
             .AsNoTracking()
             .AsParallel()
             .ToList();
      }

      public T First()
      {
         return CreateSet().FirstOrDefault();
      }

      public T First(Expression<Func<T, bool>> predicate)
      {
         return Where(predicate)
             .DefaultIfEmpty()
             .AsNoTracking()
             .AsParallel()
             .FirstOrDefault();
      }

      public T First(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
      {
         return Where(predicate, includeExpressions)
             .DefaultIfEmpty()
             .AsNoTracking()
             .AsParallel()
             .FirstOrDefault();
      }

      public T Last()
      {
         return CreateSet().LastOrDefault();
      }

      public T Last(Expression<Func<T, bool>> predicate)
      {
         return Where(predicate)
             .DefaultIfEmpty()
             .AsNoTracking()
             .AsParallel()
             .LastOrDefault();
      }

      public T Last(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
      {
         return Where(predicate, includeExpressions)
             .DefaultIfEmpty()
             .AsNoTracking()
             .AsParallel()
             .LastOrDefault();
      }

      public IList<T> Find(Expression<Func<T, bool>> predicate)
      {
         return Where(predicate)
             .DefaultIfEmpty()
             .AsNoTracking()
             .AsParallel()
             .ToList();
      }

      public IList<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
      {
         return Where(predicate, includeExpressions)
             .DefaultIfEmpty()
             .AsNoTracking()
             .AsParallel()
             .ToList();
      }

      public IList<T> Take(int count)
      {
         return CreateSet().Take(count)
             .AsNoTracking()
             .ToList();
      }

      public IList<T> Take<TKey>(Expression<Func<T, TKey>> orderBy, int count)
      {
         return CreateSet().OrderBy(orderBy)
             .AsNoTracking()
             .Take(count)
             .ToList();
      }

      public IList<T> Take<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy, int count)
      {
         return CreateSet().Where(predicate)
             .OrderBy(orderBy)
             .AsNoTracking()
             .AsParallel()
             .Take(count)
             .ToList();
      }

      public Task Add(T item, CancellationToken cancellation)
      {
         if (item == null)
         {
            throw new ArgumentNullException(nameof(item));
         }

         return AddAsync(item, cancellation);

      }

      public async Task AddAsync(T item, CancellationToken cancellation)
      {
         await CreateSet().AddAsync(item, cancellation);
      }

      public Task AddRange(List<T> listItems, CancellationToken cancellation)
      {
         return AddRangeAsync(listItems, cancellation);
      }

      public async Task AddRangeAsync(List<T> listItems, CancellationToken cancellation)
      {
         if (listItems == null || listItems.Count < 1)
         {
            throw new ArgumentNullException(nameof(listItems));
         }

         await this.CreateSet().AddRangeAsync(listItems, cancellation);
      }

      public void Update(T item)
      {
         MarkAs(item, EntityState.Modified);
      }

      public void Remove(T item)
      {
         if (item == null)
         {
            throw new ArgumentNullException(nameof(item));
         }

         Attach(item);

         MarkAs(item, EntityState.Deleted);
      }

      public void RemoveRange(Expression<Func<T, bool>> predicate)
      {
         CurrentContext.RemoveRange(Where(predicate));
      }

      public void Attach(T item)
      {
         MarkAs(item, EntityState.Unchanged);
      }

      public void Detach(T item)
      {
         MarkAs(item, EntityState.Detached);
      }

      public int Commit()
      {
         return CurrentContext.SaveChanges();
      }

      public int ExecuteSql(string sqlCommand, params object[] parameters)
      {
         return CurrentContext.Database.ExecuteSqlRaw(sqlCommand, parameters);
      }

      public async Task<int> ExecuteSqlAsync(string sqlCommand, params object[] parameters)
      {
         return await CurrentContext.Database.ExecuteSqlRawAsync(sqlCommand, parameters);
      }

      private DbSet<T> CreateSet()
      {
         return CurrentContext.Set<T>();
      }

      private IQueryable<T> SetIncludeExpressions(IQueryable<T> query, params Expression<Func<T, object>>[] includeExpressions)
      {
         foreach (var item in includeExpressions)
         {
            query = query.Include(item);
         }

         return query;
      }

      private IQueryable<T> Where(Expression<Func<T, bool>> predicate)
      {
         return CreateSet().Where(predicate);
      }

      private IQueryable<T> Where(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
      {
         var query = Where(predicate);

         return SetIncludeExpressions(query, includeExpressions);
      }

      #endregion
   }
}