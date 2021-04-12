using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;

namespace MagicalPsychics.Models
{
    public class Psychic: IPsychic
    {
        // Имя
        public string Name { get; set; }
        // Фото
        public string Photo { get; set; }
        //Догадки
        private List<Guess> Guesses;
        //Догадка
        private int guess;

        public Psychic(string name, string photo)
        {
            this.Name = name;
            this.Photo = photo;
            this.Guesses = new List<Guess>();
        }
        // Подумать
        public void GuessInit() {
            guess = 0;
        }
        //Сделать догадку
        public bool GuessMake(Random rnd)
        {
            bool readyGuessMake = rnd.Next(1, 100) > 50;
            if (readyGuessMake)
                if (rnd.Next(1, 100) > 50)
                    guess = rnd.Next(11, 99);
                else
                    guess = -rnd.Next(11, 99);
            else
                guess = 0;
            return readyGuessMake;
        }
        // Проверить догадку
        public bool GuessCheck(int puzzle)
        {
            bool right = guess == puzzle;
            Guesses.Add(new Guess { Value = guess, Right = right });
            return right;
        }
        // История догадок
        public List<Guess> GuessHistory
        {
            get { return Guesses; }
        }
        // Текущее значение достоверности
        public int Reliability
        {
            get {
                int ok = Guesses.Where(o => o.Right).Count();
                return Guesses.Count > 0 ? (100 * ok) / Guesses.Count : 0;
            }
        }
        //Ответ
        public int Guess 
        {
            get { return guess; }
        }
    }
}
