using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfPostDal : EfEntityRepositoryBase<Post, FsflMesContext>, IPostDal
    {
        public PostDetailsDto GetPostDetails(int postId)
        {
            using (var context = new FsflMesContext())
            {
                var result = from post in context.Posts
                             join report in context.Reports
                             on post.Id equals report.PostId
                             where report.PostId == postId
                             join student in context.Students
                             on post.StudentId equals student.Id
                             join schoolClass in context.SchoolClasses
                             on student.ClassId equals schoolClass.Id
                             join postType in context.PostTypes
                             on post.TypeId equals postType.Id
                             select new PostDetailsDto
                             {
                                 PostId = post.Id,
                                 TypeName = postType.Name,
                                 PostTitle = post.Title,
                                 IsPostRepliedByAdmin = post.IsRepliedByAdmin,
                                 IsPostSolved = post.IsSolved,
                                 ReportMessage = report.Message,
                                 StudentName = student.Name,
                                 StudentClassName = schoolClass.Name,
                                 SchoolNumber = student.SchoolNumber,
                                 StudentNationalIdentityNumber = student.NationalIdentityNumber,
                                 CreationDate = post.CreationDate,
                                 SolvingDate = post.SolvingDate
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
