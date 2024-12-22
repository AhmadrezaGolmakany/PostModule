using _Utilities.Application;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PostModule.Application.Contract.PostApplication;
using PostModule.Application.Contract.PostPriceApplication;
using PostModule.Domain.PostEntity;
using PostModule.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static _Utilities.Application.OperationReault;

namespace PosModule.Application.Services
{
    internal class PostPriceApplication : IPostPriceApplication
    {
        private readonly IPostPriceRepository _repository;

        public PostPriceApplication(IPostPriceRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Create(CreatePostPrice model)
        {
            PostPrice postPrice = new PostPrice(model.PostId,model.Start,model.End,model.TehranPrice
                ,model.StateCenterPrice,model.CityPrice,model.InsideStatePrice
                ,model.StateClosePrice,model.StateNonClosePrice);

            if (_repository.Create(postPrice))
                return new(true);

            return new(false,ValidationMessages.SystemErrorMessage,"Start");


        }

        public OperationResult Edite(EditPostPrice model)
        {
            var postprice = _repository.GetById(model.Id);
            postprice.Edit(model.Start, model.End, model.TehranPrice
                , model.StateCenterPrice, model.CityPrice, model.InsideStatePrice
                , model.StateClosePrice, model.StateNonClosePrice);

            if (_repository.Save())
                return new(true);

            return new(false, ValidationMessages.SystemErrorMessage, "Start");
        }

        public List<PostPriceModel> GetAllForPost(int postId)
        {
            return _repository.GetAllForPost(postId);
        }

        public EditPostPrice GetForEdite(int id)
        {
            return _repository.GetForEdite(id);
        }
    }
}
