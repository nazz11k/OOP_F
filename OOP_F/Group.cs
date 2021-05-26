using System;

namespace OOP_F
{
    public class Group
    {
        public string Name;
        public string Flow;
        private bool[,] _isPair;
        public string[] _subjects;
        public int[,] _lections;
        public int[,] _practics;

        public Group(string flow, string[] subjects, int[] lectionsCount, int[] practicesCount, int groupsCount)
        {
            Flow = flow;
            _subjects = subjects;
            Name = Flow + (groupsCount + 1).ToString();           
            
            _isPair = new bool[10, 4];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _isPair[i, j] = false;
                }
            }
            
            _lections = new int[subjects.Length, 2];
            _practics = new int[subjects.Length, 2];
            for (int i = 0; i < subjects.Length; i++)
            {
                _lections[i, 0] = lectionsCount[i];
                _practics[i, 0] = practicesCount[i];
                _lections[i, 1] = 0;
                _practics[i, 1] = 0;
            }
        }
        
        public bool IsAvailable(Pair pair)
        {
            int index = 0;
            for (int i = 0; i < _subjects.Length; i++)
            {
                if (_subjects[i] == pair.Subject)
                {
                    index = i;
                }
            }

            if (pair.Type == "lection")
            {
                if (_lections[index, 0] <= _lections[index, 1])
                {
                    throw new Exception("This pair is not due to plan");
                }
            }

            else
            {
                if (_practics[index, 0] <= _practics[index, 1])
                {
                    throw new Exception("This pair don`t due to plan");
                }
            }
            
            if (_isPair[pair.Day - 1, pair.PairNum - 1])
            {
                throw new Exception("The group has another pair at that time");
            }

            return true;
        }

        public void AddPair(Pair pair)
        {
            bool flag = false;
            int index = 0;
            for (int i = 0; i < _subjects.Length; i++)
            {
                if (_subjects[i] == pair.Subject)
                {
                    index = i;
                    flag = true;
                }
            }

            if (!flag)
            {
                throw new Exception("This subject is not planned for this group");
            }
            _isPair[pair.Day - 1, pair.PairNum - 1] = true;
            if (pair.Type == "lection")
            {
                _lections[index, 1] += 1;
            }
            else
            {
                _practics[index, 1] += 1;
            }
        }
    }
}