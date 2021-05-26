using System;

namespace OOP_F
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Teachers teachers = new Teachers();
            Auditories auditories = new Auditories();
            Flows flows = new Flows();
            Schedule schedule = new Schedule(ref teachers, ref auditories, ref flows);
            try
            {
                teachers.AddTeacher("Teacher 1", "ChM");
                teachers.AddTeacher("Teacher 2", "VM");
                teachers.AddTeacher("Teacher 3", "TA");
                teachers.AddTeacher("Teacher 4", "OOP");
                teachers.AddTeacher("Teacher 5", "English");
                teachers.AddTeacher("Teacher 6", "Ukrainian");
                teachers.AddTeacher("Teacher 7", "Physic");
                teachers.AddTeacher("Teacher 8", "Economic");
                teachers.AddTeacher("Teacher 9", "DM");
                teachers.AddTeacher("Teacher 10", "PE");
                teachers.AddTeacher("Teacher 11", "IG");
                teachers.AddTeacher("Teacher 12", "Philosophy");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            try
            {
                auditories.AddAuditory("101");
                auditories.AddAuditory("145");
                auditories.AddAuditory("134");
                auditories.AddAuditory("216");
                auditories.AddAuditory("567");
                auditories.AddAuditory("228");
                auditories.AddAuditory("226");
                auditories.AddAuditory("364");
                auditories.AddAuditory("400");
                auditories.AddAuditory("126");
                auditories.AddAuditory("183");
                auditories.AddAuditory("278");

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            try
            {
                string[] IS_subjects = {"ChM", "TA", "English", "Ukrainian", "PE", "Physic", "OOP"};
                int[] IS_lections = {2, 2, 0, 2, 0, 3, 4};
                int[] IS_practics = {4, 3, 2, 3, 2, 3, 3};
                flows.AddFlow("IS-0", IS_subjects, IS_lections, IS_practics);
                flows.AddGroup("IS-0");
                flows.AddGroup("IS-0");
                
                string[] IP_subjects = {"IG", "TA", "English", "PE", "Physic", "OOP", "VM"};
                int[] IP_lections = {1, 2, 0, 0, 2, 3, 2};
                int[] IP_practics = {2, 2, 2, 1, 2, 3, 2};
                flows.AddFlow("IP-0", IP_subjects, IP_lections, IP_practics);
                flows.AddGroup("IP-0");
                flows.AddGroup("IP-0");
                
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            try
            {
                schedule.AddPair(new Pair(1, 1, "lection", "IS-01", "Teacher 1", "ChM", "101"));
                schedule.AddPair(new Pair(1, 2, "lection", "IS-01", "Teacher 3", "TA", "101"));
                schedule.AddPair(new Pair(1, 3, "practic", "IS-01", "Teacher 4", "OOP", "101"));
                schedule.AddPair(new Pair(1, 3, "practic", "IS-02", "Teacher 6", "Ukrainian", "278"));
                schedule.AddPair(new Pair(2, 1, "lection", "IS-01", "Teacher 7", "Physic", "228"));
                schedule.AddPair(new Pair(3, 2, "practic", "IS-01", "Teacher 1", "ChM", "278"));
                schedule.AddPair(new Pair(3, 2, "practic", "IS-02", "Teacher 4", "OOP", "145"));
                schedule.AddPair(new Pair(4, 3, "lection", "IS-01", "Teacher 6", "Ukrainian", "228"));
                schedule.AddPair(new Pair(5, 1, "practic", "IS-01", "Teacher 1", "ChM", "101"));
                schedule.AddPair(new Pair(5, 2, "practic", "IS-02", "Teacher 4", "OOP", "364"));
                schedule.AddPair(new Pair(7, 3, "lection", "IS-02", "Teacher 4", "OOP", "101"));
                schedule.AddPair(new Pair(7, 4, "lection", "IS-01", "Teacher 1", "ChM", "101"));
                schedule.AddPair(new Pair(8, 1, "practic", "IS-01", "Teacher 10", "PE", "103"));
                schedule.AddPair(new Pair(8, 1, "practic", "IS-02", "Teacher 5", "English", "101"));
                schedule.AddPair(new Pair(8, 3, "practic", "IS-02", "Teacher 10", "PE", "103"));
                schedule.AddPair(new Pair(8, 3, "practic", "IS-01", "Teacher 5", "English", "101"));
                schedule.AddPair(new Pair(9, 1, "lection", "IS-01", "Teacher 7", "Physic", "101"));
                schedule.AddPair(new Pair(9, 2, "practic", "IS-01", "Teacher 10", "PE", "228"));
                schedule.AddPair(new Pair(9, 3, "practic", "IS-02", "Teacher 10", "PE", "228"));
                schedule.AddPair(new Pair(10, 1, "lection", "IS-01", "Teacher 4", "OOP", "228"));
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            while (true)
            {
                Console.WriteLine("\nChoose option:");
                Console.WriteLine("1. Print schedule for group");
                Console.WriteLine("2. Print schedule for auditory");
                Console.WriteLine("3. Print schedule for teacher");
                Console.WriteLine("4. Print flows information");
                Console.WriteLine("5. Print group information");
                Console.WriteLine("6. Print auditories list");
                Console.WriteLine("7. Print teachers list");
                Console.WriteLine("8. Exit");
                
                string key = Console.ReadLine();
                switch (key)
                {
                    case "1":
                        Console.WriteLine("Choose a group:");
                        string group = Console.ReadLine();
                        bool flag = false;
                        for (int i = 0; i < flows.flows.Length; i++)
                        {
                            for (int j = 0; j < flows.flows[i]._groups.Length; j++)
                            {
                                if (group == flows.flows[i]._groups[j].Name)
                                {
                                    flag = true;
                                }
                            }
                        }
                        try
                        {
                            if (!flag)
                            {
                                throw new Exception("This group do not exists");
                            }
                            PrintSchedule(schedule.ScheduleGroup(group), "group");
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    
                    
                    case "2":
                        bool flag1 = false;
                        Console.WriteLine("Choose a auditory:");
                        string auditory = Console.ReadLine();
                        for (int i = 0; i < auditories._cabinets.Length; i++)
                        {
                            if (auditories._cabinets[i].Name == auditory)
                            {
                                flag1 = true;
                            }
                        }

                        try
                        {
                            if (flag1)
                            {
                                PrintSchedule(schedule.ScheduleAuditory(auditory), "auditory");
                            }
                            else
                            {
                                throw new Exception("Auditory do not exists");
                            }
                            
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    
                    
                    case "3":
                        bool flag2 = false;
                        Console.WriteLine("Choose a teacher:");
                        string teacher = Console.ReadLine();
                        for (int i = 0; i < teachers._teachers.Length; i++)
                        {
                            if (teachers._teachers[i].Name == teacher)
                            {
                                flag2 = true;
                            }
                        }

                        try
                        {
                            if (flag2)
                            {
                                PrintSchedule(schedule.ScheduleTeacher(teacher), "teacher");
                            }
                            else
                            {
                                throw new Exception("Auditory do not exists");
                            }
                            
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    
                    case "4":
                        PrintFlows();
                        break;
                   
                    case "5":
                        try
                        {
                            Console.WriteLine("Choose a group: ");
                            string grup = Console.ReadLine();
                            PrintGroupInfo(grup);
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        break;
                    case "6":
                        Console.WriteLine("Teachers List:");
                        for (int i = 0; i < teachers._teachers.Length; i++)
                        {
                            Console.WriteLine($"  {teachers._teachers[i].Name} ({teachers._teachers[i].Subject})");
                        }
                        break;
                    case "7":
                        Console.WriteLine("Auditories List:");
                        for (int i = 0; i < auditories._cabinets.Length; i++)
                        {
                            Console.WriteLine($"  {auditories._cabinets[i].Name}");
                        }
                        break;
                    case "8":
                        return;
                    
                    default:
                        Console.WriteLine("This is wrong number");
                        break;
                }
            }




            void PrintGroupInfo(string _group)
            {
                bool flag = false;
                int flow = 0;
                int group = 0;
                for (int i = 0; i < flows.flows.Length; i++)
                {
                    for (int j = 0; j < flows.flows[i]._groups.Length; j++)
                    {
                        if (_group == flows.flows[i]._groups[j].Name)
                        {
                            flag = true;
                            flow = i;
                            group = j;
                        }
                    }
                }

                if (flag)
                {
                    Console.WriteLine($"Group: {_group}");
                    Console.WriteLine($"  Study plan and pairs");
                    for (int i = 0; i < flows.flows[flow]._groups[group]._subjects.Length; i++)
                    {
                        Console.WriteLine($"{  flows.flows[flow]._groups[group]._subjects[i]}:\n   lecs: {flows.flows[flow]._groups[group]._lections[i, 1]}({flows.flows[flow]._groups[group]._lections[i, 0]})\n   pracs: {flows.flows[flow]._groups[group]._practics[i, 1]}({flows.flows[flow]._groups[group]._practics[i, 0]}) ");
                    }
                    
                }
                else
                {
                    throw new Exception("This group don`t exists");
                }
            }
            
            void PrintFlows()
            {
                for (int i = 0; i < flows.flows.Length; i++)
                {
                    Console.WriteLine($"{     flows.flows[i].Name} details");
                    Console.WriteLine("Groups list");
                    for (int j = 0; j < flows.flows[i]._groups.Length; j++)
                    {
                        Console.WriteLine($"   {flows.flows[i]._groups[j].Name}");
                    }
                    Console.WriteLine("Study plan(lections, practics:");
                    for (int j = 0; j < flows.flows[i].SubjectsCount; j++)
                    {
                        Console.WriteLine($"  {flows.flows[i].Subjects[j]} ({flows.flows[i].LectionsCount[j]},{flows.flows[i].PracticesCount[j]})");
                    }
                }
            }
            
            
            
            void PrintSchedule(Pair[,] timetable, string option)
            {
                string[] Days =
                {
                    "Monday(1-st week)", "Tuesday(1-st week)", "Wednesday(1-st week)", "Thursday(1-st week)",
                    "Friday(1-st week)", "Monday(2-nd week)", "Tuesday(2-nd week)", "Wednesday(2-nd week)",
                    "Thursday(2-nd week)",
                    "Friday(2-nd week)"
                };

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"       {Days[i]}");

                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write((j + 1).ToString() + ". ");

                        switch (option)
                        {
                            case "teacher":
                                if (timetable[i, j].Type == "lection")
                                {
                                    Console.Write($"{timetable[i,j].Flow}  {timetable[i,j].Subject}({timetable[i,j].Type})   {timetable[i,j].Auditory}\n");
                                }

                                else if (timetable[i, j].Type == "practic")
                                {
                                    Console.Write($"{timetable[i,j].Group}  {timetable[i,j].Subject}({timetable[i,j].Type})   {timetable[i,j].Auditory}\n");
                                }

                                else
                                {
                                    Console.Write("\n");
                                }

                                break;
                            case "auditory":
                                if (timetable[i, j].Type == "lection")
                                {
                                    Console.Write($"{timetable[i,j].Flow}x  {timetable[i,j].Subject}({timetable[i,j].Type})   {timetable[i,j].Teacher}\n");
                                }

                                else if (timetable[i, j].Type == "practic")
                                {
                                    Console.Write($"{timetable[i,j].Group}  {timetable[i,j].Subject}({timetable[i,j].Type})   {timetable[i,j].Teacher}\n");
                                }

                                else
                                {
                                    Console.Write("\n");
                                }

                                break;
                            case "group":
                                if (timetable[i, j].Type == "lection")
                                {
                                    Console.Write($"{timetable[i,j].Subject}({timetable[i,j].Type})   {timetable[i,j].Teacher}   {timetable[i,j].Auditory}\n");
                                }

                                else if (timetable[i, j].Type == "practic")
                                {
                                    Console.Write($"{timetable[i,j].Subject}({timetable[i,j].Type})   {timetable[i,j].Teacher}   {timetable[i,j].Auditory}\n");
                                }

                                else
                                {
                                    Console.Write("\n");
                                }

                                break;
                        }
                    }
                }
            }
        }
    }
}