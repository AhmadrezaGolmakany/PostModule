using PostModule.Domain.CityEntity;
using PostModule.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Domain.StateEntity
{
    public class State : BaseEntity<int>
    {
        public string Title { get; private set; }

        public string CloseStates { get; private set; }




        public List<City> cities { get; set; }

        public State(string title )
        {
            Title = title;
            CloseStates = "";
            cities = new();
        }

        public void Edite(string title)
        {
            Title = title;
        }

        public void ChangeCloseStates(List<int> states)
        {
            CloseStates = string.Join(", ", states);
        }
    }
}
