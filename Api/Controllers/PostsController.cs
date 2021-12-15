using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("add")]
        public IActionResult Add(Post post)
        {
            var result = _postService.Add(post);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Post post)
        {
            var result = _postService.Delete(post);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Post post)
        {
            var result = _postService.Update(post);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll(string cd = null, string sd = null)
        {
            var result = _postService.GetAll(cd,sd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("get-solveds")]
        public IActionResult GetSolveds(string cd = null, string sd = null)
        {
            var result = _postService.GetSolveds(cd,sd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-not-solveds")]
        public IActionResult GetNotSolveds(string cd = null, string sd = null)
        {
            var result = _postService.GetNotSolveds(cd, sd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            var result = _postService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("get-all-by-type-id")]
        public IActionResult GetAllByTypeId(int id, string cd = null, string sd = null)
        {
            var result = _postService.GetAllByTypeId(id, cd, sd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("get-all-by-student-id")]
        public IActionResult GetAllByStudentId(int id, string cd = null, string sd = null)
        {
            var result = _postService.GetAllByStudentId(id, cd, sd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("get-details")]
        public IActionResult GetDetails(int id)
        {
            var result = _postService.GetPostDetails(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
