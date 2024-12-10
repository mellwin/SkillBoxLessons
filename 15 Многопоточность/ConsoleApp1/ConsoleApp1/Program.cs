async Task Method(int seconds, string taskName)
{
    for (int i = 0; i < 100; i++)
    {
        Console.WriteLine($"Работает {taskName} в потоке = {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(seconds);
    }
}

Console.WriteLine("Hello, World!");
Console.WriteLine($"Основной поток начало {Thread.CurrentThread.ManagedThreadId}");

var t1 = Task.Run(()=>Method(1, "задача 1"));
var t2 = Task.Run(()=>Method(2, "задача 2"));
var t3 = Task.Run(()=>Method(3, "задача 3"));

await Task.WhenAll(t1, t2, t3);

Console.WriteLine($"Основной поток конец {Thread.CurrentThread.ManagedThreadId}");