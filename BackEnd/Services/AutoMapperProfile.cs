using AutoMapper;
using Domain;
using Services.DataTransferObjects;

namespace Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // general models
            //


            // domain models
            //
            CreateMap<UserView, User>(MemberList.Source);
            CreateMap<User, UserView>(MemberList.Destination);
            CreateMap<Role, RoleView>(MemberList.Source);
            CreateMap<RoleView, Role>(MemberList.Destination);

        }
    }
}
