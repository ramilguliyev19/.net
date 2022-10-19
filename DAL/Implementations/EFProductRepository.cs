using Core.EFRepository.EFEntityRepository;
using DAL.Abstracts;
using DAL.Data;
using DAL.Models;

namespace DAL.Implementations
{
    public class EFProductRepository: EFEntityRepository<Product,AppDbContext>, IProductDal
    {
        public EFProductRepository(AppDbContext context):base(context)
        {
            
        }
    }
}