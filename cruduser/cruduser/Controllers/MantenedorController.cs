using Microsoft.AspNetCore.Mvc;
using cruduser.datos;
using cruduser.Models;

namespace cruduser.Controllers
{
    public class MantenedorController : Controller
    {
        userDatos _userDatos = new userDatos();
        public IActionResult listar()
        {
            var lista = _userDatos.listar();
            return View(lista);
        }
        [HttpPost]
        public IActionResult guardar( UsuarioModel usario)
        {
            var res = _userDatos.crear(usario);
            if (res)
            {
               return RedirectToAction("listar");
            }
            else
            {
                return View();
            }
            
        }
        public IActionResult guardar()
        {
                return View();
        }

      
        public IActionResult editar(int id)
        {
            var usuario = _userDatos.obtenerUsuario(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult editar(UsuarioModel usuario)
        {

            var res = _userDatos.editar(usuario);
            if (res)
            {
                return RedirectToAction("listar");
            }
            else
            {
                return View();
            }
        }
        public IActionResult eliminar(int id)
        {
            var usuario = _userDatos.obtenerUsuario(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult eliminar(UsuarioModel usuario)
        {

            var res = _userDatos.eliminar(usuario.id);
            if (res)
            {
                return RedirectToAction("listar");
            }
            else
            {
                return View();
            }
        }
    }
}
