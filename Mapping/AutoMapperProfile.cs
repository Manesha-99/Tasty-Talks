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
            CreateMap<Shops, ShopsDTO>().ReverseMap();
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<Shops, UpdateShopDTO>().ReverseMap();
            CreateMap<Users, UpdateUserDTO>().ReverseMap();
            CreateMap<FoodCategory, AddFoodCategoryDTO>().ReverseMap();
            CreateMap<FoodCategory, FoodCategoryDTO>().ReverseMap();
            CreateMap<FoodCategory, UpdateFoodCategoryDTO>().ReverseMap();
        }
    }
}
