using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CodingAssessment.Models;

namespace CodingAssessment.Controllers
{
    [Route("api/[controller]")]
    public class OutputMessageController : Controller
    {
        private readonly OutputMessageContext _context;

        public OutputMessageController(OutputMessageContext context)
        {
            _context = context;

            if (_context.OutputMessageItems.Count() == 0)
            {
                _context.OutputMessageItems.Add(new OutputMessageItem { Message = "Hello World" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public List<OutputMessageItem> GetAll()
        {
            return _context.OutputMessageItems.ToList();
        }

        [HttpGet("{id}", Name = "GetOutputMessage")]
        public IActionResult GetById(long id)
        {
            var item = _context.OutputMessageItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OutputMessageItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.OutputMessageItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetOutputMessage", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] OutputMessageItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var OutputMessage = _context.OutputMessageItems.Find(id);
            if (OutputMessage == null)
            {
                return NotFound();
            }
            
            OutputMessage.Message = item.Message;

            _context.OutputMessageItems.Update(OutputMessage);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var OutputMessage = _context.OutputMessageItems.Find(id);
            if (OutputMessage == null)
            {
                return NotFound();
            }

            _context.OutputMessageItems.Remove(OutputMessage);
            _context.SaveChanges();
            return NoContent();
        }

    }
}