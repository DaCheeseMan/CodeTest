using CodeTest.Data.Contracts;
using CodeTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CodeTest.Web.Api.Controllers
{
    public class MessageController : ApiControllerBase
    {
        public MessageController(ICodeTestUow uow)
        {
            Uow = uow;
        }
        
        //GET api/message
        public IEnumerable<Message> Get()
        {
            return Uow.Messages.GetAll().OrderBy(x => x.DateCreated);
        }

        //GET api/message/2
        public Message Get(int id)
        {
            return Uow.Messages.GetById(id);
        }

        //PUT api/message        
        [EnableCors("*", "*", "*")]        
        public HttpResponseMessage Post(Message message)
        {
            Uow.Messages.Add(message);
            Uow.Commit();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}

namespace CodeTest.Web.Mvc.Controllers
{
    public class MessageController : MvcControllerBase
    {
        public MessageController()
        {
        }

        //GET message/index
        public ActionResult Index()
        {
            return View();
        }
    }
}