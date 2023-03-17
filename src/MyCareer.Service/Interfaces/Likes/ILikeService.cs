using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Likes;
using MyCareer.Service.DTOs.Likes;

namespace MyCareer.Service.Interfaces.Likes
{
    public interface ILikeService
    {
        ValueTask<IQueryable<Like>> GetAll(PaginationParams @params, Expression<Func<Like, bool>> expression = null);
        ValueTask<Like> GetAsync(Expression<Func<Like, bool>> expression);
        ValueTask<Like> CreateAsync(LikeForCreationDTO likeForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Like> Update(int Id, LikeForCreationDTO likeForCreation);
    }
}
