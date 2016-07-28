namespace exercism
{
    public class SpaceAge
    {
        private readonly long _seconds;

        public SpaceAge(long seconds)
        {
            _seconds = seconds;
        }

        public long Seconds()
        {
            return _seconds;
        }

        public double OnEarth()
        {
            var convertToMinutes = _seconds/60d;
            var convertToHours = convertToMinutes/60d;
            var convertToDays = convertToHours/24d;
            var convertToYears = convertToDays/365.25d;
            return convertToYears;
        }

        public double OnMercury()
        {
            return OnEarth()/0.2408467;
        }

        public double OnVenus()
        {
            return OnEarth()/0.61519726;
        }

        public double OnMars()
        {
            return OnEarth()/1.8808158;
        }

        public double OnJupiter()
        {
            return OnEarth()/11.862615;
        }

        public double OnUranus()
        {
            return OnEarth()/84.016846;
        }

        public double OnSaturn()
        {
            return OnEarth()/29.447498;
        }

        public double OnNeptune()
        {
            return OnEarth()/164.79132;
        }
    }
}