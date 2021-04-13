using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using artist.Services;
using artist.Model;
using System;
using painting.Services;
using artist.Models;

namespace artist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaintingsController : ControllerBase
    {
        private readonly PaintingsService _service;

        public PaintingsController(PaintingsService service)
        {
            _service = service;
        }

        [HttpGet]  // GETALL
        public ActionResult<IEnumerable<Painting>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")] // GETBYID
        public ActionResult<Painting> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost] // POST
        public ActionResult<Painting> Create([FromBody] Painting newPainting)
        {
            try
            {
                return Ok(_service.Create(newPainting));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")] // PUT
        public ActionResult<Painting> Edit([FromBody] Painting editPainting, int id)
        {
            try
            {
                editPainting.Id = id;
                return Ok(_service.Edit(editPainting));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")] // DELETE
        public ActionResult<Painting> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}