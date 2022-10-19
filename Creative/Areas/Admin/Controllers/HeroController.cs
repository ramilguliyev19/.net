using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using Common.Helpers;
using Creative.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Creative.Areas.Admin.Controllers
{
    [Authorize]
    public class HeroController : Controller
    {
       
        private readonly IHeroService _heroService;
        private readonly IWebHostEnvironment _env;

        public HeroController(IHeroService heroService,IWebHostEnvironment env)
        {
            _heroService = heroService;
            _env = env;
        }
       
        [HttpGet]
        public async Task<IActionResult> Index(int skip = 0)
        {
            List<Hero> heroes;
            try
            {
                heroes = (await _heroService.GetAll()).Skip(skip).Take(3).ToList();
               
            }
            catch (Exception e)
            {
                return Json(new
                {
                    statusCode= 504,
                    message = e.Message
                });
            }

            HeroVM heroVm = new HeroVM
            {
                heroes = heroes,
                Length = (await _heroService.GetAll()).ToList().Count
            };
            return View(heroVm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Hero hero = new Hero();
            try
            {
                hero = await _heroService.Get(id);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    statusCode= 504,
                    message = e.Message
                });
            }
            return View(hero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Toggle(int id)
        {
            List<Hero> heroes;
            Hero hero = new Hero();
            try
            {
                heroes = await _heroService.GetAll();
                hero = await _heroService.Get(id);
                foreach (var h in heroes)
                {
                    if (h.Id != hero.Id)
                    {
                        h.IsActive = false;
                    }
                    else
                    {
                        h.IsActive = !h.IsActive;
                    }
                    await _heroService.Update(h);
                }
            }
            catch (Exception e)
            {
                return Json(new
                {
                    statusCode= 504,
                    message = e.Message
                });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
           
            Hero hero = new Hero();
            try
            {
                hero = await _heroService.Get(id);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    statusCode= 504,
                    message = e.Message
                });
            }

            return View(hero);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Hero hero)
        {
            if (!ModelState.IsValid)
            {
                return View(hero);
            }
            
            if (hero.ImageFile != null)
            {
                string fileName = await hero.ImageFile.CreateImage("hero",_env.WebRootPath);
                var path = _env.WebRootPath + "/uploads/hero/";
                var data = await _heroService.Get(hero.Id);
                DeleteImage(path, data.ImageUrl);
                hero.ImageUrl = fileName;
            }

            try
            {
                await _heroService.Update(hero);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    statusCode= 504,
                    message = e.Message
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var path = _env.WebRootPath + "/uploads/hero/";
            try
            {
                var data = await _heroService.Get(id);
                DeleteImage(path,data.ImageUrl);
                await _heroService.Delte(id);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    statusCode= 504,
                    message = e.Message
                });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hero hero)
        {
            if (ModelState.IsValid)
            {
                return View(hero);
            }
            
            try
            {
                string fileName = await hero.ImageFile.CreateImage("hero",_env.WebRootPath);
                hero.ImageUrl = fileName;
                await _heroService.Create(hero);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    statusCode= 504,
                    message = e.Message
                });
            }
            return RedirectToAction("Index");
        }


        private void DeleteImage(string dirName,string fileName)
        {
            System.IO.File.Delete(dirName + fileName);
        }
    }
}