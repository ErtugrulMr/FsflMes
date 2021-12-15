using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class PostManager: IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            this._postDal = postDal;
        }

        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IPostService.Get")]
        [ValidationAspect(typeof(PostValidator))]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IResult Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult(Messages.PostCreatedSuccessfully);
        }

        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IPostService.Get")]
        [ValidationAspect(typeof(PostValidator))]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IResult Delete(Post post)
        {
            var isExists = GetById(post.Id);
            if (isExists.Success)
            {
                _postDal.Delete(post);
                return new SuccessResult(Messages.PostDeletedSuccessfully);
            }
            
            return new ErrorResult(Messages.PostNotFound);
        }

        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IPostService.Get")]
        [ValidationAspect(typeof(PostValidator))]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IResult Update(Post post)
        {
            var isExists = GetById(post.Id);
            if (isExists.Success)
            {
                _postDal.Update(post);
                return new SuccessResult(Messages.PostUpdatedSuccessfully);
            }

            return new ErrorResult(Messages.PostNotFound);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<List<Post>> GetAll(string cd = null, string sd = null)
        {
            DateTime? creationDate = null;
            DateTime? solvingDate = null;

            if (cd != null)
            {
                creationDate = DateTime.Parse(String.Join(" ", cd.Split('-')));
            }
            if (sd != null)
            {
                solvingDate = DateTime.Parse(String.Join(" ", sd.Split('-')));
            }

            List<Post> result = new List<Post>();
            if (creationDate != null && solvingDate != null)
            {
                result = _postDal.GetAll(p=>p.CreationDate>=creationDate && p.SolvingDate<=solvingDate);
            }
            else if (creationDate != null && solvingDate != null)
            {
                result = _postDal.GetAll(p => p.CreationDate >= creationDate && p.SolvingDate <= solvingDate);
            }
            else if (creationDate != null && solvingDate == null)
            {
                result = _postDal.GetAll(p=>p.CreationDate>=creationDate);
            }
            else if (creationDate == null && solvingDate != null)
            {
                result = _postDal.GetAll(p => p.SolvingDate <= solvingDate);
            }
            else
            {
                result = _postDal.GetAll();
            }

            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Post>>(result);
            }
            
            return new ErrorDataResult<List<Post>>(Messages.NoPostDataInDatabase);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<List<Post>> GetAllByTypeId(int id, string cd = null, string sd = null)
        {
            var result = GetAll(cd, sd);
            if (result.Success)
            {
                var filteredData = result.Data.FindAll(p => p.TypeId == id);
                if (filteredData.Count > 0)
                {
                    return new SuccessDataResult<List<Post>>(filteredData);
                }
            }

            return new ErrorDataResult<List<Post>>(Messages.PostNotFound);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<List<Post>> GetAllByStudentId(int id, string cd = null, string sd = null)
        {
            var result = GetAll(cd, sd);
            if (result.Success)
            {
                var filteredData = result.Data.FindAll(p => p.StudentId == id);
                if (filteredData.Count > 0)
                {
                    return new SuccessDataResult<List<Post>>(filteredData);
                }
            }

            return new ErrorDataResult<List<Post>>(Messages.PostNotFound);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<List<Post>> GetSolveds(string cd = null, string sd = null)
        {
            var result = GetAll(cd, sd);
            if (result.Success)
            {
                var filteredData = result.Data.FindAll(p => p.IsSolved == true);
                if (filteredData.Count > 0)
                {
                    return new SuccessDataResult<List<Post>>(filteredData);
                }
            }

            return new ErrorDataResult<List<Post>>(Messages.PostNotFound);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<List<Post>> GetNotSolveds(string cd = null, string sd = null)
        {
            var result = GetAll(cd,sd);
            if (result.Success)
            {
                var filteredData = result.Data.FindAll(p => p.IsSolved == false);
                if (filteredData.Count > 0)
                {
                    return new SuccessDataResult<List<Post>>(filteredData);
                }
            }

            return new ErrorDataResult<List<Post>>(Messages.PostNotFound);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<Post> GetById(int id)
        {
            var result = _postDal.Get(s => s.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Post>(result);
            }

            return new ErrorDataResult<Post>(Messages.PostNotFound);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<PostDetailsDto> GetPostDetails(int id)
        {
            var result = _postDal.GetPostDetails(id);
            if (result != null)
            {
                return new SuccessDataResult<PostDetailsDto>(result);
            }

            return new ErrorDataResult<PostDetailsDto>(result);
        }
    }
}
