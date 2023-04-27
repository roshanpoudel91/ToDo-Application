using System.Runtime.Serialization;

namespace Services.DataTransferObjects
{
    public class RoleView
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}

