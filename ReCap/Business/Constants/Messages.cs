using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //global
        public static string MaintenanceTime = "Sistem Bakımda";
        //Car
        public static string CarAdded = "Araç Eklendi";
        public static string CarFailedAdd = "Araç Eklenemedi";
        public static string CarListed="Araçlar Listelendi";
        public static string CarBrandIdListed="Araçlar markaya göre Listelendi";
        public static string CarColorIdListed="Araçlar renge göre Listelendi";
        public static string CarIdListed="Araç görüntülendi";
        public static string CarDetailListed="Araç Detayları Getirildi";
        public static string CarDeleted="Araç Silinmiştir";
        public static string CarUpdated="Araç Güncellenmiştir";
        //Brand
        public static string BrandNameInvalid="Marka İsmi Geçersiz";
        public static string BrandListed="Markalar Listelendi";
        public static string BrandDeleted="Marka Silindi";
        public static string BrandUpdated="Marka Bilgileri Güncellendi";
        //Color
        public static string ColorNameInvalid="Renk İsmi Geçersiz";
        public static string ColorListed="Renkler Listelendi";
        public static string ColorDeleted="Renk Silindi";
        public static string ColorUpdated="Renk Bilgisi Güncellendi";
        //Users
        public static string UsersNotAdded="Kullanıcı Eklenemedi";
        public static string UserAdded="Kullanıcı Eklendi";
        public static string UserDeleted="Kullanıcı Silindi";
        public static string UserUpdated="Kullanıcı Güncellendi";
        public static string UsersListed="Kullanıcılar Listelendi";
        //Customer
        public static string CustomerAdded="Müşteri Eklendi";
        public static string CustomerNotAdded = "Müsteri Eklenemedi";
        public static string CustomerDeleted="Müşteri Silindi";
        public static string CustomerUpdated="Müşteri Güncellendi";
        public static string CustomerListed="Müşteriler Listelendi";
        public static string CustomerDetailListed = "Müşteri Detayları Listelendi";
        //Rentals
        public static string RentalsAdded = "Araç Kiralandı";
        public static string RentalsNotAdded = "Bilgileri Kontrol Ediniz araç kiralanamadı";
        public static string RentalsListed = "Kiralık Araçlar Listelenmiştir";
        public static string RentalsDeleted = "Kiralık Araç Silindi";
        public static string RentalsUpdated = "Kiralık Araç Güncellendi";
        //CarImage
        public static string CarImageLimit="Maksimum resim sayısına ulaşıldı";
        public static string ImageUpdated = "Resim Güncellendi";
        public static string ImageDeleted = "Resim Silindi";
        public static string UploadImage = "Resim Yüklendi";
    }
}
