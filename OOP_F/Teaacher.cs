using System;

namespace OOP_F
{
    public class Teacher
    {
        public string Name;
        public string Subject;
        private bool[,] IsPair;

        public Teacher(string name, string subject)
        {
            Name = name;
            Subject = subject;
            
            IsPair = new bool[10, 4];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    IsPair[i, j] = false;
                }
            }
        }
        
        public bool IsAvailable(Pair pair)
        {
            if (Subject != pair.Subject)
            {
                throw new Exception("Wrong subject for this Teacher");
            }

            if (IsPair[pair.Day-1, pair.PairNum-1])
            {
                throw new Exception("This Teacher is not free");
            }

            return true;
        }

        public void AddPair(Pair pair)
        {
            IsPair[pair.Day - 1, pair.PairNum - 1] = true;
        }
    }



    public class Teachers
    {
        public Teacher[] _teachers;
        private int _count;

        
        public Teachers()
        {
            _teachers = new Teacher[0];
            _count = 0;
        }

        
        public Teachers(string name, string subject)
        {
            _teachers = new Teacher[1];
            _teachers[0] = new Teacher(name, subject);
            _count = 1;
        }

        
        public void AddTeacher(string name, string subject)
        {
            bool exists = false;
            for (int i = 0; i < _count; i++)
            {
                if (_teachers[i].Name == name && _teachers[i].Subject == subject)
                {
                    exists = true;
                }
            }

            if (!exists)
            {
                Teacher[] newTeachers = new Teacher[this._count + 1];
                for (int i = 0; i < this._count; i++)
                {
                    newTeachers[i] = _teachers[i];
                }

                newTeachers[this._count] = new Teacher(name, subject);
                _teachers = newTeachers;
            }
            else
            {
                throw new Exception($"The Teacher {name} is already exists");
            }

            _count += 1;
        }
        
        public bool IsAvailable(Pair pair)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_teachers[i].Name == pair.Teacher)
                {
                    if (!_teachers[i].IsAvailable(pair))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        public void AddPair(Pair pair)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_teachers[i].Name == pair.Teacher)
                {
                    _teachers[i].AddPair(pair);
                }
            }
        }
    }
}