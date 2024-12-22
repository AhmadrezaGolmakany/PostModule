using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _Utilities.Application.OperationReault;

namespace PostModule.Application.Contract.PostApplication
{
    public interface IPostApplication
    {
        OperationResult Create(CreatePost model);
        OperationResult Edite(EditePost model);
        EditePost GetForEdite(int id );

        List<PostModel> GetAll();

        bool ActivationChange(int id);
        bool InsideCityChange(int id);
        bool OutSideCityChange(int id);
    }
}
