using Microsoft.EntityFrameworkCore;
using PostModule.Application.Contract.StateQuery;
using PostModule.Infrastracture.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Query.Services
{
    internal class StateQuery : IStateQuery
    {
        private readonly Post_Context _context;

        public StateQuery(Post_Context context)
        {
            _context = context;
        }

        public List<StateQueryModel> GetStatesWithCity()=>
            _context.states.Include(s=>s.cities).Select(s=>new StateQueryModel
            {
                Name =s.Title,
                cities = s.cities.Select(c=>new CityQueryModel
                {
                    CityCode = c.Id,
                    Name = c.Title
                }).ToList(),
            }).ToList();
       
    }
}
