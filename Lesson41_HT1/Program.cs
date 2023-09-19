using Lesson41_HT1.Service;

var safeQueue = new SafeQueue();
safeQueue.Enqueue("abdurahmon");
safeQueue.Enqueue("Azizbek");
var a = safeQueue.Dequeue();
Console.WriteLine(a);
