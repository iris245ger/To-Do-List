using System;
using System.Collections.Generic;
using static To_Do_List.Program;
using static To_Do_List.TaskManager;

namespace To_Do_List
{
    internal static class BuildInCommand
    {
        public static void CreateTask(this TaskManager saved, string newTask)
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

        public static void ShowTasks(this TaskManager saved)
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

        public static void DeleteTask(this TaskManager saved, int Index)
        {
            saved.tasks.RemoveAt(BuildInCommand.ToInternalId(Index));
            Console.WriteLine($"Task# {Index} successfully deleted!");
        }

        public static void CompleteTask(this TaskManager saved, int Index)
        {
            saved.tasks[ToInternalId(Index)].IsCompleted = true;
            Console.WriteLine($"Task# {Index} successfully completed!");
        }

        public static bool Validation(this TaskManager saved, string cmd, int index)
        {
            var internalId = BuildInCommand.ToInternalId(index);
            Console.WriteLine($"Are you sure you want to {cmd} Task# {index}? yes/no");
            if (Console.ReadLine() == "yes" && internalId < saved.tasks.Count() && internalId >= 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Try again");
                return false;
            }
        }

        public static string? TaskParse(string input)
        {
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

        public static int ToShowId(int id)
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
