using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwaEnerjiSistemleri.Models;

namespace SwaEnerjiSistemleri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuketicilerController : ControllerBase
    {

        public readonly ApplicationDbContext db;

        public TuketicilerController(ApplicationDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        [Route("GetTuketici")]
        public async Task<IEnumerable<Tuketiciler>> GetTuketici()
        {


            return await db.Tuketicilers.ToListAsync();


        }


        [HttpPost]
        [Route("PostTuketici")]
        public async Task<Tuketiciler> PostTuketici(Tuketiciler tuketici)
        {

            db.Add(tuketici);
            await db.SaveChangesAsync();
            return tuketici;


        }



        [HttpPut]
        [Route("PutTuketici/{id}")]
        public async Task<Tuketiciler> PutTuketici(Tuketiciler tuketici)
        {
            db.Update(tuketici);
            await db.SaveChangesAsync();
            return tuketici;


        }


        [HttpDelete]
        [Route("DelTuketici/{id}")]
        public bool DelTuketici(int id)
        {
            bool islem = false;
            var result = db.Tuketicilers.Find(id);

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
