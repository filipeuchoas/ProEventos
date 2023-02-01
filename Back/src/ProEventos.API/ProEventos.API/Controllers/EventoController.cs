using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento() {
                EventoId = 1,
                Tema = "Angular 11 e >Net 5",
                Local = "São Paulo",
                QtdPessoas = 250,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "foto.png"
            },
            new Evento() {
                EventoId = 2,
                Tema = "Angular 11 e >Net 5",
                Local = "São Paulo - Diadema",
                QtdPessoas = 350,
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                ImagemURL = "foto1.png"
            }
        };
        public EventoController() { }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id)
        {
            return _evento.Where(x => x.EventoId == id);
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
