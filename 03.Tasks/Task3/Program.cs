
namespace Task3
{
    public class Programm { 
    public static void Main(String[] args)
    {

        LinkedList<Employee> linkedList1 = new LinkedList<Employee>();

        Employee searchEmployee = new Employee("EEEE", 18);

        linkedList1.AddFirst(new Employee("AAAAA", 23));
        linkedList1.AddFirst(new Employee("BB", 41));
        linkedList1.AddFirst(new Employee("FFFF", 33));
        linkedList1.AddFirst(new Employee("AAAAA", 27));
        linkedList1.AddFirst(new Employee("AAAAA", 51));
        linkedList1.AddFirst(new Employee("EEEE", 18));
        linkedList1.AddFirst(new Employee("AAAAA", 23));
        linkedList1.AddFirst(new Employee("MMMM", 32));

        Console.WriteLine(linkedList1);

        linkedList1.Sort(new EmployeeComparator(SortType.Ascending));

        Console.WriteLine();
        Console.WriteLine(linkedList1);

        linkedList1.Sort(new EmployeeComparator(SortType.Descending));

        Console.WriteLine();
        Console.WriteLine(linkedList1);

        LinkedList<Employee>.Node resNode = linkedList1.Contains(searchEmployee);
        if (resNode != null)
        {
            Console.WriteLine("Элемент найден");
            Console.WriteLine(resNode.value);
        }
        else
        {
            Console.WriteLine("Элемент не найден");
        }
        
        Console.WriteLine("\nУдаляем первый и последний узлы");
        linkedList1.RemoveFirst();
        linkedList1.RemoveLast();
        Console.WriteLine(linkedList1);
        
        Console.WriteLine("Разворот односвязанного списка");
        linkedList1.Revert();
        Console.WriteLine(linkedList1);


    }

    }
}
