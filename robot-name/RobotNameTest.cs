using System;
using NUnit.Framework;

namespace exercism
{
    [TestFixture]
    public class RobotNameTest
    {
        private Robot _robot;

        [SetUp]
        public void Setup()
        {
            _robot = new Robot();
        }

        [Test]
        public void Robot_has_a_name()
        {
            Console.WriteLine(_robot.Name);
            StringAssert.IsMatch(@"[A-Z]{2}\d{3}", _robot.Name);
        }

        [Test]
        public void Name_is_the_same_each_time()
        {
            Assert.That(_robot.Name, Is.EqualTo(_robot.Name));
        }

        [Test]
        public void Different_robots_have_different_names()
        {
            var robot2 = new Robot();
            Assert.That(_robot.Name, Is.Not.EqualTo(robot2.Name));
        }

        [Test]
        public void Can_reset_the_name()
        {
            var originalName = _robot.Name;
            _robot.Reset();
            Assert.That(_robot.Name, Is.Not.EqualTo(originalName));
            StringAssert.IsMatch(@"[A-Z]{2}\d{3}", _robot.Name);
        }
    }
}