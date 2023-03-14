using MyCarrier.Domain.Configurations;
using MyCarrier.Domain.Entities.Likes;
using MyCarrier.Domain.Entities.Resumes;
using MyCarrier.Service.DTOs.Likes;
using MyCarrier.Service.DTOs.Resumes;
using MyCarrier.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCarrier.Service.Interfaces.ILikeService
{
    public interface ILikeService
    {
        IQueryable<Like> GetAll(PaginationParams @params, Expression<Func<Like, bool>> expression = null);
        ValueTask<Like> GetAsync(Expression<Func<Like, bool>> expression);
        ValueTask<Like> CreateAsync(LikeForCreationDTO likeForCreationDTO);
        ValueTask<bool> DeleteAsync(int id);
        Like Update(int Id, LikeForCreationDTO likeForCreation);
    }
}
