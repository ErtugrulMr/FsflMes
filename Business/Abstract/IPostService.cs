using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPostService
    {
        IResult Add(Post post);
        IResult Delete(Post post);
        IResult Update(Post post);
        IDataResult<List<Post>> GetAll(string cd=null, string sd=null);
        IDataResult<List<Post>> GetAllByTypeId(int id, string cd = null, string sd = null);
        IDataResult<List<Post>> GetAllByStudentId(int id, string cd = null, string sd = null);
        IDataResult<List<Post>> GetSolveds(string cd = null, string sd = null);
        IDataResult<List<Post>> GetNotSolveds(string cd = null, string sd = null);
        IDataResult<Post> GetById(int id);
        IDataResult<PostDetailsDto> GetPostDetails(int id);
    }
}
