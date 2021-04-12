using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicalPsychics.Models
{
    public interface IPsychic
    {
        // Имя
        string Name { get; set; }
        // Фото
        string Photo { get; set; }
        // Подумать
        void GuessInit();

        // Сделать догадку
        bool GuessMake(Random rnd);

        // Проверить догадку
        bool GuessCheck(int puzzle);

        // История догадок
        List<Guess> GuessHistory { get; }

        // Текущее значение достоверности
        int Reliability{ get; }
        //Ответ
        int Guess { get;}
    }
}