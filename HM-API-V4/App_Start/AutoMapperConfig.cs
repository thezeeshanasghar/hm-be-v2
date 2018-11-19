using AutoMapper;
using HM_API_V4.Models;
using HM_API_V4.Models.Custom;

namespace HM_API_V4
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Account, AccountDTO>().ReverseMap();
                config.CreateMap<Transaction, TransactionDTO>().ReverseMap();
                config.CreateMap<TrasanctionWithSmsSatus, TransactionDTO>().ReverseMap();
                config.CreateMap<Car, CarDTO>().ReverseMap();
            });
        }
    }
}
