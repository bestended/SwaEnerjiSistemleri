using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaEnerjiSistemleri.Models;

namespace SwaEnerjiSistemleri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirlerController : ControllerBase
    {

        public readonly ApplicationDbContext db;

        public SehirlerController(ApplicationDbContext db)
        {
            this.db = db;
        }



        [HttpGet]
        [Route("GetSehir")]
        public async Task<IEnumerable<Sehirler>> GetSehir()
        {
            return await db.Sehirlers.ToListAsync();


        }

        [HttpPost]
        [Route("PostSehir")]
        public async Task<Sehirler> PostSehir(Sehirler sehir)
        {

            db.Add(sehir);
            await db.SaveChangesAsync();
            return sehir;


        }

        [HttpPut]
        [Route("PutSehir/{id}")]
        public async Task<Sehirler> PutSehir(Sehirler sehir)
        {

            db.Update(sehir);
            await db.SaveChangesAsync();
            return sehir;

        }


        [HttpDelete]
        [Route("DelSehir/{id}")]
        public bool DelSehir(int id)
        {
            bool islem = false;
            var result = db.Sehirlers.Find(id);
            if (result != null)
            {
                islem = true;
                db.Remove(result);
                db.SaveChanges();

            }
            else
            {
                return false;
            }


            return islem;

        }



    }
}
