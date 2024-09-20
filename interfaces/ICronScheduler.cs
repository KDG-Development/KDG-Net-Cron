namespace KDG.Cron.Interfaces;

public interface ICronScheduler
{
    public void ScheduleOneTimeJob(ICronJob job);

    public void ScheduleOneTimeFutureJob(
        ICronJob job,
        DateTimeOffset delay
    );

    public void ScheduleRecurringJob(
        string jobName,
        ICronJob job,
        Func<string> JobSchedule
    );

    public void CancelRecurringJob(string jobName);

    public void ScheduleJobContinuation(
        string previousJobName,
        ICronJob job
    );

    public void CancelOneTimeJob(string previousJobName);
}