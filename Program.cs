using System;
using System.Threading.Tasks;

static async Task Main()
{
    await StressCpu(5, 1);
}

static async Task StressCpu(uint TimeInSeconds, uint CoreNumber)
{
    Console.WriteLine("Start Stressing...");
    Task[] tasks = Task[CoreNumber];
    bool keepGoing = true;
    for (uint i = 0; i < CoreNumber; i++)
    {
        tasks[i] = () =>
        {
            ulong initialNumber = 2;
            while (keepGoing)
            {
                initialNumber *= 2;
            }
        };
    }
    await Task.Delay(TimeInSeconds);
    keepGoing = false;
    await Task.WhenAll(tasks);
    Console.WriteLine("Stress finished.");
}
