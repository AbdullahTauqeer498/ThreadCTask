using System;
using System.Diagnostics;
using System.Threading;

class ThreadPriorityDemo
{
    // Counters for tracking work done by different priority threads
    static int highPriorityCount = 0, normalPriorityCount = 0, lowPriorityCount = 0;
    
    // Stopwatch to measure time taken by threads
    static Stopwatch stopwatch = new Stopwatch();

    // Function for simulating a CPU-bound task for high-priority thread
    static void HighPriorityWork()
    {
        stopwatch.Start(); // Start timing
        // Simulate CPU-bound work by incrementing a counter
        for (int i = 0; i < 100000000; i++) { highPriorityCount++; }
        stopwatch.Stop(); // Stop timing
        // Output the time taken by the high-priority task
        Console.WriteLine($"High priority task completed in: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Function for simulating a CPU-bound task for normal-priority thread
    static void NormalPriorityWork()
    {
        stopwatch.Restart(); // Restart timing
        for (int i = 0; i < 100000000; i++) { normalPriorityCount++; }
        stopwatch.Stop();
        // Output the time taken by the normal-priority task
        Console.WriteLine($"Normal priority task completed in: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Function for simulating a CPU-bound task for low-priority thread
    static void LowPriorityWork()
    {
        stopwatch.Restart(); // Restart timing
        for (int i = 0; i < 100000000; i++) { lowPriorityCount++; }
        stopwatch.Stop();
        // Output the time taken by the low-priority task
        Console.WriteLine($"Low priority task completed in: {stopwatch.ElapsedMilliseconds} ms");
    }

    // Function for simulating a task executed by the ThreadPool
    static void ThreadPoolWork(object state)
    {
        int taskId = (int)state;  // Get the task ID from the passed state
        stopwatch.Restart();  // Restart the stopwatch for timing
        Console.WriteLine($"ThreadPool task {taskId} started.");
        // Simulate some work (CPU-bound task)
        for (int i = 0; i < 100000000; i++) { }
        stopwatch.Stop();
        // Output the time taken for the task in the ThreadPool
        Console.WriteLine($"ThreadPool task {taskId} finished in: {stopwatch.ElapsedMilliseconds} ms");
    }

    static void Main(string[] args)
    {
        // Priority Threads Section

        // Create and assign tasks with different thread priorities
        Thread highPriorityThread = new Thread(HighPriorityWork);
        Thread normalPriorityThread = new Thread(NormalPriorityWork);
        Thread lowPriorityThread = new Thread(LowPriorityWork);

        // Set the priorities of the threads
        highPriorityThread.Priority = ThreadPriority.Highest;  // Highest priority
        normalPriorityThread.Priority = ThreadPriority.Normal; // Normal priority
        lowPriorityThread.Priority = ThreadPriority.Lowest;    // Lowest priority

        // Start the threads
        highPriorityThread.Start();
        normalPriorityThread.Start();
        lowPriorityThread.Start();

        // Ensure that all priority threads complete before proceeding
        highPriorityThread.Join();
        normalPriorityThread.Join();
        lowPriorityThread.Join();

        // ThreadPool Section

        Console.WriteLine("\nUsing ThreadPool for parallel task execution:");

        // Execute tasks using the ThreadPool
        for (int i = 1; i <= 3; i++)
        {
            // Queue tasks in the ThreadPool
            ThreadPool.QueueUserWorkItem(ThreadPoolWork, i);
        }

        // Allow time for all ThreadPool tasks to finish
        Thread.Sleep(2000);  // This ensures ThreadPool tasks complete before the program ends
    }
}
