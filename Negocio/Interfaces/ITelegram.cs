using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Negocio.Interfaces
{
    public interface ITelegram
    {
        Task EnviarMensajes(string Mensaje, int chatId);
        Task RecibirUptates(Update update);
    }
}
