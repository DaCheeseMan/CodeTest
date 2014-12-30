using CodeTest.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CodeTest.Web.Api.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ICodeTestUow Uow { get; set; }
    }
}