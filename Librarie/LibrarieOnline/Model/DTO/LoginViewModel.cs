using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibrarieOnline.Models.DTO
{
    public class LoginViewModel
    {
        private string _userName;
        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required/")]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        private string _password;
        public string Password
        {
            get => _password;
            set => _password = value;
        }

    }
}