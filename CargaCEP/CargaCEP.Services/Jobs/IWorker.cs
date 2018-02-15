namespace CargaCEP.Services.Jobs
{
    public interface IWorker
    {
        void Execute();

        string GetWorkerName();
    }
}
