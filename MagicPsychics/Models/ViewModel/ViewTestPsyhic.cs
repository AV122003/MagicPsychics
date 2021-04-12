using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;

namespace MagicalPsychics.Models
{
    public class ViewTestPsyhic
    {
        ////Состояние
        public bool WaitPuzzle;
        // Список экстрасенсов
        public List<Psychic> PsychicList;
        // Пользователь
        public User User;
    }
}