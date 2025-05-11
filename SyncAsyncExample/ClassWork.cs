using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncAsyncExample
{
    internal class ClassWork
    {

        public async Task FetchUserData()
        {
            await Task.Delay(3000);
            Console.WriteLine("User Data Fetched In 3 second");
        }

        public async Task FetchTransactionHistory()
        {
            await Task.Delay(3000);
            Console.WriteLine("Transaction History Fetched In 3 second");
        }

        public async Task RunTaskAsync()
        {
            Task a=FetchUserData();
            Task b=FetchTransactionHistory();
            await Task.WhenAll(a, b);

            Console.WriteLine("All Data Loaded");
        }
    }
}
