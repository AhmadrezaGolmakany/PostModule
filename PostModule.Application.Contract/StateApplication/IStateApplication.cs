using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Application.Contract.StateApplication
{
    public interface IStateApplication
    {
        bool Create(CreateStateModel model);
        bool Update(EditeStateModel model);
        List<StateViewModel> GetAll();
        EditeStateModel GetStateForEdite(int id);
        bool ExistTitleForCreate(string title);
        bool ExistTitleForEdite(string title,int id);
    }
}

