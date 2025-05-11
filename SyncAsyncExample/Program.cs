using SyncAsyncExample;

internal class Program
{
    private   static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //ProcessData3Async().Wait();
        //ProcessData1Async();//synchronous calling
        //ProcessData2Async();

        //TaskParallelLibraryExample example = new TaskParallelLibraryExample();
        //example.LoadDataAsync();


        ClassWork classWork = new ClassWork();
        classWork.RunTaskAsync();

        //Console.WriteLine("Execution Completed");

        Console.ReadLine();


       
    }

    /*
    Synchronous Code6
    * Executes one task at a time
    * Slows down Execution if a task takes longer

     */

    public static void ProcessData1()
    {
        Console.WriteLine("Fetching Data One...");
        Thread.Sleep(3000);//simulates delay for number in milisecond
        Console.WriteLine("Data one Fetched...");
    }
    public static void ProcessData2()
    {
        Console.WriteLine("Fetching Data Two...");
        Thread.Sleep(3000);//simulates delay for number in milisecond
        Console.WriteLine("Data two Fetched...");
    }
    public static void ProcessData3()
    {
        Console.WriteLine("Fetching Data Three...");
        Thread.Sleep(3000);//simulates delay for number in milisecond
        Console.WriteLine("Data three Fetched...");
    }

    public async static Task ProcessData1Async()
    {
        Console.WriteLine("Fetching Data One...");
        await Task.Delay(3000);//Simulates delay without blocking
        Console.WriteLine("Data one Fetched...");
    }
    public async static Task ProcessData2Async()
    {
        Console.WriteLine("Fetching Data Two...");
        await Task.Delay(2000);//Simulates delay without blocking
        Console.WriteLine("Data two Fetched...");
    }
    public async static Task ProcessData3Async()
    {
        Console.WriteLine("Fetching Data Three...");
        await Task.Delay(4000);//Simulates delay without blocking
        Console.WriteLine("Data three Fetched...");
    }

}