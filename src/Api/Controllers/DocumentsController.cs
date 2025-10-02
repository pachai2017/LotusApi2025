using LotusFive.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotusFive.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : BaseEntityController<Document, string>
    {
        public DocumentsController(IMediator mediator, ILogger<BaseEntityController<Document, string>> logger) : base(mediator, logger)
        {
        }
    }
}
