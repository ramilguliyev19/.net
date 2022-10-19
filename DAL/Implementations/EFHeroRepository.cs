using Core.EFRepository.EFEntityRepository;
using DAL.Abstracts;
using DAL.Data;
using DAL.Models;

namespace DAL.Implementations
{
    public class EFHeroRepository: EFEntityRepository<Hero,AppDbContext>, IHeroDal
    {
        public EFHeroRepository(AppDbContext context):base(context)
        {
            
        }
    }
}