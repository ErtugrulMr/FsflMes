using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager: IPostService
    {
        IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            this._postDal = postDal;
        }

        public IResult Add(Post post)
        {
            _postDal.Add(post);
            return new SuccessResult(Messages.PostCreatedSuccessfully);
        }

        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.PostDeletedSuccessfully);
        }

        public IResult Update(Post post)
        {
            _postDal.Update(post);
            return new SuccessResult(Messages.PostUpdatedSuccessfully);
        }

        public IDataResult<List<Post>> GetAll()
        {
            var result = _postDal.GetAll();
            return new SuccessDataResult<List<Post>>(result);
        }

        public IDataResult<Post> GetById(int id)
        {
            var result = _postDal.Get(s => s.Id == id);
            return new SuccessDataResult<Post>(result);
        }

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
