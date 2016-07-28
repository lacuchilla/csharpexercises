using System.Collections.Generic;

namespace exercism
{
    //Passes all tests
    //fewest number of entities
    //no duplication
    //expresses developer intent
    public class Grade
    {
        private readonly List<string> _students = new List<string>();

        public List<string> GetStudents()
        {
            return _students;
        }

        public void AddStudent(string studentName)
        {
            _students.Add(studentName);
            _students.Sort();
        }
    }
    public class School
    {
        private readonly Dictionary<int, Grade> _roster = new Dictionary<int, Grade>();

        public Dictionary<int, List<string>> Roster
        {
            get
            {
                var ret = new Dictionary<int, List<string>>();
                foreach (var keyValue in _roster)
                {
                    ret.Add(keyValue.Key, keyValue.Value.GetStudents());
                }
                return ret;
            }
        }

        public void Add(int gradeLevel, string studentName)
        {
            GetOrAddGrade(gradeLevel).AddStudent(studentName);
        }

        private Grade GetOrAddGrade(int gradeLevel)
        {
            if (!_roster.ContainsKey(gradeLevel))
                _roster.Add(gradeLevel, new Grade());
            return _roster[gradeLevel];
        }

        public List<string> Grade(int gradeLevel)
        {
            return GetOrAddGrade(gradeLevel).GetStudents();
        }
    }
}