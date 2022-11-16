using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemListaController : ControllerBase
    {
        private readonly IItemListaService _itemListaService;
        public ItemListaController()
        {
            _itemListaService = new ItemListaService();
        }
    }
}
