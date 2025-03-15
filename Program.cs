namespace To_Do_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.Write("To-Do List: ");
                    var input = Console.ReadLine();
                    var cmd = input.Split(' ', 2)[0];
                    var task = BuildInCommand.TaskParse(input);

                    switch (cmd)
                    {
                        case "add":
                            BuildInCommand.CreateTask(SavedTasks.Instance, task); 
                            break;
                        case "show":
                            BuildInCommand.ShowTasks(SavedTasks.Instance);
                            break;
                        case "delete":
                            var idDel = BuildInCommand.IdParse(task);
                            if (BuildInCommand.Validation(SavedTasks.Instance, cmd, idDel))
                            {
                                BuildInCommand.DeleteTask(SavedTasks.Instance, idDel);
                            }
                            break;
                        case "complete":
                            var idComp = BuildInCommand.IdParse(task);
                            if (BuildInCommand.Validation(SavedTasks.Instance, cmd, idComp))
                            {
                                BuildInCommand.CompleteTask(SavedTasks.Instance, idComp);
                            }
                            break;
                        case "exit":
                            BuildInCommand.Exit();
                            break;
                        default:
                            Console.WriteLine("Please use buid-in commands: " +
                                "\n add: to add a new task" +
                                "\n show: show all added tasks" +
                                "\n delete id: delete the task with the corresponding id" +
                                "\n complete id: mark the task with the corresponding id as completed");
                            break;
                    }
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        public class Task
        {
            public string Body { get; set; }
            public bool IsCompleted { get; set; }
        }

        public class SavedTasks
        {
            private SavedTasks() { }
            private static SavedTasks instance;
            public static SavedTasks Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new SavedTasks();
                    }
                    return instance;
                }
            }
            public List<Task> tasks = new List<Task>();
        }

        public static class BuildInCommand
        {
            public static void CreateTask (SavedTasks saved, string newTask)
            {
                if (newTask != null)
                {
                    saved.tasks.Add(new Task()
                    {
                        Body = newTask,
                        IsCompleted = false
                    });
                    Console.WriteLine("Task created!");
                }
                else Console.WriteLine("Not valid task, try again");
            }

            public static void ShowTasks (SavedTasks saved)
            {
                if (saved.tasks.Count > 0)
                {
                    for (int i = 0; i < saved.tasks.Count(); i++)
                    {
                        Console.WriteLine($"{BuildInCommand.ToShowId(i)}: {saved.tasks[i].Body}, Completed: {saved.tasks[i].IsCompleted}");
                    }
                }
                else Console.WriteLine("No tasks found");
            }

            public static void DeleteTask(SavedTasks saved, int Index)
            {
                saved.tasks.RemoveAt(BuildInCommand.ToInternalId(Index));
                Console.WriteLine($"Task# {Index} successfully deleted!");
            }

            public static void CompleteTask(SavedTasks saved, int Index)
            {
                saved.tasks[BuildInCommand.ToInternalId(Index)].IsCompleted = true;
                Console.WriteLine($"Task# {Index} successfully completed!");
            }

            public static bool Validation (SavedTasks saved, string cmd, int index)
            {
                var internalId = BuildInCommand.ToInternalId(index);
                Console.WriteLine($"Are you sure you want to {cmd} Task# {index}? yes/no");
                if (Console.ReadLine() == "yes" && internalId < saved.tasks.Count() && internalId >= 0)
                {
                    return true;
                } else {
                    Console.WriteLine("Try again");
                    return false;
                } 
            } 

            public static string TaskParse (string input) {
                if (input.Split(' ', 2).Length > 1)
                {
                    return input.Split(' ', 2)[1];
                }
                else return null;
            }

            public static int IdParse(string input)
            {
                int result;
                if (int.TryParse(input, out result)) return result;
                else return 0;
            }

            public static int ToShowId (int id)
            {
                return id + 1;
            }

            public static int ToInternalId(int id)
            {
                return id - 1;
            }

            public static void Exit()
            {
                Environment.Exit(0);
            }
        }

    }
}
