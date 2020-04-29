using System;
using System.Collections.Generic;
using PhonePersonDB.Models;
using PhonePersonDB.Repositories;
using PhonePersonDB.Views;

namespace PhonePersonDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = null;
            UIModels uiModel = new UIModels();
            string msg = "";
            do
            {
                userInput = Choise();
                switch (userInput.ToUpper())
                {
                    case "C":
                        uiModel.Create();
                        msg = "---------------------------------";
                        break;
                    case "R":
                        uiModel.ReadById(4);
                        msg = "---------------------------------";
                        break;
                    case "U":
                        uiModel.Update();
                        msg = "---------------------------------";
                        break;
                    case "D":
                        uiModel.Delete(13);
                        msg = "---------------------------------";
                        break;
                    case "X":
                        msg = "Lopetetaan...";
                        break;
                    default:
                        msg = "Yritä uudestaan oikealla näppäimellä";
                        break;
                }
                Console.WriteLine(msg);
            } while (userInput.ToUpper() != "X");
        }
        static string Choise()
        {
            Console.WriteLine("[C] Luodaan henkilö tietokantaan\n[R] Haetaan henkilö ID:n mukaan" +
                "\n[U] Päivitä henkilö\n[D] Poista henkilö tietokannasta\n[X] Lopeta");
            Console.Write("Valitse mitä tehdään: ");
            string choise = Console.ReadLine();
            return choise;
        }
    }
}
