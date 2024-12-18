using PostModule.Application.Contract.CityApplication;
using PostModule.Application.Contract.StateApplication;
using PostModule.Domain.CityEntity;
using PostModule.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosModule.Application.Services
{
    internal class CityApplication : ICityApplication
    {
        private readonly ICityRepository _cityRepository;

        public CityApplication(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public bool Create(CreateCityModel model)
        {
            City city = new(model.StateId , model.Title , model.statuse);
            return _cityRepository.Create(city);
        }

        public bool ExistTitleForCreate(string title , int stateId)=>
            _cityRepository.Exist(c=>c.Title == title && c.StateId == stateId);

       

        public bool ExistTitleForEdite(string title, int id, int stateId) =>
            _cityRepository.Exist(c => c.Title == title && c.StateId == stateId && c.Id != id);



        public List<CityViewModel> GetAll() => null;

        public List<CityViewModel> GetAllForState(int stateId) =>
            _cityRepository.GetAllForState(stateId);
        
        public EditeCityModel GetCityForEdite(int id)=>
            _cityRepository.GetCityForEdite(id);

        public bool Update(EditeCityModel model)
        {
            var city = _cityRepository.GetById(model.Id);
            city.Edite(model.Title , model.statuse);
            return _cityRepository.Save();
        }
    }
}
