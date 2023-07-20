
namespace Task3
{
    public class EmployeeComparator : IComparer<Employee>
    {
        private SortType sortType;

        public SortType SortType
        {
            get { return sortType; }
            set { sortType = value; }
        }

        public EmployeeComparator(SortType sortType)
        {
            this.sortType = sortType;
        }

        public int Compare(Employee x, Employee y)
        {
            // Use the CompareTo method for strings and integers
            int nameRes = sortType == SortType.Ascending ? x.GetName().CompareTo(y.GetName()) :
            y.GetName().CompareTo(x.GetName());

            if (nameRes == 0)
            {
                return sortType == SortType.Ascending ? x.GetAge().CompareTo(y.GetAge()) :
                y.GetAge().CompareTo(x.GetAge());
            }

            return nameRes;
        }
    }
}
