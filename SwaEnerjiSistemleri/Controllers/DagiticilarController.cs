using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaEnerjiSistemleri.Models;

namespace SwaEnerjiSistemleri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DagiticilarController : ControllerBase
    {

        public readonly ApplicationDbContext db;

        public DagiticilarController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("GetDagitici")]
        public async Task<IEnumerable<Dagiticilar>> GetDagitici()
        {

            return await db.Dagiticilars.ToListAsync();

        }


        [HttpPost]
        [Route("PostDagitici")]
        public async Task<Dagiticilar> PostDagitici(Dagiticilar dagiticilar)
        {
            db.Add(dagiticilar);
            await db.SaveChangesAsync();

            return dagiticilar;
        }


        [HttpPut]
        [Route("PutDagitici/{id}")]
        public async Task<Dagiticilar> PutDagitici(Dagiticilar dagiticilar)
        {
            db.Update(dagiticilar);
            await db.SaveChangesAsync();
            return dagiticilar;

                



        }



        [HttpDelete]
        [Route("DelDagitici/{id}")]
        public bool DelDagitici(int id)
        {
            bool islem = false;
            var sonuc=db.Dagiticilars.Find(id);

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
