using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : BaseEntityController<Document, string>
    {
        public DocumentsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
