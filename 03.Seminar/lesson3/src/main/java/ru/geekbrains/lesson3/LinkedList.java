package ru.geekbrains.lesson3;

import java.util.Comparator;

/**
 * Связный список
 * @param <T>
 */
public class LinkedList<T> {

    /**
     * Указатель на первый элемент (узел) связного списка
     */
    private Node head;
    // Указатель на последний узел
    private Node tail;
    /**
     * Узел (элемент)
     */
    public class Node{

        /**
         * Указатель на следующий узел
         */
        public Node next;
        // Указатель на предыдущий узел
        public Node previous;

        /**
         * Значение узла
         */
        public T value;

    }

    // Метод разворота списка
    public void revert(){
        Node node = head;
        // меняем местами голову и хвост
        Node temp = head;
        head = tail;
        tail = temp;
        // перебор списка с поворотом указателя
        while (node.next != null){
            temp = node.next;
            node.previous = temp;
            node = node.previous;
        }
    }


    /**
     * Добавление нового элемента в начало связного списка
     * @param value значение
     */
    public void addFirst(T value){
        Node node = new Node();
        node.value = value;
        if (head != null){
            node.next = head;
        }
        head = node;
    }

    /**
     * Удалить первый элемент связного списка
     */
    public void removeFirst(){
        if (head != null){
            head = head.next;
        }
    }

    /**
     * Поиск элемента в связном списке по значению
     * @param value значение
     * @return элемент (узел)
     */
    public Node contains(T value){
        Node node = head;
        while (node != null){
            if (node.value.equals(value))
                return node;
            node = node.next;
        }
        return null;
    }

    /**
     * Сортировка
     * @param comparator
     */
    public void sort(Comparator<T> comparator){
        Node node = head;
        while (node != null){

            Node minValueNode = node;

            Node node2 = node.next;
            while (node2 != null){
                /*if (node2.value.compareTo(minValueNode.value) < 0) {
                    minValueNode = node2;
                }*/
                if (comparator.compare(minValueNode.value, node2.value) > 0){
                    minValueNode = node2;
                }
                node2 = node2.next;
            }

            if (minValueNode != node){
                T buf = node.value;
                node.value = minValueNode.value;
                minValueNode.value = buf;
            }

            node = node.next;
        }

    }

    /**
     * Добавление элемента в конец списка
     * @param value значение
     */
    public void addLast(T value){
        Node node = new Node();
        node.value = value;
        if (head == null){
            head = node;
        }
        else {
            Node lastNode = head;
            while (lastNode.next != null) {
                lastNode = lastNode.next;
            }
            lastNode.next = node;
        }
    }

    /**
     * Удаление элемента из конца связного списка
     */
    public void removeLast(){
        if (head == null)
            return;

        Node node = head;
        while (node.next != null){
            if (node.next.next == null){
                node.next = null;
                return;
            }
            node = node.next;
        }

        head = null;
    }


    @Override
    public String toString() {

        StringBuilder stringBuilder = new StringBuilder();

        Node node = head;
        while (node != null){
            stringBuilder.append(node.value);
            stringBuilder.append('\n');
            node = node.next;
        }

        return stringBuilder.toString();
    }
}
