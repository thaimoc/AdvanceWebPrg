using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Validation;
using Entities.IRepository;
using Utilities;
using System.Linq.Expressions;
using DAL.Sql.Modles;

namespace BLL
{
    public class MemberManager : IValidator<Member>
    {
        private IGeneralRepository<Member> _repository;

        public MemberManager(IGeneralRepository<Member> ict)
        {
            if (ict == null)
                throw new ArgumentNullException("ict");
            _repository = ict;
        }

        public ValidationResult Validate(Member obj)
        {
            var vResult = new ValidationResult();
            if(string.IsNullOrEmpty(obj.Name) || string.IsNullOrEmpty(obj.Name.Trim()))
                vResult.Messages.Add("Member's name does not accept null or empty!");

            if(_repository.Find(e=>e.Name.ToLower() == obj.Name.ToLower()).Count() > 0)
                vResult.Messages.Add("Member's name had have been exited!");

            //Check email's type;
            string email = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" 
                            + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
            if(!StringExtension.Test(obj.Email, email))
                vResult.Messages.Add("Member's email had not have been corrected!");

            if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrEmpty(obj.Email.Trim()))
                vResult.Messages.Add("Member's email does not accept null or empty!");

            if (_repository.Find(e => e.Email.ToLower() == obj.Email.ToLower()).Count() > 0)
                vResult.Messages.Add("Member's email had have been exited!");

            if (string.IsNullOrEmpty(obj.Password) || string.IsNullOrEmpty(obj.Password.Trim()))
                vResult.Messages.Add("Member's passwords does not accept null or empty!");

            if (obj.Password.Length <= 6)
                vResult.Messages.Add("Member's password must more than 6 character!");

            if(obj.IsActive == null)
                vResult.Messages.Add("Member's IsActive does not accept null!");

            return vResult;
        }

        public ActionResult InsertOrUpdate(Member member)
        {
            var aResult = new ActionResult();
            try
            {
                if (member.MemberID <= 0)
                {
                    if (_repository.Add(member) <= 0)
                        aResult.Exceptions.Add(new Exception("Inserted process had been failed!"));
                }
                else
                {
                    if (!_repository.Update(member))
                        aResult.Exceptions.Add(new Exception("Updated process had been failed!"));
                }
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResult Delete(Member member)
        {
            var aResult = new ActionResult();
            try
            {
                if (!_repository.Delete(member))
                    aResult.Exceptions.Add(new Exception("Deleted process had been failed!"));
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResult Delete(int _memberId)
        {
            var aResult = new ActionResult();
            try
            {
                if (!_repository.Delete(e => e.MemberID == _memberId))
                    aResult.Exceptions.Add(new Exception("Deleted process had been fail!"));
            }
            catch (Exception ex)
            {
                aResult.Exceptions.Add(ex);
            }
            return aResult;
        }

        public ActionResultAsList<Member> Find(Expression<Func<Member, bool>> predicate)
        {
            var aResult = new ActionResultAsList<Member>();
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
