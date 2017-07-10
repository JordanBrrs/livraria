using Biblios.BL;
using Biblios.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Biblios.Api.Controllers
{
    [RoutePrefix("livros")]
    public class LivroController : ApiController
    {

        [Route("salvarlivro")]
        [HttpPost]
        public HttpResponseMessage SalvarLivros(Livro livro)
        {            
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, LivroBL.SalvarLivro(livro));

            }
            catch (Exception ex)
            {
                if (ex.Message == "Dados Inválidos") {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [Route("deletarlivro")]
        [HttpPost]
        public HttpResponseMessage DeletarLivro(Livro livro)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, LivroBL.DeletarLivro(livro));

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("getlivros")]
        [HttpGet]
        public HttpResponseMessage GetLivros()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, LivroBL.getAllLivros());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
