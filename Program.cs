using System;
using System.Diagnostics;
using System.Threading;

namespace Delegates_n_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            PreparationAssignmentApplication App = new PreparationAssignmentApplication();
            App.Run(); //This is a Task. If we want to do someting fun below, we are free to do so :)


            int counter = 0;
            while (true)
            {
                Thread.Sleep(1000);
                counter += 1;
                //Console.WriteLine($"Hanging around in Main()...waiting for someting fun... {counter}");
            }
        }
    }
}
