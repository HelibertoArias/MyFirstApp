using System.IO;
using System.Net;
using System.Web.Mvc;

/*
 Links to review
 http://www.dotnettricks.com/learn/mvc/viewdata-vs-viewbag-vs-tempdata-vs-session
 https://www.owasp.org/index.php/.NET_Security_Cheat_Sheet
 @Html.Partial and @Html.RenderPartial are used when your Partial view model is correspondence of parent model, 
 we don't need to create any action method to call this.

@Html.Action and @Html.RenderAction are used when your partial view model are independent 
from parent model, basically it is used when you want to display any widget type content on page. You must create an action method which returns a partial view result while calling the method from view.

 */
namespace MyFirstApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult IndexPasarParametros() {
            ViewBag.Texto = "Este es un texto enviado en ViewBag";
            TempData["Texto"] = "Esto es un texto enviado desde Tempdata";

            ViewBag.Obj = new Dummy() { Id =0, Nombre="Nombre viewbag" };
            TempData["Obj"] = new Dummy() { Id = 0, Nombre = "Nombre tempdata" };

            return View();
        }


        public ActionResult IndexInicial() {
            ViewBag.Testing = "Este ViewBag se agregó en el IndexIncial";
            TempData["Testing"]= "Este TempData se agregó en el IndexIncial";
          

            return RedirectToAction("IndexSecundario");
        }

        public ActionResult IndexSecundario() {
            TempData["Testing"] = TempData["Testing"] + ". y paso por el IndexSecundario";
            ViewData["Testing2"] = "Este ViewData se agregó en el IndexSecundario";
            return View();
        }

        public FileContentResult IndexArchivo()
        {
            var ms = new MemoryStream();
            using (var file = new StreamWriter(ms))
            {
                file.WriteLine("Wrinting in file");
                file.Flush();
                ms.Flush();

                FileContentResult result = new FileContentResult(ms.ToArray() , "application/octet-stream");
                result.FileDownloadName ="MiArchivo.txt"  ;
                return result;
            }
        }


        public ActionResult IndexSinParametro()
        {
            Dummy item = new Dummy() { Id = 123, Nombre = "Testing", Valor = 345 };
            return View(item);
        }

        public ActionResult IndexDefault()
        {
            return View("ViewDefault");
        }

        public ActionResult IndexConAjaxRequest()
        {
            if (Request.IsAjaxRequest())
            {
                return Json(new Dummy() { Id = 1, Nombre = "Dummy 1", Valor = 123 }, JsonRequestBehavior.AllowGet);
            }
            else
                return View();
        }

        public ActionResult IndexConAjaxParameter(int? id)
        {
            if (Request.IsAjaxRequest())
            {
                if (id.HasValue && id.Value > 1)

                    return Json(new Dummy() { Id = id.Value, Nombre = "Dummy 1", Valor = 123 }, JsonRequestBehavior.AllowGet);
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Valor debe ser mayor a 1");
                }
            }
            else
                return View();
        }

        // GET: Home
        // http://localhost:52908/home/AccionSinParametros
        public string AccionSinParametros()
        {
            return "Acción sin parametros";
        }

        /*
         * http://localhost:52908/home/AccionParametroIntId/1
         * http://localhost:52908/home/AccionParametroIntId
         * http://localhost:52908/home/AccionParametroIntId?id=1
         */

        public string AccionParametroIntId(int? id)
        {
            return (id.HasValue) ? "El valor del parametro Id es " + id.Value : "El parametro id es null";
        }

        /*
         * http://localhost:52908/home/AccionParametros?id=1&nombre=dummy&valor=123
         *
         */

        public string AccionParametros(int id, string nombre, int valor)
        {
            return $"Los valores ingresado son: <br/> ID={id} <br/> Nombre={nombre} <br/> Valor={valor}";
        }

        /*
         * http://localhost:52908/home/AccionParametrosObjeto/3?Nombre=Testing&Valor=321&Id=333
         * http://localhost:52908/home/AccionParametrosObjeto?Id=22&Nombre=Testing&Valor=321&Id=333
         */

        public string AccionParametrosObjeto(int id, Dummy item)
        {
            return $"Los valores ingresado son: <br/> ID={item.Id} <br/> Nombre={item.Nombre} <br/> Valor={item.Valor}";
        }

        /*
         * http://localhost:52908/home/AccionParametrosObjetoNoId/1?Nombre=Testing&Valor=321&Id=333
         */

        public string AccionParametrosObjetoNoId(Dummy item)
        {
            return $"Los valores ingresado son: <br/> ID={item.Id} <br/> Nombre={item.Nombre} <br/> Valor={item.Valor}";
        }


        public string IndexGetContentString() {
            return "<br/><br/><b>Esto es el contenido del IndexGetContent</b>";
        }

        public ActionResult IndexGetContentView() {
            return View();
        }


        public ActionResult IndexFormulario()
        {
            return View();
        }


        public ActionResult IndexRazor() {
            return View();
        }


    }

    public class Dummy
    {
        public string Nombre { get; set; }

        public int Valor { get; set; }

        public int Id { get; set; }
    }
}