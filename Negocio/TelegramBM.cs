using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Negocio
{
    public class TelegramBM : ITelegram
    {
        private readonly IConfiguration configuration;

        public TelegramBM(IConfiguration configuration )
        {
            this.configuration = configuration;
        }

        public async Task EnviarMensajes(string Mensaje, int chatId)
        {
            string ApiBot = configuration["BotInfo:Bot"];
            var ChatId = chatId;

            TelegramBotClient bot = new TelegramBotClient(ApiBot);
            await bot.SendTextMessageAsync(ChatId, Mensaje);

        }

        public async Task RecibirUptates(Update update)
        {
            string ApiBot = configuration["BotInfo:Bot"];

            TelegramBotClient bot = new TelegramBotClient(ApiBot);

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {

                if (update.Message.Text.Contains("Hola"))
                {
                    await bot.SendTextMessageAsync(update.Message.From.Id, "Hola tambien para ti");
                }


                if (update.Message.Text.Contains("Lluvia"))
                {
                    await bot.SendTextMessageAsync(update.Message.From.Id, "Lluvia");
                } 
                
                
                if (update.Message.Text.ToLower().Contains("photo"))
                {
                    await bot.SendPhotoAsync(
                      chatId: update.Message.From.Id,
                      photo: "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg",
                      caption: "<b>Ara bird</b>. <i>Source</i>: <a href=\"https://pixabay.com\">Pixabay</a>",
                      parseMode: ParseMode.Html
                    );
                }

            }
        }
    }
}
