using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class RentalDetailDto:IDto
    {

       
            public int Id { get; set; }
            public int VehicleId { get; set; }
            public int CustomerId { get; set; }
           
            public string VehicleName { get; set; }
            public string BrandName { get; set; }
            public string CustomerName { get; set; }
        
            public string UserName { get; set; }
          
            public decimal DailyPrice { get; set; }
            public DateTime RentDate { get; set; }
            public DateTime? DeliveryDate { get; set; }











    }
}
