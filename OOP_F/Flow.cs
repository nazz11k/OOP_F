namespace OOP_F
{
    public class Flow
    {
        public string Name;
        private int _groupsCount;
        public Group[] _groups;
        public int SubjectsCount;
        public string[] Subjects;
        public int[] LectionsCount;
        public int[] PracticesCount;

        public Flow(string name, string[] subjects, int[] lectionsCount, int[] practicesCount)
        {
            Name = name;
            Subjects = subjects;
            LectionsCount = lectionsCount;
            PracticesCount = practicesCount;
            SubjectsCount = subjects.Length;
            _groups = new Group[0];
            _groupsCount = 0;
        }

        public Flow(string name)
        {
            Name = name;
            _groups = new Group[0];
            _groupsCount = 0;
        }

        public void AddSubject(string subjects, int lections, int practices)
        {
            string[] newSubjects = new string[SubjectsCount + 1];
            int[] newLections = new int[SubjectsCount + 1];
            int[] newPracticies = new int[SubjectsCount + 1];
            for (int i = 0; i < SubjectsCount; i++)
            {
                newSubjects[i] = Subjects[i];
                newLections[i] = LectionsCount[i];
                newPracticies[i] = PracticesCount[i];
            }
            newSubjects[SubjectsCount] = Subjects[SubjectsCount];
            newLections[SubjectsCount] = LectionsCount[SubjectsCount];
            newPracticies[SubjectsCount] = PracticesCount[SubjectsCount];
            SubjectsCount += 1;
        }

        public void AddGroup()
        {
            Group[] newGroup = new Group[_groupsCount + 1];
            if (_groupsCount != 0)
            {
                for (int i = 0; i < _groupsCount; i++)
                {
                    newGroup[i] = _groups[i];
                }
                newGroup[_groupsCount] = new Group(Name, Subjects, LectionsCount, PracticesCount, _groupsCount);

            }
            else
            {
                newGroup[0] = new Group(Name, Subjects, LectionsCount, PracticesCount, _groupsCount);
            }
            _groups = newGroup;
            _groupsCount += 1;
        }

        public void AddPair(Pair pair)
        {
            if (pair.Type == "lection")
            {
                for (int i = 0; i < _groupsCount; i++)
                {
                    _groups[i].AddPair(pair);
                }
            }
            else
            {
                for (int i = 0; i < _groupsCount; i++)
                {
                    if (_groups[i].Name == pair.Group)
                    {
                        _groups[i].AddPair(pair);
                    }
                }
            }
            
        }

        public bool IsAvailable(Pair pair)
        {
            if (pair.Type == "lection")
            {
                for (int i = 0; i < _groupsCount; i++)
                {
                    if (!_groups[i].IsAvailable(pair))
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < _groupsCount; i++)
                {
                    if (_groups[i].Name == pair.Group)
                    {
                        if (!_groups[i].IsAvailable(pair))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }


    public class Flows
    {
        public Flow[] flows;
        private int count;

        public Flows()
        {
            flows = new Flow[0];
            count = 0;
        }

        public void AddFlow(string name, string[] subjects, int[] lectionsCount, int[] practicesCount)
        {
            Flow[] newFlows = new Flow[count + 1];
            if (count != 0)
            {
                for (int i = 0; i < count; i++)
                {
                    newFlows[i] = flows[i];
                }
                newFlows[count] = new Flow(name, subjects, lectionsCount, practicesCount);
            }
            else
            {
                newFlows[0] = new Flow(name, subjects, lectionsCount, practicesCount);
            }
            flows = newFlows;
            count += 1;
        }

        public void AddPair(Pair pair)
        {
            for (int i = 0; i < count; i++)
            {
                if (pair.Flow == flows[i].Name)
                {
                    flows[i].AddPair(pair);
                }
            }
        }

        public bool IsAvailable(Pair pair)
        {
            for (int i = 0; i < count; i++)
            {
                if (pair.Flow == flows[i].Name)
                {
                    if (!flows[i].IsAvailable(pair))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void AddGroup(string name)
        {
            for (int i = 0; i < count; i++)
            {
                if (flows[i].Name == name)
                {
                    flows[i].AddGroup();
                }
            }
        }
    }
}