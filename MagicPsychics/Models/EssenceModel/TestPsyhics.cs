using System;
using System.Collections.Generic;
using System.Linq;



namespace MagicalPsychics.Models
{
    public class TestPsyhics: ITestPsyhics
    {
        int nPsychic;
        int nPsychicMaxAnswer;
        int nGuessSuccess;
        Random rnd;

        bool puzzleWait;
        List<Psychic> psychics;
        User user;

        // Инициализация
        public TestPsyhics(int nPsychicMaxAnswer, List<Psychic> psychics, User user)
        {
            puzzleWait = true; 
            this.nPsychic = psychics.Count;
            this.nPsychicMaxAnswer = psychics.Count > nPsychicMaxAnswer ? nPsychicMaxAnswer : psychics.Count;
            this.psychics = new List<Psychic>();
            this.nGuessSuccess = 0;

            foreach (Psychic psychic in psychics)
            {
                this.psychics.Add(psychic);
            }

            this.user = user;

            rnd = new Random();
        }
        //Состояние теста
        public bool PuzzleWait
        {
            get { return puzzleWait; }
        }
        // Список экстрасенсов
        public List<Psychic> PsychicList
        {
            get { return psychics; }
        }
        // Пользователь
        public User User
        {
            get { return user; }
        }
        // Опрос экстрасенсов
        public void GuessMake()
        {
            // Всем подумать
            for (int j = 0; j < psychics.Count; j++)
                psychics[j].GuessInit();
            // Текущее количество отвечающих
            int nPsychicAnswer = rnd.Next(nPsychicMaxAnswer, nPsychic);
            // Отвечают
            int i = 0;
            while (i < nPsychicAnswer)
            {
                for (int j = 0; j < psychics.Count; j++)
                {
                    //отвечают не ответившие ранее
                    if (psychics[j].Guess ==0 && psychics[j].GuessMake(rnd))
                    {
                        i++;
                        break;
                    }
                }
            }

            puzzleWait = false;
        }
        // Проверить прогноз
        public void GuessCheck(int puzzle)
        {
            user.PuzzleMake(puzzle);
            nGuessSuccess = 0;
            foreach (IPsychic psychic in psychics.Where(o => o.Guess != 0))
            {
                if (psychic.GuessCheck(puzzle))
                    nGuessSuccess++;
            }

            puzzleWait = true;
        }
        //Количество угадавших
        public int GuessSuccessNumber
        {
            get { return nGuessSuccess; }
        }
    }
}