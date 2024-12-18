using PostModule.Application.Contract.CityApplication;
using PostModule.Domain.CityEntity;
using PostModule.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Infrastracture.EF.Repositpries
{
    internal class CityRepository : Repository<int , City>, ICityRepository
    {
       private readonly Post_Context _context;

        public CityRepository(Post_Context context) : base(context) 
        {
            _context = context;
        }

        public List<CityViewModel> GetAllForState(int stateId)
        {
            return GetAllByQuery(c=>c.StateId == stateId).Select(c=>new CityViewModel
            {
                Createdate = c.CreateDate.ToString(),
                Id = c.Id,
                Title = c.Title,
                statuse = c.Statuse,
            }).ToList();
        }

        public EditeCityModel GetCityForEdite(int id)
        {
            var city  = GetById(id);
            return new()
            {
                Id = city.Id,
                Title = city.Title,
                statuse = city.Statuse,
            };
        }
    }
}
