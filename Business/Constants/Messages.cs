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

        public static readonly string PostNotFound = "Gönderi bulunamadı.";
        public static readonly string NoPostDataInDatabase = "Gönderi tablosunda hiçbir veri bulunamadı.";

        public static readonly string ReportNotFound = "Rapor bulunamadı.";
        public static readonly string NoReportDataInDatabase = "Raporlar tablosunda hiçbir veri bulunamadı.";


        // Validation Error Messages

        public static readonly string ClassIdCantBeEmpty = "Sınıf Id'si boş olamaz.";

        public static readonly string SchoolNumberCantBeEmpty = "Okul numarası boş olamaz.";

        public static readonly string NationalIdentityNumberMustBeElevenCharacters = "TC kimlik numarası 11 haneden oluşmalıdır.";
        public static readonly string NationalIdentityNumberCantBeEmpty = "TC kimlik numarası boş olamaz.";

        public static string StatusCantBeEmpty = "Statü boş olamaz.";

        public static string UsernameCantBeEmpty = "Kullanıcı adı boş olamaz.";
        public static string UsernameTooShort = "Kullanıcı adı çok kısa.";

        public static string PasswordCantBeEmpty = "Parola boş olamaz.";
        public static string PasswordTooShort = "Parola çok kısa.";
        public static string UsernameTooLong = "Kullanıcı adı çok uzun";
        public static string PasswordTooLong = "Parola çok uzun.";

        public static string FirstNameCantBeEmpty = "Ad boş olamaz.";
        public static string FirstNameTooShort = "Ad en az 2 karakterden oluşmalıdır.";
        public static string FirstNameTooLong = "Ad en fazla 50 karakterden oluşmalıdır.";

        public static string LastNameCantBeEmpty = "Soyad boş olamaz.";
        public static string LastNameTooShort = "Soyad çok kısa.";
        public static string LastNameTooLong = "Soyad çok uzun.";

        public static string TypeIdCantBeEmpty = "Tip Id'si boş olamaz.";

        public static string StudentIdCantBeEmpty = "Öğrenci Id'si boş olamaz.";

        public static string TitleCantBeEmpty = "Başlık boş olamaz.";
        public static string TitleTooShort = "Başlık çok kısa.";
        public static string TitleTooLong = "Başlık çok uzun.";

        public static string IsRepliedByAdminCantBeEmpty = "IsRepliedByAdmin alanı boş olamaz.";

        public static string IsSolvedCantBeEmpty = "IsSolved alanı boş olamaz.";

        public static string CreationDateCantBeEmpty = "Oluşturulma tarihi boş olamaz.";

        public static string NameCantBeEmpty = "Ad boş olamaz.";

        public static string PostIdCantBeEmpty = "Gönderi Id'si boş olamaz.";

        public static string UserIdCantBeEmpty = "Kullanıcı Id'si boş olamaz.";

        public static string IsFromStudentCantBeEmpty = "IsFromStudent alanı boş olamaz.";

        public static string MessageCantBeEmpty = "Mesaj alanı boş olamaz.";
        public static string MessageTooShort = "Mesaj çok kısa.";
        public static string MessageTooLong = "Mesaj çok uzun.";
    }
}
