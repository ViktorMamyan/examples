const string MUTEX_GUID = "15cb037d-3aec-475c-8ad4-e153d71cceb9";

static Mutex mutex = new Mutex(true, MUTEX_GUID);
[STAThread]
static async Task Main(string[] args)
{
    if (mutex.WaitOne(TimeSpan.Zero, true))
    {
        mutex.ReleaseMutex();
    }
    else
    {
        return;
    }
}