using AutoMapper;
using Tasty_Talks_BackEnd.Model.Domian;
using Tasty_Talks_BackEnd.Model.DTO;

namespace Tasty_Talks_BackEnd.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shops, AddShopsDTO>().ReverseMap();
            CreateMap<Users, AddUserDTO>().ReverseMap();   
        }
    }
}
