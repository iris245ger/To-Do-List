namespace To_Do_List
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.Write("To-Do List: ");
                    var input = Console.ReadLine();
                    if (input != null) {
                        TaskManager.Instance.Manager(input);
                    }
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
