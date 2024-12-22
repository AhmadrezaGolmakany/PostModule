using _Utilities.Application;
using _Utilities.Infrastracture;
using Microsoft.EntityFrameworkCore;
using PostModule.Application.Contract.PostApplication;
using PostModule.Domain.PostEntity;
using PostModule.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Infrastracture.EF.Repositpries
{
    internal class PostRepositories : Repository<int, Post>, IPostRepository
    {
        private readonly Post_Context _context;
        public PostRepositories(Post_Context context) : base(context)
        {
            _context = context;
        }

        public List<PostModel> GetAllPosts()
        {
            return GetAllQuery().Select(p=> new PostModel
            {
                CityPricePlus = p.CityPricePlus,
                CreateDate = p.CreateDate.ToPersainDate(),
                Id = p.Id,
                InsideStatePricePlus = p.InsideStatePricePlus,
                StateCenterPricePlus = p.StateCenterPricePlus,
                StateClosePricePlus = p.StateClosePricePlus,
                StateNonClosePricePlus = p.StateNonClosePricePlus,
                Status = p.Status,
                TehranPricePlus = p.TehranPricePlus,
                Title = p.Title,
                Description = p.Description,
                Active = p.Active,
                InsideCity = p.InsideCity,
                OutSideCity = p.OutSideCity, 
            }).ToList();
        }

        public EditePost GetForEdite(int id)
        {
            return _context.posts.Select(p => new EditePost
            {

                CityPricePlus = p.CityPricePlus,
                Id = p.Id,
                InsideStatePricePlus = p.InsideStatePricePlus,
                StateCenterPricePlus = p.StateCenterPricePlus,
                StateClosePricePlus = p.StateClosePricePlus,
                StateNonClosePricePlus = p.StateNonClosePricePlus,
                Status = p.Status,
                TehranPricePlus = p.TehranPricePlus,
                Title = p.Title,
                Description = p.Description
            }).SingleOrDefault(p=>p.Id == id);
        }
    }
}
