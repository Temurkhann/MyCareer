using MyCareer.Domain.Configurations;
using MyCareer.Domain.Entities.Likes;
using MyCareer.Service.DTOs.Likes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCareer.Service.Interfaces.Likes
{
    public interface ILikeService
    {
        ValueTask<IEnumerable<Like>> GetAll(PaginationParams @params, Expression<Func<Like, bool>> expression = null);
        ValueTask<Like> GetAsync(Expression<Func<Like, bool>> expression);
        ValueTask<Like> CreateAsync(LikeForCreationDTO likeForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        ValueTask<Like> Update(int Id, LikeForCreationDTO likeForCreation);
    }
}
