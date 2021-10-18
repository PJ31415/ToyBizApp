
using CoreLibrary;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyBizApp
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello World! This is toy business application");

            var dataProvider = SelectDataProvider();
            if (dataProvider == null)
            {
                Console.WriteLine("No data sources available - program will exit");
                Console.ReadKey();
                return (int)ExitCode.NoDataProvider;
            }

            var logic = new BizLogic(dataProvider);
            try
            {
                ProgramLoop(logic);
            }
            catch (ApplicationException e)
            {
                // we do not know what went wrong right here, but we knew when we thew it
                Console.WriteLine(e.Message);
                return (int)ExitCode.SomeLogicError;
            }

            return (int)ExitCode.Normal;
        }

        private static void ProgramLoop(BizLogic logic)
        {
            ShowHelp();
            var sort = SortType.PriceDescending;
            do
            {
                Console.WriteLine("{0,-18} {1,-12} {2,-12}!", "Name", "Price", "Super offer");
                foreach (var offer in logic.GetOffers(sort))
                {
                    Console.WriteLine("{0,-18:F} {1,12:N2} {2,12:N2}!", offer.Name, offer.Price, offer.FinalPrice);
                }

                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        sort = SortType.NameAscending;
                        break;
                    case ConsoleKey.H:
                    case ConsoleKey.Help:
                        ShowHelp();
                        break;
                    case ConsoleKey.S:
                        sort = SortType.PriceDescending;
                        break;
                    case ConsoleKey.X:
                        sort = SortType.PriceAscending;
                        break;
                    case ConsoleKey.Q:
                        return;
                    case ConsoleKey.Z:
                        sort = SortType.NameDescending;
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        goto case ConsoleKey.H;
                }
            } while (true);
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Use following keys to ");
            Console.WriteLine("a - sort products by name A-Z");
            Console.WriteLine("z - sort products by name Z-A");
            Console.WriteLine("s - sort products by price descending");
            Console.WriteLine("s - sort products by price ascending");
            Console.WriteLine("q - quit application");
            Console.WriteLine("h - show help");
        }

        private static IDataProvider SelectDataProvider()
        {
            var dataProviders = LoadDataProviders();
            if (dataProviders.Count == 0)
                return null;
            if (dataProviders.Count == 1)
            {
                return dataProviders[0];
            }
            // only 10 providers to choose from because this is demo ;)
            //  could be extended to paged list with next/previous options and Skip/Take
            //  or just listing all and parsing index from ReadLine
            dataProviders = dataProviders.Take(10).ToList();
            Console.WriteLine("Please select data provider:");
            for (int i = 0; i < dataProviders.Count; i++)
            {
                Console.WriteLine("{0} - {1}", i, dataProviders[i].Name);
            }
            var key = Console.ReadKey();
            Console.WriteLine();
            int selectedIndex = 0;
            switch (key.Key)
            {
                case ConsoleKey.D0:
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                case ConsoleKey.D6:
                case ConsoleKey.D7:
                case ConsoleKey.D8:
                case ConsoleKey.D9:
                    selectedIndex = key.Key - ConsoleKey.D0;
                    break;
                default:
                    Console.WriteLine("Invalid key - using first available data source");
                    break;
            }
            if (selectedIndex >= dataProviders.Count)
            {
                Console.WriteLine("Index out of range - using first available data source instead");
                selectedIndex = 0;
            }
            return dataProviders[selectedIndex];
        }

        /// <summary>
        /// Search for possible data providers in libraries
        /// </summary>
        /// <returns>list of found data providers</returns>
        private static List<IDataProvider> LoadDataProviders()
        {
            var available = new List<IDataProvider>();
            Type providerType = typeof(IDataProvider);
            // note that this project has MockData project added as dependency to have .dll copied
            //  it will work anyway, but in less interesting way ;)
            foreach (var file in System.IO.Directory.EnumerateFiles(System.IO.Directory.GetCurrentDirectory(), "*.dll"))
            {
                try
                {
                    System.Reflection.AssemblyName name = System.Reflection.AssemblyName.GetAssemblyName(file);
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(name);
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.IsAbstract || type.IsInterface || type.IsEnum || type.IsNotPublic) continue;
                        try
                        {
                            if (type.GetInterface(providerType.FullName) == null) continue;
                            IDataProvider instance = (IDataProvider)Activator.CreateInstance(type);
                            available.Add(instance);
                        }
                        catch (Exception e) when (e is System.Reflection.AmbiguousMatchException || e is ArgumentException || e is System.Reflection.TargetInvocationException
                        || e is MemberAccessException)
                        {// if we cannot use this type - skip it
                            Console.WriteLine("Attempt to use {0} failed", type.FullName);
                        }

                    }
                }
                catch (SystemException e) when (e is System.Security.SecurityException || e is BadImageFormatException || e is System.IO.IOException || e is System.Reflection.ReflectionTypeLoadException)
                {
                    Console.WriteLine("Found {0} but could not load it", file);
                }
            }


            return available;
        }

        enum ExitCode : int
        {
            Normal = 0,
            NoDataProvider = 123,
            SomeLogicError = 456
        }

    }
}
