using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_n_Tasks
{
    internal class AsynchronousFileIO
    {
        private struct TaskParams
        {
            public int DelayTime;
            public int TaskId;
            public string StringToFile;
            public TaskParams(int delayTime, int taskId, string stringToFile)
            {
                DelayTime = delayTime;
                TaskId = taskId;
                StringToFile = stringToFile;
            }
        }

        public bool IsBusy { get; set; } = false; //Token

        public delegate void CallbackDelegate(string status); // Step 1. "Specs for delegate class...ICH"
        public CallbackDelegate callbackDelegate = null; // Step 2 "Create delegate object...ICH"

        public void AsyncWriteStringToFile(string _string)
        {
            IsBusy = true;
            TaskParams WriteTaskParams = new TaskParams(2000, 10, _string); //A SimulationDelay + TaskID + String to write to file
            Task WriteTask = new Task(WriteToFile, WriteTaskParams);
            WriteTask.Start();
        }
        public async void WriteToFile(object? _taskParams) //See Task API, måste ta emot object :(
        {
            TaskParams taskParams = (TaskParams)_taskParams;
            Debug.WriteLine($" Im Task with id={taskParams.TaskId}. I dont want to lock your GUI/UX when i do my stuffNow. I will callback when im done ");
            await File.WriteAllTextAsync("myFile.txt", taskParams.StringToFile);
            await Task.Delay(taskParams.DelayTime); // Simulating...
            callbackDelegate("Write operation"); // Step 3 "Raise the delegate event, and pass this string, I wonder if anyone is listening :)
            IsBusy = false;
        }

        public void AsyncReadStringFromFile()
        {
            IsBusy = true;
            TaskParams ReadTaskParams = new TaskParams(2000, 11, null); //A SimulationDelay + TaskID
            Task ReadTask = new Task(ReadFromFile, ReadTaskParams);
            ReadTask.Start();
        }
        public async void ReadFromFile(object? _taskParams) //See Task API, måste ta emot object  :(
        {
            TaskParams taskParams = (TaskParams)_taskParams;
            Debug.WriteLine($" Im Task with id={taskParams.TaskId}. I dont want to lock your GUI/UX when i do my stuffNow. I will callback when im done ");
            await Task.Delay(taskParams.DelayTime); // Simulating...
            Console.WriteLine(await File.ReadAllTextAsync("myFile.txt"));
            callbackDelegate("Read operation"); // Step 3 "Raise the delegate event, and pass this string, I wonder if anyone is listening :)
            IsBusy = false;
        }
    }
}
