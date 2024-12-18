﻿using PostModule.Application.Contract.StateApplication;
using PostModule.Domain.StateEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Domain.Services
{
    public interface IStateRepository : IRepository<int, State>
    {
        List<StateViewModel> GetAllStateViewModel();
        EditeStateModel GetStateForEdite(int id);
    }
}
