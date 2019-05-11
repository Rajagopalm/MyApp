using System;

namespace MyApp.API.Dtos
{
    public class DistrictsForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? StateId { get; set; }
    }
}