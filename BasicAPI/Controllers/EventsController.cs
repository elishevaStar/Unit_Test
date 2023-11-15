using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
       private readonly IDataContext _dataContext; 
        
        public EventsController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
    
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _dataContext.Events;
        }

        //GET api/<EventsController>/5
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            var ev = _dataContext.Events.Find(e => e.Id == id);
            if (ev == null)
                return NotFound();
            return Ok(ev);
        }

        // POST api/<EventsController>
        [HttpPost]
        public ActionResult Post([FromBody] Event eve)
        {
            _dataContext.Events.Add(new Event { Id =1, Title = eve.Title, start = eve.start });
            return Ok();
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event eve)
        {
            var ev = _dataContext.Events.Find(e => e.Id == id);
            if (ev == null)
                return NotFound();
            
                ev.Title = eve.Title;
                ev.start = eve.start;
                ev.end = eve.end;
            return Ok();
            
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var eve = _dataContext.Events.Find(e => e.Id == id);
            if (eve == null)
                return NotFound();
            _dataContext.Events.Remove(eve);
            return Ok();

        }
    }
}
