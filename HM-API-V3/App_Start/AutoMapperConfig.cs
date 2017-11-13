using AutoMapper;

namespace HM_API_V3
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Account, AccountDTO>().ReverseMap();
                config.CreateMap<Transaction, TransactionDTO>().ReverseMap();
            });
        }
    }
}
