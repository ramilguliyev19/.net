using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services;
using DAL.Abstracts;
using DAL.Models;

namespace Business.Implementations
{
    public class HeroRepository : IHeroService
    {
        private readonly IHeroDal _heroRepository;

        public HeroRepository(IHeroDal heroRepository)
        {
            _heroRepository = heroRepository;
        }
        public async Task<Hero> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException();
            }

            var data = await _heroRepository.GetAsync(hero => hero.Id == id);
            
            if (data is null)
            {
                throw new NullReferenceException();
            }

            return data;
        }

        public async Task<List<Hero>> GetAll()
        {
            var data = await _heroRepository.GetAllAsync(hero => !hero.IsDelted);
            if (data is null)
            {
                throw new NullReferenceException();
            }

            return data;
        }

        public async Task Create(Hero entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            await _heroRepository.AddAsync(entity);
        }

        public async Task Update(Hero entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            
            entity.UpdatedDate = DateTime.Now;
            await _heroRepository.UpdateAsync(entity);
        }

        public async Task Delte(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException();
            }

            var data = await Get(id);
            if (data is null)
            {
                throw new NullReferenceException();
            }
            
            await _heroRepository.DeleteAsync(data);
        }
    }
}