using KDG.Cron.Interfaces;

namespace KDG.Cron;

public class CronScheduler : ICronScheduler {

    public Task Execute(){
        return Task.CompletedTask;
    }

    public void ScheduleOneTimeJob(ICronJob job){
        Hangfire.BackgroundJob.Enqueue(() => job.Execute());
    }
    public void ScheduleOneTimeFutureJob (
        ICronJob job,
        DateTimeOffset delay
    ) {
        Hangfire.BackgroundJob.Schedule(
            () => job.Execute(),
            delay
        );
    }
    public void ScheduleRecurringJob(
        string jobName,
        ICronJob job,
        Func<string> jobSchedule
    ){
        Hangfire.RecurringJob.AddOrUpdate(
            jobName,
            () => job.Execute(),
            jobSchedule
        );
    }
    public void ScheduleJobContinuation(
        string previousJobName,
        ICronJob job
    ){
        Hangfire.BackgroundJob.ContinueJobWith(
            previousJobName,
            () => job.Execute()
        );
    }
    public void CancelRecurringJob(string jobName){
        Hangfire.RecurringJob.RemoveIfExists(jobName);
    }
    public void CancelOneTimeJob(string jobName){
        Hangfire.BackgroundJob.Delete(jobName);
    }
}