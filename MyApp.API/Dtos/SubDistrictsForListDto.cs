using System;

namespace MyApp.API.Dtos
{
    public class SubDistrictsForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DistrictId { get; set; }
    }
}