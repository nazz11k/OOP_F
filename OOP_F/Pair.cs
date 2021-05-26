namespace OOP_F
{
    public class Pair
    {
        public int Day;
        public int PairNum;
        public string Type;
        public string Flow;
        public string Group;
        public string Subject;
        public string Teacher;
        public string Auditory;

        public Pair(int day, int pairNum, string type, string group, string teacher, string discipline, string auditory)
        {
            Day = day;
            PairNum = pairNum;
            Type = type;
            Subject = discipline;
            Teacher = teacher;
            Auditory = auditory;
            Group = group; 
            Flow = group.Remove(group.Length - 1, 1);
        }

        public Pair()
        {
        }
    }
}