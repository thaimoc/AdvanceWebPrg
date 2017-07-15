using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Validation;
using Entities.IRepository;
using DAL.Sql;
using System.Linq.Expressions;
using DAL.Sql.Modles;

namespace BLL
{
    public class ClassManager : IValidator<Class>
    {
        private IGeneralRepository<Class> _repository;

        public ClassManager(IGeneralRepository<Class> ict)
        {
            if (ict == null) throw new ArgumentNullException("ict");
            _repository = ict;
        }

        public ValidationResult Validate(Class obj)
        {
            var vResult = new ValidationResult();
            if (obj.CourseID <= 0)
                vResult.Messages.Add("Class's courseID is not accept null or less than zero!");

            using (GeneralRepository<Course> rp = new GeneralRepository<Course>())
            {                
                if(rp.Find(e=>e.CourseID == obj.CourseID).Count() <= 0)
                    vResult.Messages.Add("Class's courseID is not exited!");
            }

            if (obj.MemberID <= 0)
                vResult.Messages.Add("Class's MemberID is not accept null or less than zero!");

            using (GeneralRepository<Member> rp = new GeneralRepository<Member>())
            {
                if (rp.Find(e => e.MemberID == obj.MemberID).Count() <= 0)
                    vResult.Messages.Add("Class's meberID is not exited!");
            }
            
            if(obj.Completed == null)
                vResult.Messages.Add("Class's Completed does not accept null!");           

            return vResult;
        }

        public ActionResult InsertOrUpdate(Class _class)
        {
            var aResult = new ActionResult();
            try
            {
                if (_class.CourseID <= 0)
                {
                    if (_repository.Add(_class) <= 0)
                        aResult.Exceptions.Add(new Exception("Inserted process had been failed!"));
                }
                else
                {
                    if (!_repository.Update(_class))
                        aResult.Exceptions.Add(new Exception("Updated process had been failed!"));
                }
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResult Delete(Class _class)
        {
            var aResult = new ActionResult();
            try
            {
                if (!_repository.Delete(_class))
                    aResult.Exceptions.Add(new Exception("Deleted process had been failed!"));
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResult Delete(int _courseId, int _memberId)
        {
            var aResult = new ActionResult();
            try
            {
                if (!_repository.Delete(e => e.CourseID == _courseId && e.MemberID == _memberId))
                    aResult.Exceptions.Add(new Exception("Deleted process had been fail!"));
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResultAsList<Class> Find(Expression<Func<Class, bool>> predicate)
        {
            var aResult = new ActionResultAsList<Class>();
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
