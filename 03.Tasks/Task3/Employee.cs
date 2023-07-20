
using System;

namespace Task3
{
    public class Employee
    {

        private String name;
        private int age;

        public String GetName()
        {
            return name;
        }

        public void SetName(String name)
        {
            this.name = name;
        }

        public int GetAge()
        {
            return age;
        }

        public void SetAge(int age)
        {
            this.age = age;
        }

        public Employee(String name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
                return true;
            if (obj is Employee employee){
                if (employee.name.Equals(name) && employee.age == age)
                    return true;
            }
            return false;
        }

        public override String ToString()
        {
            return String.Format("{0} - {1}", name, age);
        }
    }

}
