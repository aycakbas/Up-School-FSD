using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordGenerator.Console
{
    public class Characters
    {
        public static string Numbers = "1234567890";
        public static string LowercaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        public static string UppercaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string SpecialCharacters = "*$-+?_&=!%{}/\"";

        private readonly Random _random;

        public static string SelectedChars { get; set; } = null!;

        public Characters()
        {
            _random = new Random();
        }

        public static void SelectNumbers ()
        {
            SelectedChars += (Numbers);
        }
        public static void SelectLovercaseChars()
        {
            SelectedChars += (LowercaseCharacters);
        }
        public static void SelectUppercaseChars()
        {
            SelectedChars += (UppercaseCharacters);
        }
        public static void SelectSpecialChars()
        {
            SelectedChars += (SpecialCharacters);
        }
        public string GetRandomPassword (int x)
        {
            string charset = "";

            for (int i=0; i<x; i++) 
            {
                var randomIndex = _random.Next(x);
                var character = SelectedChars[randomIndex];
                charset += character;
            }
            return charset;
        }


    }
}
