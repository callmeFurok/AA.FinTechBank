using AA.FinTechBank.Domain.Dto;
using AA.FinTechBank.Domain.Entities;
using AutoMapper;

namespace AA.FinTechBank.Common.Utils
{
    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateUserDto,EApplicationUser>().ReverseMap();
            CreateMap<CreateClientDto,EClient>().ReverseMap();
        }
    }
}
