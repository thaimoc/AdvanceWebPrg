using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Validation;
using Entities.IRepository;
using System.Linq.Expressions;
using DAL.Sql;
using DAL.Sql.Modles;

namespace BLL
{
    public class CategoryManager:IValidator<Category>, IDisposable
    {
        private IGeneralRepository<Category> _repository;

        public CategoryManager()
        {
            _repository = new GeneralRepository<Category>();
        }

        public CategoryManager(IGeneralRepository<Category> ict)
        {
            if (ict == null) throw new ArgumentNullException("ict");
            _repository = ict;
        }

        public ValidationResult Validate(Category obj)
        {
            var vResult = new ValidationResult();

            if (string.IsNullOrEmpty(obj.Name) || string.IsNullOrEmpty(obj.Name.Trim()))
                vResult.Messages.Add("Category's Name is not accept null or empty!");

            if (obj.IsActive == null)
                vResult.Messages.Add("Category's IsActive is not accept null!");

            return vResult;
        }

        public ActionResult InsertOrUpdate(Category category)
        {
            var aResult = new ActionResult();
            try
            {
                if (category.CategoryID <= 0)
                {
                    if(_repository.Find(e=>e.Name.ToLower() == category.Name.ToLower()).Count() > 0)
                        aResult.Exceptions.Add(new Exception(String.Format("Category {0} had been exited!", category.Name)));
                    else if (_repository.Add(category) <= 0)
                        aResult.Exceptions.Add(new Exception("Inserted process had been fail!"));
                }
                else
                {
                    if(!_repository.Update(category))
                        aResult.Exceptions.Add(new Exception("Updated process had been fail!"));
                }
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResult Delete(Category category)
        {
            var aResult = new ActionResult();
            try
            {
                if (!_repository.Delete(category))
                    aResult.Exceptions.Add(new Exception("Deleted process had been fail!"));
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResult Delete(int categoryId)
        {
            var aResult = new ActionResult();
            try
            {
                if (!_repository.Delete(e => e.CategoryID == categoryId))
                    aResult.Exceptions.Add(new Exception("Deleted process had been fail!"));
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResultAsList<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            var aResult = new ActionResultAsList<Category>();
            try
            {
                aResult.Result = _repository.Find(predicate).ToList();
                if (aResult.Result.Count == 0)
                    aResult.Exceptions.Add(new Exception("Searching had have been ending and not found!"));
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public void Dispose()
        {
            if (_repository != null)
                (_repository as GeneralRepository<Category>).Dispose();
        }
    }
}
