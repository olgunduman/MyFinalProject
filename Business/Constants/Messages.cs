using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Eklemek istediğiniz ürün ismi daha önceden eklenmiştir";
        public static string CategoryLimitExceded="Kategori limiti aşıldıgı ıcın yenı urun eklenemez.";
        public static string AuthorizationDenied="Yetkiniz yok.";
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string AccessTokenCreated;
        internal static string UserAlreadyExists;
    }
}
