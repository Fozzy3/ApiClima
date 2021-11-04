using Backend.Data;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class UsuarioController : ApiController
    {   
        public List<Usuario> GET()
        {
            return UsuarioData.Listar();
        }

        public List<Inicio> GET()
        {
            return UsuarioData.ListarInicio();
        }
        public bool Post([FromBody] Guardar oGuardar)
        {
            return UsuarioData.Registrar(oGuardar);
        }
    }
}