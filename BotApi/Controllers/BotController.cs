using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController:ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ITelegram telegram;

        public BotController(IConfiguration configuration, ITelegram telegram)
        {
            this.configuration = configuration;
            this.telegram = telegram;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
           await telegram.RecibirUptates(update);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get(string Mensaje, int IdChat)
        {
            await telegram.EnviarMensajes(Mensaje, IdChat);
            return Ok();
        }

      

    }
}
