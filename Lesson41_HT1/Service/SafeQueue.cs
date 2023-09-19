namespace Lesson41_HT1.Service
{
    public class SafeQueue
    {
        public List<string> _queue = new List<string>();
        private readonly object _lock = new();
        public SafeQueue() { }

        public void Enqueue(string element)
        {
            lock (_lock)
            {
                _queue.Add(element);
            }
        }
        public string? Dequeue()
        {
            if( _queue.Count > 0 )
            {
                return _queue.FirstOrDefault();
            }
            throw new ArgumentNullException("colleksiya ichi bo'sh");
        }

    }
}
