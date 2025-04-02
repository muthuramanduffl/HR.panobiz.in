using Quartz;
using Quartz.Impl;
using System;
  

    public class JobScheduler
    {
        public static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<DocVerified.MyJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()

            //.WithIdentity("trigger1", "group1")
            //.StartNow()
            //.WithSimpleSchedule
            //(x => x
            ////.WithIntervalInSeconds(60)
            //.WithIntervalInMinutes(1)
            //.RepeatForever()
            //)

            .WithDailyTimeIntervalSchedule
            (s =>
            s.WithIntervalInHours(24)
            .OnEveryDay()
            .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(13,05))
            .InTimeZone(INDIAN_ZONE)
            )
            .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }


