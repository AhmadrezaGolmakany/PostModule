using PostModule.Domain.Common;
using PostModule.Domain.StateEntity;
using _Utilities.Enums;

namespace PostModule.Domain.CityEntity
{
    public class City : BaseEntity<int>
    {
        public int StateId { get; private set; }
        public string Title { get; private set; }

        public CityStatuse Statuse { get; set; }



        public State  state { get; private set; }

        public City() { }

        public City(int stateid, string title, CityStatuse statuse)
        {
            StateId = stateid;
            Title = title;
            Statuse = statuse;
           
        }

        public void Edite(string title, CityStatuse statuse)
        {
            Title = title;
            Statuse = statuse;

        }

        public void Istehran()
        {
            Statuse = CityStatuse.تهران;
        }
        public void Iscenter()
        {
            Statuse = CityStatuse.مرکز_استان;
        }
        public void NotCenterOrTehran()
        {
            Statuse = CityStatuse.شهرستان_معمولی;    
        }
    }
}
