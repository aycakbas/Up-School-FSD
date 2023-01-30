using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Linq.Expressions;

public class Program
{
    private static void Main(string[] args)
    {
        string myText = "Welcome to the B E S T P A S S W O R D M A N A G E R !";
        int lengthText = myText.Length;

        Console.WriteLine(new string('*', lengthText) + "\n" + myText + "\n" + new string('*', lengthText));


        List<char> numbers = new List<char>();
        List<char> lowercaseCharacters = new List<char>();
        List<char> uppercaseCharacters = new List<char>();
        List<char> specialCharacters = new List<char>();
        List<char> passwordList = new List<char>();


        for (char i = '0'; i <= '9'; i++)
            numbers.Add(i);

        for (char i = 'a'; i <= 'z'; i++)
            lowercaseCharacters.Add(i);

        for (char i = 'A'; i <= 'Z'; i++)
            uppercaseCharacters.Add(i);

        for (char i = '!'; i <= '/'; i++)
            specialCharacters.Add(i);



        Console.WriteLine("Do you want to Include Number?");
        string includeNumbers = Console.ReadLine();

        switch (includeNumbers)
        {
            case "y":
            case "Y":
                passwordList.AddRange(includeNumbers);
                break;
        }


        Console.WriteLine("OK! How about lowercase characters?");
        string includeLowercaseCharacters = Console.ReadLine();

        switch (includeLowercaseCharacters)
        {
            case "y":
            case "Y":
                passwordList.AddRange(lowercaseCharacters);
                break;
        }


        Console.WriteLine("Very nice! How about uppercase characters?");
        string includeUppercaseCharacters = Console.ReadLine();

        switch (includeUppercaseCharacters)
        {
            case "y":
            case "Y":
                passwordList.AddRange(uppercaseCharacters);
                break;
        }


        Console.WriteLine("All right! We are almost done. Would you also want to add special characters?");
        string includeSpecialCharacters = Console.ReadLine();

        switch (includeSpecialCharacters)
        {
            case "y":
            case "Y":
                passwordList.AddRange(specialCharacters);
                break;
        }



        Console.WriteLine("Great! How long do you want to keep your password length?");
        int passwordLength = Convert.ToInt32(Console.ReadLine());

        Random rnd = new Random();

        switch (passwordLength)
        {
            case > 0:
                for (int i = 0; i < passwordLength; i++)

                Console.Write(passwordList[rnd.Next(passwordLength)]);
                Console.ReadLine();    
                   
                
                break;


        }

        Console.WriteLine(new string('-', lengthText));

        Console.ReadLine();

    }


}