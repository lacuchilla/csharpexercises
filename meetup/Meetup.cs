using System;

namespace exercism.meetup
{

    #region Adjusters

    public interface IDayAdjuster
    {
        DateTime Adjust(DateTime day);
    }

    public class AddWeeksDayAdjuster : IDayAdjuster
    {
        private readonly int _weeksToAdd;

        public AddWeeksDayAdjuster(int weeksToAdd)
        {
            _weeksToAdd = weeksToAdd;
        }

        public DateTime Adjust(DateTime day)
        {
            return day.AddWeeks(_weeksToAdd);
        }
    }


    public class DayAdjusterFactory
    {
        public static IDayAdjuster Create(Schedule schedule)
        {
            switch (schedule)
            {
                case Schedule.Teenth:
                    return new AddUntilTeenthAdjuster();
                case Schedule.First:
                    return new AddWeeksDayAdjuster(0);
                case Schedule.Second:
                    return new AddWeeksDayAdjuster(1);
                case Schedule.Third:
                    return new AddWeeksDayAdjuster(2);
                case Schedule.Fourth:
                    return new AddWeeksDayAdjuster(3);
                case Schedule.Last:
                    return new AddUntilLastInMonthAdjuster();
                default:
                    throw new ArgumentOutOfRangeException(nameof(schedule));
            }
        }
    }

    public class AddUntilTeenthAdjuster : TryOneThenTheOtherAdjuster
    {
        public AddUntilTeenthAdjuster() : base(
            new AddWeeksDayAdjuster(1), new AddWeeksDayAdjuster(2))
        {
        }

        protected override bool Check(DateTime current, DateTime original)
        {
            return current.Day >= 13;
        }
    }

    public abstract class TryOneThenTheOtherAdjuster : IDayAdjuster
    {
        private readonly IDayAdjuster _first;
        private readonly IDayAdjuster _second;

        protected TryOneThenTheOtherAdjuster(IDayAdjuster first, IDayAdjuster second)
        {
            _first = first;
            _second = second;
        }

        public DateTime Adjust(DateTime day)
        {
            var first = _first.Adjust(day);
            if (Check(first, day))
                return first;
            return _second.Adjust(day);
        }

        protected abstract bool Check(DateTime current, DateTime original);
    }

    public class AddUntilLastInMonthAdjuster : TryOneThenTheOtherAdjuster
    {
        public AddUntilLastInMonthAdjuster() : base(new AddWeeksDayAdjuster(4), new AddWeeksDayAdjuster(3))
        {
        }

        protected override bool Check(DateTime current, DateTime original)
        {
            return current.Month == original.Month;
        }
    }

    #endregion

    #region schedule

    public enum Schedule
    {
        Teenth,
        Last,
        Fourth,
        Third,
        Second,
        First
    }

    #endregion

    #region helpers

    public static class DateTimeHelpers
    {
        public static DateTime AddWeeks(this DateTime dateTime, int numWeeks)
        {
            return dateTime.AddDays(7*numWeeks);
        }
    }

    #endregion

    public class Meetup
    {
        private readonly int _month;
        private readonly int _year;

        public Meetup(int month, int year)
        {
            _month = month;
            _year = year;
        }

        public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
        {
            var adjuster = DayAdjusterFactory.Create(schedule);
            for (var dayOfMonth = 1; dayOfMonth <= 7; dayOfMonth++)
            {
                var day = new DateTime(_year, _month, dayOfMonth);
                if (day.DayOfWeek == dayOfWeek)
                {
                    return adjuster.Adjust(day);
                }
            }
            throw new ArgumentOutOfRangeException(nameof(dayOfWeek));
        }
    }
}