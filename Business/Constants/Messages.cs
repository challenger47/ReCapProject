using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Constants
{
    //static yaparsak new lenemez
   public static class Messages
    {
        public static string VehicleAdded = "Araç Eklendi";
        public static string VehicleNameInvalid = "Araç adı minimum 2 karakter olmalıdır";
        public static string MaintenanceTime="Sistem Bakımda";
        public static string VehiclesListed = "Araçlar Listelendi";
        public static string VehicleDeleted = "Araç Silindi ";
        public static string VehicleUpdated = "Araç Güncellendi ";
        public static string BrandAdded = "Marka eklendi ";
        public static string BrandUpdated = "Marka Güncellendi ";
        public static string BrandDeleted = "Marka Silindi ";
        public static string ColorAdded = "Renk eklendi ";
        public static string ColorUpdated = "Renk Güncellendi ";
        public static string ColorDeleted = "Renk Silindi ";
        public static string RentalSucceed = "Kiralama işlemi gerçekleşti ";
        public static string NotAvailable = "Araç Müsait değil Teslim edilmedi veya Arızalı ";
        public static string TheSameVehicleCountError="Aynı İsimli Araçtan 5 adet Kaydedebilirsiniz"; //uydurma kurallar
        public static string TheSameBrandCountError="Aynı Markadan sadece 3 çeşit Araç Eklenebilir";
        public static string ImageAdded="Araç Resmi Eklendi";
        public static string ImageDeleted="Araç Resmi Silindi";
        internal static string ImageLimit="Bir Araç için En fazla 5 Adet Resim girilebilir";
    }
}
