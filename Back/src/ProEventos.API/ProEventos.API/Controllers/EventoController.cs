using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using ProEventos.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;
        public EventoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return _context.Eventos.FirstOrDefault(x => x.EventoId == id);
        }

        //[HttpPost]
        //public string Post()
        //{
        //    return $"";
        //}

        //[HttpPut]
        //public string Put(int id)
        //{
        //    return $"";
        //}

        //[HttpDelete]
        //public string Delete(int id)
        //{
        //    return $"";
        //}
    }
}
