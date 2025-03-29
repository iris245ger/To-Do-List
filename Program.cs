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
                            TaskManager.Instance.CreateTask(task);
                            break;
                        case "show":
                            TaskManager.Instance.ShowTasks();
                            break;
                        case "delete":
                            var idDel = BuildInCommand.IdParse(task);
                            if (TaskManager.Instance.Validation(cmd, idDel))
                            {
                                TaskManager.Instance.DeleteTask(idDel);
                            }
                            break;
                        case "complete":
                            var idComp = BuildInCommand.IdParse(task);
                            if (TaskManager.Instance.Validation(cmd, idComp))
                            {
                                TaskManager.Instance.CompleteTask(idComp);
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
    }
}
