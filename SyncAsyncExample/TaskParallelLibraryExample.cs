using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncAsyncExample
{
    public class TaskParallelLibraryExample
    {
        public void Example()
        {

            /*
             * function or action
            ()=>{} 


             */
            //suitable for background task
            //
            Task.Run(() => {
                Console.WriteLine("Fetching Data One...");
                Thread.Sleep(3000);//simulates delay for number in milisecond
                Console.WriteLine("Data one Fetched...");
            });


        }

        public async Task LoadDataAsync()
        {
            Task<int> task1= Task.Run(() => {
                Console.WriteLine("Fetching Data One...");
                Task.Delay(3000);//simulates delay for number in milisecond
                Console.WriteLine("Data one Fetched...");
                return 10;
            });
            Task<int> task2 = Task.Run(() => {
                Console.WriteLine("Fetching Data two...");
                Task.Delay(3000);//simulates delay for number in milisecond
                Console.WriteLine("Data two Fetched...");
                return 20;
            });
            

            int[] results =await Task.WhenAll(task1, task2);
            Console.WriteLine($"Results: {results[0]}, {results[1]}");
        }
    }
}
