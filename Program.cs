using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;


namespace Project_Capstone
{
    class Program
    {
        // **************************************************
        //
        // Title: Capstone Project
        // Application Type: Console
        // Description: An application that uses the Finch Robot
        //              to teach the basics of playing a guitar
        // Author: Jurich, Alexander
        // Dated Created: 7/22/2021
        // Last Modified: 8/1/2021
        //
        // **************************************************

        static void Main(string[] args)
        {
            Finch finchRobot = new Finch();

            SetTheme();
            DisplayTitle(finchRobot);
            DisplayMenu();
        }

        static void DisplayMenu()
        {
            Finch finchRobot = new Finch();

            bool quitApp = false;
            string menuChoice;

            Console.CursorVisible = true;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t1] TUNER");
                Console.WriteLine();
                Console.WriteLine("\t\t2] SCALES");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\t\t3] CHORDS");
                Console.WriteLine();
                Console.WriteLine("\t\t4] LESSONS");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t0] EXIT APPLICATION");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\t\tWhat would you like to do? ");

                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    case "1":
                        DisplayGuitarTunerMenu(finchRobot);
                        break;

                    case "2":
                        DisplayGuitarScalesMenu(finchRobot);
                        break;

                    case "3":
                        DisplayGuitarChordsMenu(finchRobot);
                        break;

                    case "0":
                        finchRobot.disConnect();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\t\t[Please enter a number from the list above ...]");
                        DisplayContinue();
                        break;
                }

            } while (!quitApp);
        }

        #region USER INTERFACE

        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void DisplayTitle(Finch finchRobot)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tTITLE SCREEN");
            Console.WriteLine();
            finchRobot.connect();

            DisplayContinue();

            for (int index = 0; index < 40; ++index)
            {
                finchRobot.setLED(index, index, index);
                finchRobot.noteOn(index * 40);
                finchRobot.wait(5);
                finchRobot.noteOff();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void DisplayContinue()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t[Press any key ...]");
            Console.ReadKey();
        }

        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\t\t\t\t\t[Return to the {menuName} ...]");
            Console.ReadKey();
        }

        #endregion

        #region GUITAR TUNER

        static void DisplayGuitarTunerMenu(Finch finchRobot)
        {
            bool quitTunerMenu = false;
            string menuChoice;

            Console.CursorVisible = true;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t1] Standard: E A D G B E");
                Console.WriteLine();
                Console.WriteLine("\t\t2] Drop D: D A D G B E");
                Console.WriteLine();
                Console.WriteLine("\t\t3] Open D: D A D F# A D");
                Console.WriteLine();
                Console.WriteLine("\t\t4] Open G: D G D G B D");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t\t0] Exit to Main Menu");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\t\tHow would you like to tune you guitar? ");

                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {
                    case "1":
                        DisplayStandardTuning(finchRobot);
                        break;

                    case "2":
                        DisplayDropDTuning(finchRobot);
                        break;

                    case "3":
                        DisplayOpenDTuning(finchRobot);
                        break;

                    case "4":
                        DisplayOpenGTuning(finchRobot);
                        break;

                    case "0":
                        quitTunerMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\t\t[Please enter a number from the list above]");
                        DisplayContinue();
                        break;
                }

            } while (!quitTunerMenu);
        }

        static void DisplayStandardTuning(Finch finchRobot)
        {
            finchRobot.connect();

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tStandard: E A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" E||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(330);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tStandard: E A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" a||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" E||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(440);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tStandard: E A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" d||--0---------------------|--0---------------------|--0---------------------|--0--------------------o||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" E||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(587);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tStandard: E A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" g||--0---------------------|--0---------------------|--0---------------------|--0--------------------o||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" E||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(784);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tStandard: E A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" b||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" E||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(988);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tStandard: E A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" e||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" E||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(1319);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tStandard: E A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" e||------------------------|------------------------|-------------0----------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|--0---------------------|------------------------||");
            Console.WriteLine(" g||------------------------|-------------0----------|------------------------|------------------------||");
            Console.WriteLine(" d||------------------------|--0---------------------|------------------------|------------------------||");
            Console.WriteLine(" a||-------------0----------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" E||--0---------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            finchRobot.wait(300);
            finchRobot.noteOn(330);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOn(1319);
            finchRobot.wait(1000);
            finchRobot.noteOff();

            DisplayMenuPrompt("Tuner");
        }

        static void DisplayDropDTuning(Finch finchRobot)
        {
            finchRobot.connect();

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tDrop D: D A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" D||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(294);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tDrop D: D A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" a||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(440);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tDrop D: D A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" d||--0---------------------|--0---------------------|--0---------------------|--0--------------------o||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(587);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tDrop D: D A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" g||--0---------------------|--0---------------------|--0---------------------|--0--------------------o||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(784);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tDrop D: D A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" e||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" b||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(988);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tDrop D: D A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" e||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(1319);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tDrop D: D A D G B E");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" e||------------------------|------------------------|-------------0----------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|--0---------------------|------------------------||");
            Console.WriteLine(" g||------------------------|-------------0----------|------------------------|------------------------||");
            Console.WriteLine(" d||------------------------|--0---------------------|------------------------|------------------------||");
            Console.WriteLine(" a||-------------0----------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||--0---------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            finchRobot.wait(300);
            finchRobot.noteOn(294);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOn(1319);
            finchRobot.wait(1000);
            finchRobot.noteOff();

            DisplayMenuPrompt("Tuner");
        }

        static void DisplayOpenDTuning(Finch finchRobot)
        {
            finchRobot.connect();

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen D: D A D F A D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine("f#||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" D||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(294);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen D: D A D F A D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine("f#||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" a||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(440);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen D: D A D F A D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine("f#||------------------------|------------------------|------------------------|-----------------------o||");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" d||--0---------------------|--0---------------------|--0---------------------|--0--------------------o||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(587);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen D: D A D F A D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("f#||--0---------------------|--0---------------------|--0---------------------|--0--------------------o||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(740);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen D: D A D F A D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" a||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("f#||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(880);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen D: D A D F A D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" d||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine("f#||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" a||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(1175);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen D: D A D F A D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" d||------------------------|------------------------|-------------0----------|------------------------||");
            Console.WriteLine(" a||------------------------|------------------------|--0---------------------|------------------------||");
            Console.WriteLine("f#||------------------------|-------------0----------|------------------------|------------------------||");
            Console.WriteLine(" d||------------------------|--0---------------------|------------------------|------------------------||");
            Console.WriteLine(" a||-------------0----------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||--0---------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            finchRobot.wait(300);
            finchRobot.noteOn(294);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(740);
            finchRobot.wait(500);
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOn(1175);
            finchRobot.wait(1000);
            finchRobot.noteOff();

            DisplayMenuPrompt("Tuner");
        }

        static void DisplayOpenGTuning(Finch finchRobot)
        {
            finchRobot.connect();

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen G: D G D G B D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" D||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(294);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen G: D G D G B D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" g||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(392);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen G: D G D G B D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" d||--0---------------------|--0---------------------|--0---------------------|--0--------------------o||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" g||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(587);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen G: D G D G B D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" g||--0---------------------|--0---------------------|--0---------------------|--0--------------------o||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(784);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen G: D G D G B D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" d||------------------------|------------------------|------------------------|------------------------||");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" b||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(988);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen G: D G D G B D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" d||--0---------------------|--0---------------------|--0---------------------|--0---------------------||");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" b||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" d||------------------------|------------------------|------------------------|-----------------------o||");
            Console.WriteLine(" g||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||------------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();

            finchRobot.wait(300);
            finchRobot.noteOn(1175);

            DisplayContinue();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\t\t\t\t: : : : : :   T U N E R   : : : : : :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\tOpen G: D G D G B D");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" d||------------------------|------------------------|-------------0----------|------------------------||");
            Console.WriteLine(" b||------------------------|------------------------|--0---------------------|------------------------||");
            Console.WriteLine(" g||------------------------|-------------0----------|------------------------|------------------------||");
            Console.WriteLine(" d||------------------------|--0---------------------|------------------------|------------------------||");
            Console.WriteLine(" g||-------------0----------|------------------------|------------------------|------------------------||");
            Console.WriteLine(" D||--0---------------------|------------------------|------------------------|------------------------||");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            finchRobot.wait(300);
            finchRobot.noteOn(294);
            finchRobot.wait(500);
            finchRobot.noteOn(392);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOn(1175);
            finchRobot.wait(1000);
            finchRobot.noteOff();

            DisplayMenuPrompt("Tuner");
        }

        #endregion

        #region GUITAR SCALES

        static void DisplayGuitarScalesMenu(Finch finchRobot)
        {
        }

        #endregion

        #region GUITAR CHORDS

        static void DisplayGuitarChordsMenu(Finch finchRobot)
        {
        }

        #endregion
    }
}
