using AutoMapper;
using Tasty_Talks_BackEnd.Model.Domian;
using Tasty_Talks_BackEnd.Model.DTO;

namespace Tasty_Talks_BackEnd.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shop, AddShopsDTO>().ReverseMap();
            CreateMap<User, AddUserDTO>().ReverseMap();
            CreateMap<Shop, ShopsDTO>().ReverseMap();
            CreateMap<User, UsersDTO>().ReverseMap();
            CreateMap<Shop, UpdateShopDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<FoodCategory, AddFoodCategoryDTO>().ReverseMap();
            CreateMap<FoodCategory, FoodCategoryDTO>().ReverseMap();
            CreateMap<FoodCategory, UpdateFoodCategoryDTO>().ReverseMap();
            CreateMap<Food, AddFoodDTO>().ReverseMap();
            CreateMap<Food, FoodDTO>().ReverseMap();
            CreateMap<Food, UpdateFoodDTO>().ReverseMap();
            CreateMap<Order,  AddOrderDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
        }
    }
}
