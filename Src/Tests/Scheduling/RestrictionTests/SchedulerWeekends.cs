using System;
using Coravel.Scheduling.Schedule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tests.Scheduling.Helpers.SchedulingTestHelpers;

namespace Tests.Scheduling.RestrictionTests
{
    [TestClass]
    public class SchedulerWeekends
    {
        [TestMethod]
        [DataTestMethod]
        public void DailyOnWeekendsOnly()
        {
            var scheduler = new Scheduler();
            int taskRunCount = 0;

            scheduler.Schedule(() => taskRunCount++)
            .Daily()
            .Weekend();

            scheduler.RunAt(DateTime.Parse("2018/06/09")); //Sat
            scheduler.RunAt(DateTime.Parse("2018/06/10")); //Sun
            scheduler.RunAt(DateTime.Parse("2018/06/11")); //Mon
            scheduler.RunAt(DateTime.Parse("2018/06/12")); //Tue
            scheduler.RunAt(DateTime.Parse("2018/06/13")); //W
            scheduler.RunAt(DateTime.Parse("2018/06/14")); //T
            scheduler.RunAt(DateTime.Parse("2018/06/15")); //F
            scheduler.RunAt(DateTime.Parse("2018/06/16")); //S
            scheduler.RunAt(DateTime.Parse("2018/06/17")); //S
            scheduler.RunAt(DateTime.Parse("2018/06/18")); //M

            Assert.IsTrue(taskRunCount == 4);
        }
    }
}