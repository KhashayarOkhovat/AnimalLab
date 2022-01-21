using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DataLayer;

namespace DataLayer.MyGenericRepository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private LabratoryDBEntities _db;
        private DbSet<TEntity> _dbset;
        public GenericRepository(LabratoryDBEntities db)
        {
            _db = db;
            _dbset = _db.Set<TEntity>();
        }

        //دستور خواندن اطلاعات از بانک
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes ="")
        {
            IQueryable<TEntity> query = _dbset;
            if (where != null)
            {
                query = query.Where(where);

            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                    query = query.Include(include);
            }
            return query.ToList();
        }
        //دستور افزودن به بانک
        public virtual void Insert(TEntity entity)
        {
            _dbset.Add(entity);
        }

        //دستور خواندن اطلاعات بر اساس آیدی از بانک
        public virtual TEntity GetById(object ID)
        {
            return _dbset.Find(ID);
        }

        //دستور ویرایش کردن اطلاعات 
        public virtual void Update(TEntity entity)
        {
            _dbset.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;

        }
        //دستور حذف از بانک
        public virtual void Delete(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }
            _dbset.Remove(entity);
        }
        //دستور حذف بر اساس آیدی
        public virtual void Delete(object ID)
        {
            var entity = GetById(ID);
            Delete(entity);
        }


    }
}
