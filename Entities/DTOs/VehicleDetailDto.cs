using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class VehicleDetailDto:IDto
    {
        public int Id { get; set; }
        public string VehicleName { get; set; }
        public string BrandName { get; set; }
       
        public string Color { get; set; }
        public DateTime Model { get; set; }
        public decimal  DailyPrice { get; set; }


    }
}
