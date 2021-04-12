using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicalPsychics.Models
{
    public interface IUser
    {
        // Имя
        string Name { get; set; }
        // Фото
        string Photo { get; set; }
        //Загадка
        int Puzzle { get; set; }
        // Сделать загадку
        void PuzzleMake(int puzzle);
        // История загадок
        List<int> PuzzleHistory { get; }

    }
}