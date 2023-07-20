using System.Text;

namespace Task3
{
    public class LinkedList<T>
    {
        // Указатель на первый элемент (узел) связного списка
        private Node head;
        // Узел (элемент)
        public class Node
        {
            // Указатель на следующий узел
            public Node? next;
            // Значение узла
            public T? value;
        }
        // Добавление нового элемента в начало связного списка @param value значение
        public void AddFirst(T value)
        {
            Node node = new Node();
            node.value = value;
            if (head != null)
            {
                node.next = head;
            }
            head = node;
        }
        // Удалить первый элемент связного списка
        public void RemoveFirst()
        {
            if (head != null)
            {
                head = head.next;
            }
        }

        // Поиск элемента в связном списке по значению @param value значение @return элемент (узел)
        public Node Contains(T value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value.Equals(value))
                    return node;
                node = node.next;
            }
            return null;
        }
        // Сортировка @param comparer
        public void Sort(IComparer<T> comparer)
        {
            Node node = head;
            while (node != null)
            {
                Node minValueNode = node;
                Node node2 = node.next;
                while (node2 != null)
                {
                    if (comparer.Compare(minValueNode.value, node2.value) > 0)
                    {
                        minValueNode = node2;
                    }
                    node2 = node2.next;
                }
                if (minValueNode != node)
                {
                    T buf = node.value;
                    node.value = minValueNode.value;
                    minValueNode.value = buf;
                }
                node = node.next;
            }

        }
        // Добавление элемента в конец списка @param value значение
        public void addLast(T value)
        {
            Node node = new Node();
            node.value = value;
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node lastNode = head;
                while (lastNode.next != null)
                {
                    lastNode = lastNode.next;
                }
                lastNode.next = node;
            }
        }
        // Удаление элемента из конца связного списка
        public void RemoveLast()
        {
            if (head == null)
                return;
            Node node = head;
            while (node.next != null)
            {
                if (node.next.next == null)
                {
                    node.next = null;
                    return;
                }
                node = node.next;
            }
            head = null;
        }


        // Функция разворота связанного списка
        public void Revert()
        {
            // Если список пуст или содержит один элемент, то ничего не делаем
            if (head == null || head.next == null)
                return;

            // Инициализируем три указателя: предыдущий, текущий и следующий
            Node prev = null;
            Node curr = head;
            Node next = null;

            // Пока текущий узел не равен null, выполняем следующие шаги:
            while (curr != null)
            {
                // Запоминаем следующий узел
                next = curr.next;
                // Меняем направление ссылки текущего узла на предыдущий
                curr.next = prev;
                // Перемещаем предыдущий и текущий узлы на один шаг вперёд
                prev = curr;
                curr = next;
            }

            // Обновляем голову списка на последний обработанный узел
            head = prev;
        }

        public override String ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Node node = head;
            while (node != null)
            {
                stringBuilder.Append(node.value);
                stringBuilder.Append('\n');
                node = node.next;
            }
            return stringBuilder.ToString();
        }
    }
}
