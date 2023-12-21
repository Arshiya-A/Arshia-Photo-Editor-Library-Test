// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.InteropServices;
using ArshiaPhotoEditorLibrary.Interfaces;
using ArshiaPhotoEditorLibrary.Models;
using ArshiaPhotoEditorLibrary.Services;

string mainPath = Environment.CurrentDirectory;
string folderName = "ImageEdited";
string fileName = "00.jpg";

string command = "";
float value = 0;

bool run = true;

if (!Directory.Exists(Path.Combine(mainPath, folderName)))
    Directory.CreateDirectory(Path.Combine(mainPath, folderName));

while (run)
{
    APELImage apelImage = new APELImage(Path.Combine(mainPath, folderName, fileName));
    IAPEL apel = new APEL();
    apel.Ready(apelImage);


    Console.WriteLine("---------------------ARSHIA PHOTOT EDITOR TEST -------------------------");
    Console.WriteLine("For Show All Command Please Type Help");


    command = Console.ReadLine();
    if (command == "help")
    {
        Console.Clear();
        Console.WriteLine("---------------------ARSHIA PHOTOT EDITOR TEST -------------------------\n");
        Console.WriteLine("All Commands : \n ");
        Console.WriteLine("b => Brightness from -1 till 1 \n"
        + "c => Contrast form -1 till 2 \n" +
        "r => CustomeRGB for every parameters from 0 till 256\n" +
        "ra => CustomeRGB with Alpha for alpha parameter from 0 till 1\n" +
        "\nFor Show Image Edited , can go to ApplicationPath/ImageEdited/ImageEdited.jpg" +
        "\nFor Exit you can type exit");
        command = Console.ReadLine();
        BrightnessCommand();
        ContrastCommand();
        CustomeRGBCommand();
        CustomeRGBACommand();
        Exit();
    }
    else
    {
        BrightnessCommand();
        ContrastCommand();
        CustomeRGBCommand();
        CustomeRGBACommand();
        Exit();

    }

    void BrightnessCommand()
    {
        if (command == "b")
        {
            Console.WriteLine("Value ? : ");
            value = float.Parse(Console.ReadLine());
            apel.Brightness(value);
            apel.Save(Path.Combine(mainPath, folderName, "EditedImage.jpg"));
        }
    }

    void ContrastCommand()
    {
        if (command == "c")
        {
            Console.WriteLine("Value ? : ");
            value = float.Parse(Console.ReadLine());
            apel.Contrast(value);
            apel.Save(Path.Combine(mainPath, folderName, "EditedImage.jpg"));
        }
    }



    void CustomeRGBCommand()
    {
        if (command == "r")
        {
            float r = 0;
            float g = 0;
            float b = 0;

            Console.WriteLine("R Value ? : ");
            r = float.Parse(Console.ReadLine());

            Console.WriteLine("G Value ? : ");
            g = float.Parse(Console.ReadLine());

            Console.WriteLine("B Value ? : ");
            b = float.Parse(Console.ReadLine());

            apel.CustomeRGB(r, g, b);
            apel.Save(Path.Combine(mainPath, folderName, "EditedImage.jpg"));
        }
    }

    void CustomeRGBACommand()
    {
        if (command == "ra")
        {
            float r = 0;
            float g = 0;
            float b = 0;
            float a = 0;

            Console.WriteLine("R Value ? : ");
            r = float.Parse(Console.ReadLine());

            Console.WriteLine("G Value ? : ");
            g = float.Parse(Console.ReadLine());

            Console.WriteLine("B Value ? : ");
            b = float.Parse(Console.ReadLine());

            Console.WriteLine("A Value ? : ");
            a = float.Parse(Console.ReadLine());

            apel.CustomeRGB(a, r, g, b);
            apel.Save(Path.Combine(mainPath, folderName, "EditedImage.jpg"));
        }
    }

    void Exit()
    {
        if (command == "exit")
        {
            run = false;
        }
    }




}