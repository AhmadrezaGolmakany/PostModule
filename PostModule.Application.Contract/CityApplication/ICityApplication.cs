using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Application.Contract.CityApplication
{
    public interface ICityApplication
    {
        bool Create(CreateCityModel model);
        bool Update(EditeCityModel model);
        List<CityViewModel> GetAll();
        List<CityViewModel> GetAllForState(int stateId);

        EditeCityModel GetCityForEdite(int id);
        bool ExistTitleForCreate(string title, int stateId);
        bool ExistTitleForEdite(string title,int id, int stateId);
    }
}

