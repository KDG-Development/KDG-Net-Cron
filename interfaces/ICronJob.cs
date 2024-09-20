namespace KDG.Cron.Interfaces;

public interface ICronJob {
    public abstract Task Execute();
}