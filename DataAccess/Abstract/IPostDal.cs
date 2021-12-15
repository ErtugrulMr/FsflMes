using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface IPostDal: IEntityRepository<Post>
    {
        PostDetailsDto GetPostDetails(int postId);
    }
}
