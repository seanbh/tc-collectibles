using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.Services.Cart.Rest.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<Models.CartForCreation, Entities.Cart>();
            CreateMap<Entities.Cart, Models.Cart>().ReverseMap();
        }
    }
}
