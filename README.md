C# Thread Priority and Thread Pool Explanation

## Overview

This project demonstrates the use of **thread priorities** and **Thread Pool** for executing CPU-bound tasks in parallel. It showcases:
- How different **thread priorities** (high, normal, low) affect task execution times.
- How to use the .NET **ThreadPool** to manage and run tasks concurrently with optimized resource usage.

## Features

- **Priority Threads**:
  - Simulates tasks with different priorities using `ThreadPriority` (Highest, Normal, Lowest).
  - Measures and prints the time taken by each priority thread.

- **Thread Pool Tasks**:
  - Demonstrates the use of `ThreadPool.QueueUserWorkItem()` to execute tasks concurrently.
  - Each task is identified and executed in the background using the ThreadPool.

## Code Workflow

1. **Priority Threads**:
   - Three threads are created with different priorities: **High**, **Normal**, and **Low**.
   - Each thread performs CPU-bound work (a loop counting to 100,000,000) and outputs the time taken to complete.

2. **Thread Pool**:
   - After the priority threads finish, three tasks are queued into the ThreadPool.
   - These tasks run concurrently, and the program prints the start and completion times for each.


