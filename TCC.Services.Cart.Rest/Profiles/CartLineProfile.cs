using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace TCC.Services.Cart.Rest.Profiles
{
    public class CartLineProfile : Profile
    {
        public CartLineProfile()
        {
            CreateMap<Models.CartLineForCreation, Entities.CartLine>();
            CreateMap<Models.CartLineForUpdate, Entities.CartLine>();
            CreateMap<Entities.CartLine, Models.CartLine>().ReverseMap();
        }
    }
}
