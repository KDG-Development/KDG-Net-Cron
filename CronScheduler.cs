using Hangfire;
using KDG.Cron.Interfaces;

namespace KDG.Cron;

public class CronScheduler : ICronScheduler {
    public void ScheduleOneTimeJob(System.Linq.Expressions.Expression<Action> job){
        Hangfire.BackgroundJob.Enqueue(job);
    }
    public void ScheduleOneTimeFutureJob(
        System.Linq.Expressions.Expression<Action> job,
        DateTimeOffset delay
    ){
        Hangfire.BackgroundJob.Schedule(
            job,
            delay
        );
    }
    public void ScheduleRecurringJob(
        string jobName,
        System.Linq.Expressions.Expression<Action> job,
        Func<string> jobSchedule
    ){
        Hangfire.RecurringJob.AddOrUpdate(
            jobName,
            job,
            jobSchedule
        );
    }
    public void ScheduleJobContinuation(
        string previousJobName,
        System.Linq.Expressions.Expression<Action> job
    ){
        Hangfire.BackgroundJob.ContinueJobWith(
            previousJobName,
            job
        );
    }
    public void CancelRecurringJob(string jobName){
        Hangfire.RecurringJob.RemoveIfExists(jobName);
    }
    public void CancelOneTimeJob(string jobName){
        Hangfire.BackgroundJob.Delete(jobName);
    }
}