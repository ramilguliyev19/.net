using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services;
using DAL.Abstracts;
using DAL.Models;

namespace Business.Implementations
{
    public class ProductRepository: IProductService
    {
        private readonly IProductDal _productRepository;

        public ProductRepository(IProductDal productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException();
            }

            var data = await _productRepository.GetAsync(n => n.Id == id);

            if (data is null)
            {
                throw new NullReferenceException();
            }

            return data;
        }

        public async Task<List<Product>> GetAll()
        {
            var data = await _productRepository.GetAllAsync();
            if (data is null)
            {
                throw new NullReferenceException();
            }
            
            return data;
        }

        public Task Create(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delte(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}