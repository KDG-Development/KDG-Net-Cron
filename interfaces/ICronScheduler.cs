using Hangfire;

namespace KDG.Cron.Interfaces;

public interface ICronScheduler
{

    public void ScheduleOneTimeJob(System.Linq.Expressions.Expression<Action> job);
    public void ScheduleOneTimeFutureJob(
        System.Linq.Expressions.Expression<Action> job,
        DateTimeOffset delay
    );
    public void ScheduleRecurringJob(
        string jobName,
        System.Linq.Expressions.Expression<Action> job,
        Func<string> JobSchedule
    );
    public void CancelRecurringJob(string jobName);
    public void ScheduleJobContinuation(
        string previousJobName,
        System.Linq.Expressions.Expression<Action> job
    );
    public void CancelOneTimeJob(string previousJobName);
}