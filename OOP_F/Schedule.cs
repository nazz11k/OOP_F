using System.Collections.Generic;
using System.Linq;

namespace OOP_F
{
    public class Schedule
    {
        private Teachers _teachers;
        private Auditories _auditories;
        private Flows _flows;
        private List<Pair>[,] schedule;

        public Schedule(ref Teachers teachers, ref Auditories auditories, ref Flows flows)
        {
            _teachers = teachers;
            _auditories = auditories;
            _flows = flows;
            schedule = new List<Pair>[10, 4];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    schedule[i, j] = new List<Pair>();
                }
            }
        }

        public bool IsAvailable(Pair pair)
        {
            if (!_teachers.IsAvailable(pair))
            {
                return false;
            }

            if (!_auditories.IsAvailable(pair))
            {
                return false;
            }

            if (!_flows.IsAvailable(pair))
            {
                return false;
            }

            return true;
        }

        public void AddPair(Pair pair)
        {
            if (this.IsAvailable(pair))
            {
                _auditories.AddPair(pair);
                _flows.AddPair(pair);
                _teachers.AddPair(pair);
                schedule[pair.Day - 1, pair.PairNum - 1].Add(pair);
            }
        }

        public Pair[,] ScheduleTeacher(string teacher)
        {
            Pair[,] timetable = new Pair[10, 4];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bool flag = false;
                    foreach (var pair in schedule[i, j])
                    {
                        if (pair.Teacher == teacher)
                        {
                            timetable[i, j] = pair;
                            flag = true;
                        }
                    }

                    if (!flag)
                    {
                        timetable[i, j] = new Pair();
                    }
                }
            }

            return timetable;
        }
        
        public Pair[,] ScheduleAuditory(string auditory)
        {
            Pair[,] timetable = new Pair[10, 4];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bool flag = false;
                    foreach (var pair in schedule[i, j])
                    {
                        if (pair.Auditory == auditory)
                        {
                            timetable[i, j] = pair;
                            flag = true;
                        }
                    }

                    if (!flag)
                    {
                        timetable[i, j] = new Pair();
                    }
                }
            }

            return timetable;
        }
        
        public Pair[,] ScheduleGroup(string group)
        {
            Pair[,] timetable = new Pair[10, 4];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    bool flag = false;
                    foreach (var pair in schedule[i, j])
                    {
                        if ((pair.Group == group && pair.Type == "practic") || (pair.Type == "lection" && pair.Flow == group.Remove(group.Length - 1, 1)))
                        {
                            timetable[i, j] = pair;
                            flag = true;
                        }
                    }

                    if (!flag)
                    {
                        timetable[i, j] = new Pair();
                    }
                }
            }

            return timetable;
        }
    }
}