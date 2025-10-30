using JonDou9000.TaskPlanner.Domain.Models;
using JonDou9000.TaskPlanner.Domain.Models.Enums;
using JonDou9000.TaskPlanner.Domain.Logic;

internal class Program
{
    public static void Main(string[] args)
    {
        var items = new List<WorkItem>();

        Console.WriteLine("Enter tasks (empty title to stop):");
        while (true)
        {
            Console.Write("Title: ");
            string? title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title)) break;

            Console.Write("Description: ");
            string? description = Console.ReadLine();

            Console.Write("Due date (dd.MM.yyyy): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine() ?? "");

            Console.Write("Priority (None, Low, Medium, High, Urgent): ");
            Priority priority = Enum.Parse<Priority>(Console.ReadLine() ?? "None", true);

            Console.Write("Complexity (None, Minutes, Hours, Days, Weeks): ");
            Complexity complexity = Enum.Parse<Complexity>(Console.ReadLine() ?? "None", true);

            items.Add(new WorkItem
            {
                Title = title,
                Description = description ?? "",
                DueDate = dueDate,
                CreationDate = DateTime.Now,
                Priority = priority,
                Complexity = complexity
            });
        }

        var planner = new SimpleTaskPlanner();
        var sorted = planner.CreatePlan(items.ToArray());

        Console.WriteLine("\nSorted tasks:");
        foreach (var item in sorted)
            Console.WriteLine(item);
    }
}
