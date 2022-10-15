using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;


namespace program
{
    class mementosapp
    {

        class Global
        {
            public static string[] lines = new string[100];
            public static int linesCount = lines.Count();
            
        }

        class file
        {
            public static void init()
            {
                if (File.Exists("data.txt"))
                {
                    Global.lines = File.ReadAllLines("data.txt");
                }
                else
                {
                    File.Create("data.txt");
                }

            }
        }
        public static void Main(string[] args)
        {
            file.init();
            int i = 0;
            var showMenu = true;
            while (showMenu)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Show mementos");
                Console.WriteLine("2. Add memento");
                Console.WriteLine("3. Edit memento");
                Console.WriteLine("4. Remove memento");
                Console.WriteLine("5. Save and exit");

                int menuSelection = Convert.ToInt32(Console.ReadLine());
                switch (menuSelection)
                {
                    case 1:
                        foreach (string ln in Global.lines)
                        {
                            if(ln != null)
                                Console.WriteLine(ln);
                            i++;
                        }
                        break;
                    case 2:
                        Console.WriteLine(Global.lines.Length);
                        Array.Resize(ref Global.lines, 100);
                        Console.WriteLine(i + 1);
                        Global.lines[i + 1] = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Which memento to edit(0-100 0 meaning first line): ");
                        int mementoLineToEdit = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Edit with: ");
                        string mementoEdited = Console.ReadLine();
                        Global.lines[mementoLineToEdit] = mementoEdited;
                        break;
                    case 4:
                        Console.Write("Which memento to remove(0-100 0 meaning first line): ");
                        int mementoLineToRemove = Convert.ToInt32(Console.ReadLine());
                        Global.lines[mementoLineToRemove] = null;
                        i = 0;
                        while (i < Global.lines.Count())
                        {
                            foreach (string ln in Global.lines)
                            {
                                if (Global.lines[i] != null)
                                {
                                    if (Global.lines[i] == null)
                                    {
                                        do
                                        {
                                            int x = i + 1;
                                            Global.lines[i] = Global.lines[x];
                                        }
                                        while (Global.lines[i] != null);
                                    }
                                    Global.lines[i] = Global.lines[i + 1];
                                }
                                Global.lines[i] = Global.lines[i];
                            }
                            i++;

                        }
                        break;
                    case 5:
                            File.WriteAllLines("data.txt", Global.lines);
                        showMenu = false;
                        break;
                }
            }
        }
    }
}
