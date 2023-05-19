// See https://aka.ms/new-console-template for more information

using SimplePasswordGenerator.Console;
using System.Collections;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

string myText = "Welcome to the B E S T P A S S W O R D M A N A G E R !";
int lengthText = myText.Length;

Console.WriteLine(new string('*', lengthText) + "\n" + myText + "\n" + new string('*', lengthText));

Console.WriteLine("Do you want to Include Number?");
string includeNumbers = Console.ReadLine();

switch (includeNumbers)
{
    case "Y":
        Characters.SelectNumbers();
        break;

    case "y":
        Characters.SelectNumbers(); break;

    default:
        break;
}

Console.WriteLine("OK! How about lowercase characters?");
string includeLowercaseCharacters = Console.ReadLine();

switch (includeLowercaseCharacters)
{
    case "Y":
        Characters.SelectLovercaseChars();
        break;

    case "y":
        Characters.SelectLovercaseChars(); break;

    default:
        break;
}

Console.WriteLine("Very nice! How about uppercase characters?");
string includeUppercaseCharacters = Console.ReadLine();

switch (includeUppercaseCharacters)
{
    case "Y":
        Characters.SelectUppercaseChars();
        break;

    case "y":
        Characters.SelectUppercaseChars(); break;

    default:
        break;
}

Console.WriteLine("All right! We are almost done. Would you also want to add special characters?");
string includeSpecialCharacters = Console.ReadLine();

switch (includeSpecialCharacters)
{
    case "Y":
        Characters.SelectSpecialChars();
        break;

    case "y":
        Characters.SelectSpecialChars(); break;

    default:
        break;
}

var characters = new Characters();

Console.WriteLine("Great! How long do you want to keep your password length?");
int passwordLength = Convert.ToInt32(Console.ReadLine());

if (passwordLength == 0)
{
    Console.WriteLine("BAD GIRL!!");
}

Console.WriteLine("-----------------------------------------------------------------------------------");
Console.WriteLine($"Your password is : {characters.GetRandomPassword(passwordLength)}");
Console.WriteLine("-----------------------------------------------------------------------------------");

Console.ReadLine();











