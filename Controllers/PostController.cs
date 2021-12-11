using Hoviedo.Api.Blog.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hoviedo.Api.Blog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : Controller
    {

        // GET: api/<postController>
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAllDireccion()
        {
            if (DbContext.ListaPost.Any())
                return Ok(DbContext.ListaPost);
            else
                return NoContent();
            return DbContext.ListaPost;
        }

        // GET <PostController>/
        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {
            if (DbContext.ListaPost.Any(p => p.Id == id))
                return Ok(DbContext.ListaPost.FirstOrDefault(p => p.Id == id));
            else
                return NoContent();

          
        }
        /*
        // GET <PostController>/
        [HttpGet("{title}")]
        public ActionResult<Post> Get(String title)
        {
            
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException($"'{nameof(title)}' no puede ser nulo ni estar vacío.", nameof(title));
            }
            if (DbContext.ListaPost.Any(p => p.Title == title))
                return Ok(DbContext.ListaPost.FirstOrDefault(p => p.Title == title));
            else
                return NoContent();

          
        }   */

        /*
        // GET <PostController>/
        [HttpGet("{body}")]
        public ActionResult<Post> GetAction(string body)
        {
            if (string.IsNullOrEmpty(body))
            {
                throw new ArgumentException($"'{nameof(body)}' no puede ser nulo ni estar vacío.", nameof(body));
            }

            if (DbContext.ListaPost.Any(p => p.Body == body))
                return Ok(DbContext.ListaPost.FirstOrDefault(p => p.Body == body));
            else
                return NoContent();       
        }
            */
      
       // POST <PostController>
       [HttpPost("{id}")]
        public IActionResult Post([FromBody] Post value)
        {
            if (!DbContext.ListaPost.Any(p => p.Id == value.Id))
            {
                DbContext.ListaPost.Add(value);
                return Ok();
            }
            else
            {
                return BadRequest($"Exists a post with id {value.Id}");
            }
        }


        // PUT: PostController/Edit/
        [HttpPut("{id}")]

        public ActionResult Edit(int id, [FromBody] Post value)
        {
            var PostToUpdate = DbContext.ListaPost.Single(p => p.Id == id);
            DbContext.ListaPost.Remove(PostToUpdate);
            DbContext.ListaPost.Add(value);
            return View();
        }


        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: PostController/Delete/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var PostToDelete = DbContext.ListaPost.Single(p => p.Id == id);
            DbContext.ListaPost.Remove(PostToDelete);


        }
        /*
        private bool WildcardMatch(String s, String wildcard, bool case_sensitive)
        {
            // Reemplaza % con un .* y el ? con un punto.
            //  poninedo ^ al principio y  $ al final - Así que algo como foo%.xls? se transformará en ^foo.*\.xls.$.
            String pattern = "^" + Regex.Escape(wildcard).Replace(@"\%", ".*").Replace(@"\?", ".") + "$";

            // Now, run the Regex as you already know
            Regex regex;
            if (case_sensitive)
                regex = new Regex(pattern);
            else
                regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return (regex.IsMatch(s));
        }
        */


    }
}
