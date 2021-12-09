using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {

        // Success Messages

        public static readonly string SuccessfulLogin = "Başarılı giriş.";

        public static readonly string TokenCreated = "Token oluşturuldu.";

        public static readonly string StudentCreatedSuccessfully = "Öğrenci başarıyla oluşturuldu.";
        public static readonly string StudentDeletedSuccessfully = "Öğrenci başarıyla silindi.";
        public static readonly string StudentUpdatedSuccessfully = "Öğrenci başarıyla güncellendi.";

        public static readonly string SchoolCreatedSuccessfully = "Okul başarıyla oluşturuldu.";
        public static readonly string SchoolDeletedSuccessfully = "Okul başarıyla silindi.";
        public static readonly string SchoolUpdatedSuccessfully = "Okul başarıyla güncellendi.";
        
        public static readonly string SysAdminCreatedSuccessfully = "Sistem yöneticisi başarıyla oluşturuldu.";
        public static readonly string SysAdminDeletedSuccessfully = "Sistem yöneticisi başarıyla silindi.";
        public static readonly string SysAdminUpdatedSuccessfully = "Sistem yöneticisi başarıyla güncellendi.";

        public static readonly string SchAdminCreatedSuccessfully = "Okul yöneticisi başarıyla oluşturuldu.";
        public static readonly string SchAdminUpdatedSuccessfully = "Okul yöneticisi başarıyla silindi.";
        public static readonly string SchAdminDeletedSuccessfully = "Okul yöneticisi başarıyla güncellendi.";

        public static readonly string PostCreatedSuccessfully = "Gönderi başarıyla oluşturuldu.";
        public static readonly string PostDeletedSuccessfully = "Gönderi başarıyla silindi.";
        public static readonly string PostUpdatedSuccessfully = "Gönderi başarıyla güncellendi.";

        public static readonly string ReportCreatedSuccessfully = "Rapor başarıyla oluşturuldu.";
        public static readonly string ReportDeletedSuccessfully = "Rapor başarıyla silindi.";
        public static readonly string ReportUpdatedSuccessfully = "Rapor başarıyla güncellendi.";

        public static readonly string UserOperationClaimAdded = "Kullanıcı operation claimi başarıyla oluşturuldu.";
        public static readonly string UserOperationClaimDeleted = "Kullanıcı operation claimi başarıyla silindi.";
        public static readonly string UserOperationClaimUpdated = "Kullanıcı operation claimi başarıyla güncellendi.";



        // Error Messages

        public static readonly string AuthorizationDenied = "Yetkiniz yok.";

        public static readonly string PasswordError = "Parola hatası.";

        public static readonly string StudentNotFound = "Öğrenci bulunamadı.";
        public static readonly string StudentAlreadyExists = "Öğrenci zaten mevcut.";
        public static readonly string NoStudentDataInDatabase = "Öğrenci tablosunda hiçbir veri bulunamadı.";

        public static readonly string SysAdminNotFound = "Sistem yöneticisi bulunamadı.";
        public static readonly string SysAdminAlreadyExists = "Sistem yöneticisi zaten mevcut.";
        public static readonly string NoSysAdminDataInDatabase = "Sistem yöneticileri tablosunda hiçbir veri bulunamadı.";

        public static readonly string UserOperationClaimNotFound = "Kullanıcı operation claimi bulunamadı.";
        public static readonly string UserOperationClaimAlreadyExists = "Kullanıcı operation claimi zaten mevcut.";

        public static readonly string SchAdminNotFound = "Okul yöneticisi bulunamadı.";
        public static readonly string SchAdminAlreadyExists = "Okul yöneticisi zaten mevcut";
        public static readonly string NoSchAdminDataInDatabase = "Okul yöneticileri tablosunda hiçbir veri bulunamadı.";


        // Validation Error Messages

        public static readonly string ClassIdCantBeEmpty = "Sınıf Id'si boş olamaz.";

        public static readonly string SchoolIdCantBeEmpty = "Okul Id'si boş olamaz.";

        public static readonly string SchoolNumberCantBeEmpty = "Okul numarası boş olamaz.";

        public static readonly string NationalIdentityNumberMustBeElevenCharacters = "TC kimlik numarası 11 haneden oluşmalıdır.";
        public static readonly string NationalIdentityNumberCantBeEmpty = "TC kimlik numarası boş olamaz.";

        public static readonly string NameCantBeEmpty = "Ad boş olamaz.";
        public static readonly string NameTooShort = "Ad çok kısa.";
        public static readonly string NameTooLong = "Ad çok uzun";
    }
}
