using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MagicalPsychics.Models
{
    public class User:IUser
    {
        public User(string name, string photo)
        {
            this.Name = name;
            this.Photo = photo;
            this.Puzzles = new List<int>();
        }
        // Имя
        public string Name { get; set; }
        // Фото
        public string Photo { get; set; }
        // Загадка
        public int Puzzle { get; set; }
        // Загадки
        private List<int> Puzzles;
        // Сделать загадку
        public void PuzzleMake(int puzzle)
        {
            Puzzles.Add(puzzle);
        }
        // История загадок
        public List<int> PuzzleHistory
        {
            get { return Puzzles; }
        }
    }
}