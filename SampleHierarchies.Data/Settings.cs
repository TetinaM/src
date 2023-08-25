using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    public class Settings : ISettings
    {/// <summary>
     /// Implementacja pól ustawień
     /// </summary>
       
        public string MainScreenColor { get; set; } = "Red";
        public string AnimalsScreenColor { get; set; } = "Green";
        public string MammalsScreenColor { get; set; } = "DarkMagenta";
        public string DogsScreenColor { get; set; } = "Cyan";
        public string CatsScreenColor { get; set; } = "Blue";
        public string LionsScreenColor { get; set; } = "Magenta";
        public string ElephantsScreenColor { get; set; } = "Yellow";
        public string TigersScreenColor { get; set; } = "DarkCyan";


    }
}
