using System.Runtime.Serialization;

namespace Services.DataTransferObjects
{
    public class UserView
    {
        [DataMember]
        public string UserviewId { get; set; }
        public string Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string ConfirmPassword { get; set; }

        [DataMember]
        public string AccessToken { get; set; }

    }
}

