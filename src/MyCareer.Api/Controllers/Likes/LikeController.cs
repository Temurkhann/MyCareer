using Microsoft.AspNetCore.Mvc;
using MyCareer.Domain.Configurations;
using MyCareer.Service.DTOs.Likes;
using MyCareer.Service.DTOs.Resumes;
using MyCareer.Service.Interfaces.Likes;
using MyCareer.Service.Services.Resumes;
using System.Threading.Tasks;

namespace MyCareer.Api.Controllers.Likes
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService likeService;

        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }

        /// <summary>
        /// Create new like
        /// </summary>
        /// <param name="likeForCreationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync(LikeForCreationDTO likeForCreationDTO)
            => Ok(await likeService.CreateAsync(likeForCreationDTO));

        /// <summary>
        /// GetAll likes
        /// </summary>
        /// <param name="params"></param>
        /// <returns></returns>
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await likeService.GetAll(@params));

        /// <summary>
        /// Get like
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await likeService.GetAsync(u => u.Id == id));

        /// <summary>
        /// Delete like
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await likeService.DeleteAsync(id));
    }
}
