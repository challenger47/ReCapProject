using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Entities.Concrete;
using Core.Entities.Concrete;

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
        public static string ImageLimit="Bir Araç için En fazla 5 Adet Resim girilebilir";
        public static string AuthorizationDenied="Yetkiniz Yok";
        public static string UserRegistered="Kullanıcı Kaydedildi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Bşarılı";
        public static string UserAlreadyExists = "Bu isimde bir Kullanıcı Zaten Var ";
        public static string AccessTokenCreated = "Access Token Oluşturuldu ";
        internal static string UserDeleted="Kullanıcı Silindi";
        internal static string UserUpdated="Kullanıcı bilgileri güncellendi";
    }
}
