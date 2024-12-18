using _Utilities.Enums;

namespace PostModule.Application.Contract.CityApplication
{
    public class EditeCityModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CityStatuse statuse { get; set; }

    }

}
