namespace Task_2
{
    public interface IMedia
    {
        bool Paused { get; set; }

        void Pause();
        void Stop();

        void AskWhenSelected();
    }
}