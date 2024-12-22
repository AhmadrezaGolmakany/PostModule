using PostModule.Application.Contract.PostApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _Utilities.Application.OperationReault;

namespace PostModule.Application.Contract.PostPriceApplication
{
    public interface IPostPriceApplication
    {
        OperationResult Create(CreatePostPrice model);
        OperationResult Edite(EditPostPrice model);
        EditPostPrice GetForEdite(int id);

        List<PostPriceModel> GetAllForPost(int postId);

    }
}
