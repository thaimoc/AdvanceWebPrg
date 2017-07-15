using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Validation;
using Entities.IRepository;
using System.Linq.Expressions;
using DAL.Sql.Modles;

namespace BLL
{
    public class CourseManger:IValidator<Course>
    {
        private IGeneralRepository<Course> _repository;

        public CourseManger(IGeneralRepository<Course> ict)
        {
            if (ict == null) throw new ArgumentNullException("ict");
            _repository = ict;
        }

        public ValidationResult Validate(Course obj)
        {
            var vResult = new ValidationResult();

            if (string.IsNullOrEmpty(obj.Name) || string.IsNullOrEmpty(obj.Name.Trim()))
                vResult.Messages.Add("Course's Name is not accept null or empty!");

            if (obj.CategoryID == null)
                vResult.Messages.Add("Course's categoryID is not accept null!");

            if (obj.IsActive == null)
                vResult.Messages.Add("Category's IsActive is not accept null!");

            return vResult;
        }

        public ActionResult InsertOrUpdate(Course course)
        {
            var aResult = new ActionResult();
            try
            {
                if (course.CourseID <= 0)
                {
                    if (_repository.Find(e => e.Name.ToLower() == course.Name.ToLower()).Count() > 0)
                        aResult.Exceptions.Add(new Exception(String.Format("Category {0} had been exited!", course.Name)));
                    else if (_repository.Add(course) <= 0)
                        aResult.Exceptions.Add(new Exception("Inserted process had been failed!"));
                }
                else
                {
                    if (!_repository.Update(course))
                        aResult.Exceptions.Add(new Exception("Updated process had been failed!"));
                }
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResult Delete(Course course)
        {
            var aResult = new ActionResult();
            try
            {
                if (!_repository.Delete(course))
                    aResult.Exceptions.Add(new Exception("Deleted process had been failed!"));
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResult Delete(int courseId)
        {
            var aResult = new ActionResult();
            try
            {
                if (!_repository.Delete(e => e.CourseID == courseId))
                    aResult.Exceptions.Add(new Exception("Deleted process had been fail!"));
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResultAsList<Course> Find(Expression<Func<Course, bool>> predicate)
        {
            var aResult = new ActionResultAsList<Course>();
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
    }
}
