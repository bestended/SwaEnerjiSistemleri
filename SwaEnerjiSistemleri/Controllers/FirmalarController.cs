using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaEnerjiSistemleri.Models;

namespace SwaEnerjiSistemleri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmalarController : ControllerBase
    {

        public readonly ApplicationDbContext db;

        public FirmalarController(ApplicationDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        [Route("GetFirmalar")]
        public async Task<IEnumerable<Firmalar>> GetFirmalar()
        {
           return await db.Firmalars.ToListAsync();


        }



        [HttpPost]
        [Route("PostFirma")]
        public async Task<Firmalar> PostFirma(Firmalar firma)
        {
            db.Add(firma);
            await db.SaveChangesAsync();
            return firma;

        }





        [HttpPut]
        [Route("PutFirma/{id}")]
        public async Task<Firmalar> PutFirma(Firmalar firma)
        {

            db.Update(firma);
            await db.SaveChangesAsync();
            return firma;


        }



        [HttpDelete]
        [Route("DelFirma/{id}")]
        public bool DelFirma(int id)
        {
            bool islem = false;
            var sonuc = db.Firmalars.Find(id);

            if (sonuc != null)
            {

                islem = true;
                db.Remove(sonuc);
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
