using _Utilities.Application;
using PostModule.Application.Contract.PostApplication;
using PostModule.Domain.PostEntity;
using PostModule.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _Utilities.Application.OperationReault;

namespace PosModule.Application.Services
{
    internal class PostApplication : IPostApplication
    {
        private readonly IPostRepository _repository;

        public PostApplication(IPostRepository repository)
        {
            _repository = repository;
        }

        public bool ActivationChange(int id)
        {
            var post = _repository.GetById(id);
            post.ActivationChange();
            return _repository.Save();
        }

        public OperationResult Create(CreatePost model)
        {
            if(_repository.Exist(p=>p.Title == model.Title))
            {
                return new OperationResult(false, ValidationMessages.DuplicatedMessage, "Title");
            }
            Post post = new(model.Title,model.Status,model.TehranPricePlus,model.StateCenterPricePlus
                ,model.CityPricePlus,model.InsideStatePricePlus,
                model.StateClosePricePlus,model.StateNonClosePricePlus,model.Description);

            if (_repository.Create(post))
            {
                return new(true);
            }
            return new OperationResult(false, ValidationMessages.SystemErrorMessage, "Title");


        }

        public OperationResult Edite(EditePost model)
        {
            if (_repository.Exist(p => p.Title == model.Title && p.Id!=model.Id))
            {
                return new OperationResult(false, ValidationMessages.DuplicatedMessage, "Title");
            }
            var post = _repository.GetById(model.Id);

             post.Edit(model.Title, model.Status, model.TehranPricePlus, model.StateCenterPricePlus
                , model.CityPricePlus, model.InsideStatePricePlus,
                model.StateClosePricePlus, model.StateNonClosePricePlus, model.Description);

            if (_repository.Save())
            {
                return new(true);
            }
            return new OperationResult(false, ValidationMessages.SystemErrorMessage, "Title");
        }

        public List<PostModel> GetAll()
        {
           return _repository.GetAllPosts();
        }

        public EditePost GetForEdite(int id)
        {
            return _repository.GetForEdite(id);
        }

        public bool InsideCityChange(int id)
        {
            var post = _repository.GetById(id);
            post.InsideCityChange();
            return _repository.Save();
        }

        public bool OutSideCityChange(int id)
        {
            var post = _repository.GetById(id);
            post.OutSideCityChange();
            return _repository.Save();
        }
    }
}
