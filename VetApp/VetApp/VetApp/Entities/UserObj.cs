namespace VetApp.Entities
{
    public class UserObj
    {
        public int IdUser { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string UserFirstLastName { get; set; } = string.Empty;
        public string UserSecondLastName { get; set; } = string.Empty;
        public string UserMail { get; set; } = string.Empty;
        public string UserNickName { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public string UserPicture { get; set; } = "";
        public string UserPhoneNumber { get; set; } = string.Empty;
        public int IdRol { get; set; } = 0;
        public string UserIdCard { get; set; } = String.Empty;
        public string RolName { get; set; } = string.Empty;
    }
}
