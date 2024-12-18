using PostModule.Application.Contract.StateApplication;
using PostModule.Domain.Services;
using PostModule.Domain.StateEntity;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosModule.Application.Services
{
    internal class StateApplication : IStateApplication
    {
        private readonly IStateRepository _stateRepository;

        public StateApplication(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public bool Create(CreateStateModel model)
        {
            State state = new(model.Title);
            return _stateRepository.Create(state);
        }

        public bool ExistTitleForCreate(string title)=>
            _stateRepository.Exist(s => s.Title == title);


        public bool ExistTitleForEdite(string title, int id)=>
            _stateRepository.Exist(s => s.Title == title && s.Id != id);


        public List<StateViewModel> GetAll()=>
            _stateRepository.GetAllStateViewModel();
        

        public EditeStateModel GetStateForEdite(int id)
        {
            return _stateRepository.GetStateForEdite(id);

        }

        public bool Update(EditeStateModel model)
        {
            var state = _stateRepository.GetById(model.Id);
            state.Edite(model.Title);
            return _stateRepository.Save();
        }
    }
}
