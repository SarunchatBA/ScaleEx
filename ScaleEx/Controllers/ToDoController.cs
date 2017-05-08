using ScaleEx.Filter;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

namespace ScaleEx.Controllers
{
    [RoutePrefix("api/todo")]
    public class ToDoController : ApiController
    {
        [HttpGet]
        // GET api/<controller>
        [ResponseType(typeof(IEnumerable<List<ToDo>>))]
        public IHttpActionResult Get()
        {
            return Ok(new ToDoEntities().ToDoData);
        }
        [HttpGet]
        // GET api/<controller>/5
        [ResponseType(typeof(IEnumerable<ToDo>))]
        public IHttpActionResult Get(int id)
        {
            var result = new ToDoEntities().ToDoData.Where(d => d.Id == id).SingleOrDefault();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        // POST api/<controller>
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody]InputData input)
        {
            using (var db= new ToDoEntities())
            {
                db.ToDoData.Add(new ToDo { Detail = input.Content, Subject = input.Subject, Status= input.Status });
                db.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        // PUT api/<controller>/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody]InputData input)
        {
            using (var db = new ToDoEntities())
            {
                var entity = db.ToDoData.Find(id);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.Detail = input.Content;
                entity.Subject = input.Subject;
                entity.Status = input.Status;
                db.SaveChanges();
                return Ok();
            }
        }
        [HttpPatch]
        // PUT api/<controller>/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Patch(int id, [FromBody]InputStaus input)
        {
            using (var db = new ToDoEntities())
            {
                var entity = db.ToDoData.Find(id);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.Status = input.Status;
                db.SaveChanges();
                return Ok();
            } 
        }
        [HttpDelete]
        // DELETE api/<controller>/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            using (var db = new ToDoEntities())
            {
               ToDo result= db.ToDoData.Find(id);
                if(result == null)
                {
                   return NotFound();
                }

                db.ToDoData.Remove(result);
                db.SaveChanges();
                return Ok();
            }
        }
    }
    public class InputData
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }
        public bool Status { get; set; }
    }
    public class InputStaus
    {
        [Required]
        public bool Status { get; set; }
    }
}