using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.IRepository;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Data;
using System.Data.Entity;
using DAL.Sql.Modles;

namespace DAL.Sql
{
    public class GeneralRepository<T> : IDisposable, IGeneralRepository<T> where T : class
    {
        private readonly string _entitySetName;
        private readonly string[] _keyNames;

        private readonly ObjectSet<T> _set;
        private readonly ObjectContext _dataContext;

        public GeneralRepository()
        {
            _dataContext = (new CourseEntities()) as ObjectContext;
            _set = _dataContext.CreateObjectSet<T>();

            // Get entity set for current entity type
            var entitySet = _set.EntitySet;
            // Build full name of entity set for current entity type
            _entitySetName = _dataContext.DefaultContainerName + "." + entitySet.Name;
            // Get name of the entity's key properties
            _keyNames = entitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
        }

        public GeneralRepository(ObjectContext _objcontext)
        {
            if (_objcontext == null) throw new ArgumentNullException("_objcontext");
             _dataContext = _objcontext;
            _set = _dataContext.CreateObjectSet<T>();

            // Get entity set for current entity type
            var entitySet = _set.EntitySet;
            // Build full name of entity set for current entity type
            _entitySetName = _dataContext.DefaultContainerName + "." + entitySet.Name;
            // Get name of the entity's key properties
            _keyNames = entitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
        }

        public IQueryable<T> Paging(int page, int pageSize, out int howManyPages)
        {
            howManyPages = _dataContext.CreateObjectSet<T>().Count() / pageSize;
            return _dataContext.CreateObjectSet<T>().Skip((page - 1) * pageSize).Take(pageSize);
        }

        public T Single(params object[] keys)
        {
            if (keys.Length != _keyNames.Length)
            {
                throw new ArgumentException("Invalid number of key members");
            }

            // Merge key names and values by its order in array
            var keyPairs = _keyNames.Zip(keys, (keyName, keyValue) =>
                new KeyValuePair<string, object>(keyName, keyValue));

            // Build entity key
            var entityKey = new EntityKey(_entitySetName, keyPairs);
            // Query first current state manager and if entity is not found query database!!!
            return (T)_dataContext.GetObjectByKey(entityKey);
        }

        public IQueryable<T> All()
        {
            return _dataContext.CreateObjectSet<T>();
            
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _set.Where(predicate).AsQueryable<T>();
        }

        public int Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _set.AddObject(entity);
            return _dataContext.SaveChanges();
        }

        public bool Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            try
            {
                _dataContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Detached);
                _set.Attach(entity);
                _dataContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Modified);
                return _dataContext.SaveChanges() > 0;
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }
        }

        public bool Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dataContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Detached);
            _set.Attach(entity);
            //_set.DeleteObject(entity);
            ObjectStateEntry rs = _dataContext.ObjectStateManager.ChangeObjectState(entity, System.Data.EntityState.Deleted);
            //_contex.SaveChanges();
            return rs.State == EntityState.Deleted ? true : false;
        }

        public bool Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> objects = _set.Where(predicate).AsQueryable<T>();
            foreach (var obj in objects)
                Delete(obj);
            return _dataContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
