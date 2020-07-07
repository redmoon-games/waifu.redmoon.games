using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary.Models
{
    public class RemTeam : Team
    {
        private static string[] _jobs = new string[]
        {
            "Уборка особняка",
            "Удар моргенштерном",
            "Водная магия",
            "Демоническая форма",
        };

        private static string[] _rangs = new string[]
        {
            "Бесславный ",
            "Новичок",
            "Пляжный задира",
            "Икона стиля",
            "Королева Пляжа",
        };

        public RemTeam() : base("Rem Team", _rangs, _jobs)
        {

        }
    }
}
