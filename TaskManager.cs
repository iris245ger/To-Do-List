namespace To_Do_List
{
    public class TaskManager
    {
        private TaskManager() { }
        private static TaskManager instance;
        public static TaskManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaskManager();
                }
                return instance;
            }
        }
        public List<Task> tasks = new List<Task>();
    }
}
