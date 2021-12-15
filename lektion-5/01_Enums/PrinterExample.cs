using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Enums
{



    enum PrinitingState
    {
        Initializing,
        Idle,
        ReceivingData,
        LoadingPapper,
        Printing,
        CoolingDown,
        Offline
    }


    internal class PrinterExample
    {
        public static PrinitingState state = PrinitingState.Offline;
        private static PrinitingState prevState = PrinitingState.Offline;


        public static void Start()
        {
            Console.Clear();
            state = PrinitingState.Initializing;
            Task.Delay(10000).Wait();

            Console.Clear();
            state = PrinitingState.Idle;
            Task.Delay(5000).Wait();
        }

        public static void Print()
        {
            Console.Clear();
            state = PrinitingState.ReceivingData;
            Task.Delay(5000).Wait();

            Console.Clear();
            state = PrinitingState.LoadingPapper;
            Task.Delay(1000).Wait();

            Console.Clear();
            state = PrinitingState.Printing;
            Task.Delay(2000).Wait();

            Console.Clear();
            state = PrinitingState.Idle;
            Task.Delay(5000).Wait();
        }

        public static async Task ShowState()
        {
            while (true)
            {
                if(prevState != state)
                {
                    prevState = state;

                    switch (state)
                    {
                        case PrinitingState.Initializing:
                            Console.WriteLine("Printer is starting. Please wait...");
                            break;

                        case PrinitingState.Idle:
                            Console.WriteLine("Printer ready.");
                            break;

                        case PrinitingState.ReceivingData:
                            Console.WriteLine("Receiving data");
                            break;

                        case PrinitingState.Printing:
                            Console.WriteLine("Printing");
                            break;
                    }
                }
                    





                await Task.Delay(1000);
            }
        }

    }
}
