using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    // Static verdiğimizde new' lememize gerek kalmaz. Direk Messages. deriz
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductDeleted = "Ürün silindi.";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductListed = "Ürünler Listelendi";

        public static string MaintenanceTime = "Sistem bakımda";

        public static string CategoryListed = "Kategoriler listelendi";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerUpdated = "Müşteri güncellendi";

        public static string OrderAdded = "Sipariş eklendi";
        public static string OrderUpdated = "Sipariş güncellendi";
        public static string OrderDeleted = "Sipariş silindi";
        public static string OrderListed = " Siparişler listelendi";

        public static string CapacityFulled = "En fazla 10 adet resim yükleyebilirsiniz.";

        public static string ProductImageAdded = "Ürün resmi eklendi";
        public static string ProductImageNotAdded = "Ürün resmi eklenemedi";

        public static string ProductImageDeleted = "Ürün resmi silindi";

        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";

        public static string CustomerNameAlreadyExists = "Bu isimde zaten başka bir kullanıcı var";
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kullanıcı kayıtlı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Erişim Jetonu Oluşturuldu";
    }
}
