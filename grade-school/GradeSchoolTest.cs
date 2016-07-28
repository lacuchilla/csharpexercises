using System.Collections.Generic;
using NUnit.Framework;

namespace exercism
{
    [TestFixture]
    public class GradeSchoolTest
    {
        private School school;

        [SetUp]
        public void Setup()
        {
            school = new School();
        }

        [Test]
        public void New_school_has_an_empty_roster()
        {
            Assert.That(school.Roster, Has.Count.EqualTo(0));
        }

        [Test]
        public void Adding_a_student_adds_them_to_the_roster_for_the_given_grade()
        {
            school.Add(2, "Aimee");
            var expected = new List<string> { "Aimee" };
            Assert.That(school.Roster[2], Is.EqualTo(expected));
        }

        [Test]
        public void Adding_more_students_to_the_same_grade_adds_them_to_the_roster()
        {
            school.Add(2, "Blair");
            school.Add(2, "James");
            school.Add(2, "Paul");
            var expected = new List<string> { "Blair", "James", "Paul" };
            Assert.That(school.Roster[2], Is.EqualTo(expected));
        }

        [Test]
        public void Adding_students_to_different_grades_adds_them_to_the_roster()
        {
            school.Add(3, "Chelsea");
            school.Add(7, "Logan");
            Assert.That(school.Roster[3], Is.EqualTo(new List<string> { "Chelsea" }));
            Assert.That(school.Roster[7], Is.EqualTo(new List<string> { "Logan" }));
        }

        [Test]
        public void Grade_returns_the_students_in_that_grade_in_alphabetical_order()
        {
            school.Add(5, "Franklin");
            school.Add(5, "Bradley");
            school.Add(1, "Jeff");
            var expected = new List<string> { "Bradley", "Franklin" };
            Assert.That(school.Grade(5), Is.EqualTo(expected));
        }

        [Test]
        public void Grade_returns_an_empty_list_if_there_are_no_students_in_that_grade()
        {
            Assert.That(school.Grade(1), Is.EqualTo(new List<string>()));
        }

        [Test]
        public void Student_names_in_each_grade_in_roster_are_sorted()
        {
            school.Add(4, "Jennifer");
            school.Add(6, "Kareem");
            school.Add(4, "Christopher");
            school.Add(3, "Kyle");
            Assert.That(school.Roster[3], Is.EqualTo(new List<string> { "Kyle" }));
            Assert.That(school.Roster[4], Is.EqualTo(new List<string> { "Christopher", "Jennifer" }));
            Assert.That(school.Roster[6], Is.EqualTo(new List<string> { "Kareem" }));
        }
    }
}