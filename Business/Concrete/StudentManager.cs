using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StudentManager : IStudentService
    {

        private IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        [ValidationAspect(typeof(StudentValidator))]
        [SecuredOperation("sysAdmin,schAdmin")]
        public IResult Add(Student student)
        {
            if (!IsExists(student.SchoolNumber, student.NationalIdentityNumber))
            {
                _studentDal.Add(student);
                return new SuccessResult(Messages.StudentCreatedSuccessfully);
            }

            return new ErrorResult(Messages.StudentAlreadyExists);
        }

        [ValidationAspect(typeof(StudentValidator))]
        public IResult Delete(Student student)
        {
            var isExists = GetById(student.Id);
            if (isExists != null)
            {
                _studentDal.Delete(student);
                return new SuccessResult(Messages.StudentDeletedSuccessfully);
            }
            
            return new ErrorResult(Messages.StudentNotFound);
        }

        [ValidationAspect(typeof(StudentValidator))]
        public IResult Update(Student student)
        {
            var isExists = GetById(student.Id);
            if (isExists != null)
            {
                _studentDal.Update(student);
                return new SuccessResult(Messages.StudentUpdatedSuccessfully);
            }

            return new ErrorDataResult<Student>(Messages.StudentNotFound);
        }

        [SecuredOperation("sysAdmin,schAdmin")]
        public IDataResult<List<Student>> GetAll()
        {
            var result = _studentDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<Student>>(result);
            }

            return new ErrorDataResult<List<Student>>(Messages.NoStudentDataInDatabase);
        }

        public IDataResult<Student> GetById(int id)
        {
            var result = _studentDal.Get(s => s.Id == id);
            if(result != null)
            {
                return new SuccessDataResult<Student>(result);
            }

            return new ErrorDataResult<Student>(Messages.StudentNotFound);
        }
        
        public IDataResult<Student> GetBySchoolNumber(int schoolNumber)
        {
            var result = _studentDal.Get(s => s.SchoolNumber == schoolNumber);
            if(result != null)
            {
                return new SuccessDataResult<Student>(result);
            }

            return new ErrorDataResult<Student>(result, Messages.StudentNotFound);
        }
        
        public IDataResult<Student> GetByNationalIdentityNumber(long nationalIdentityNumber)
        {
            var result = _studentDal.Get(s => s.NationalIdentityNumber == nationalIdentityNumber);
            if (result != null)
            {
                return new SuccessDataResult<Student>(result);
            }

            return new ErrorDataResult<Student>(result, Messages.StudentNotFound);
        }

        private bool IsExists(int schoolNumber, long nationalIdentityNumber)
        {
            if (GetBySchoolNumber(schoolNumber).Success || GetByNationalIdentityNumber(nationalIdentityNumber).Success)
            {
                return true;
            }

            return false;
        }
    }
}
