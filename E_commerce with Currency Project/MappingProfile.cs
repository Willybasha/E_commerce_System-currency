using AutoMapper;
using E_commerce_System_currency.Models;
using E_commerce_System_currency.Services.DTOs;

namespace E_commerce_System_currency
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<RegisterModelDto,Customer>().ReverseMap();

            CreateMap<AddItemDto,Item>().ReverseMap();

            CreateMap<Item,OutPutItemDto>().ReverseMap();

            CreateMap<UpdateItemDto, Item>().ReverseMap();

            CreateMap<Order, OutPutOrderDto>().ReverseMap();

            
        }
    }
}
