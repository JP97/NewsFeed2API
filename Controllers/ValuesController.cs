using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewsFeed2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        int i;
        private readonly NewsContext _context;
        public ValuesController(NewsContext context)
        {
            // i++;
             _context = context;

            List<News> newsList = new List<News>()
            {
                new News{
                Title = "Overskrift",
                Author = "Simon",
                Content = "Indhold",
                CreatedDate = DateTime.Now.AddDays(-4),
                UpdatedDate = DateTime.Now,
                HashTags = "#SimonErGud;#FedOpgave" },

                new News{
                Title = "Bob er syg!",
                Author = "julianbulian",
                Content = "han er så syg",
                CreatedDate = DateTime.Now.AddDays(-3),
                UpdatedDate = DateTime.Now,
                HashTags = "#FuckingSyg;#MorgenHår;#Dabtastic;#ForhåbentligRaskIgenSnart" },

                new News{
                Title = "Bob er rask!",
                Author = "julianbulian",
                Content = "Han er så rask!",
                CreatedDate = DateTime.Now.AddDays(-2),
                UpdatedDate = DateTime.Now,
                HashTags = "#FuckingRask;#Yay;#NearDeathExperience" },

                new News{
                Title = "Bob er syg, igen!",
                Author = "julianbulian",
                Content = "Bob var aldrig rask!",
                CreatedDate = DateTime.Now.AddDays(-1),
                UpdatedDate = DateTime.Now,
                HashTags = "#FuckMyLife;#Testamente;#ErDerFlereHashTags?;#HashTagHashTags" },

            };
        //}
            //{
            //    Title = "Overskrift",
            //    Author = "Simon",
            //    Content = "Indhold",
            //    CreatedDate = DateTime.Now.AddDays(-1),
            //    UpdatedDate = DateTime.Now,
            //    HashTags = "#SimonErGud;#FedOpgave"
            //};
            _context.AddRange(newsList);
            _context.SaveChanges();

        }
      

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<News>> Get()
        {
            List<News> newsList = _context.news.ToList();
            return newsList;
        }

        // GET api/values/5
        [HttpGet("from/{startYear}/{startMonth}/to/{endYear}/{endMonth}")]
        public ActionResult<List<News>> Get(int startYear, int startMonth, int endYear, int endMonth)
        {
            DateTime dt1 = new DateTime(startYear, startMonth, 0);
            DateTime dt2 = new DateTime(endYear, endMonth, 0);


             List<News> newsList = _context.news.Where(x => x.CreatedDate<= dt1 && x.CreatedDate>=dt2).ToList();
            return newsList;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
