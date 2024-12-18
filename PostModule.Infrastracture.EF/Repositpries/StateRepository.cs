using PostModule.Application.Contract.StateApplication;
using PostModule.Domain.Services;
using PostModule.Domain.StateEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Infrastracture.EF.Repositpries
{
    internal class StateRepository : Repository<int , State> , IStateRepository
    {
        private readonly Post_Context _context;

        public StateRepository(Post_Context context) : base(context)
        {
            _context = context;
        }

        public List<StateViewModel> GetAllStateViewModel()
        {
            return GetAllQuery().Select(x => new StateViewModel { 
                   CreateDate = x.CreateDate.ToString(),
                   Id = x.Id,
                   Title = x.Title,
            
            }).ToList();
        }

        public EditeStateModel GetStateForEdite(int id)
        {
           var state = GetById(id);
            return new() { 
                Id = state.Id,
                Title = state.Title,
            };
        }
    }
}
