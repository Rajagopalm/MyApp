using System;

namespace MyApp.API.Dtos
{
    public class SubDistrictsForListDto
    {
        public int Id { get; set; }
        public string CurrentCity { get; set; }
        public int? CurrentCityId { get; set; }
        public string CurrentDistrict { get; set; }
        public int? CurrentDistrictId { get; set; }
    }
}