using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicalPsychics.Models
{
    interface ITestPsyhics
    {
        //Состояние теста
        bool PuzzleWait { get;}
        // Список экстрасенсов
        List<Psychic> PsychicList { get; }
        // Пользователь
        User User { get; }

        // Опрос экстрасенсов
        void GuessMake();
        // Проверить прогноз
        void GuessCheck(int puzzle);
        // Количество угадавших
        int GuessSuccessNumber { get; }
    }
}