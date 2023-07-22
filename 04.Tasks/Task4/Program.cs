namespace Task4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashMap<string, string> hashMap = new HashMap<string, string>(4);

            hashMap.Put("+79001112233", "Ноль");
            hashMap.Put("+79001112232", "Один");
            hashMap.Put("+79001112234", "Два");
            hashMap.Put("+79001112235", "Три");
            hashMap.Put("+79001112236", "Четыре");
            hashMap.Put("+79001112237", "Пять");
            hashMap.Put("+79001112212", "Шесть");
            hashMap.Put("+79001112213", "Семь");
            hashMap.Put("+79001112214", "Восемь");
            hashMap.Put("+79101112232", "Девять");
            hashMap.Put("+79201112234", "Десять");
            hashMap.Put("+79301112235", "Одинадцать");
            hashMap.Put("+79401112236", "Двенадцать");
            hashMap.Put("+79501112237", "Тринадцать");
            hashMap.Put("+79601112212", "Четырнадцать");

            Console.WriteLine(hashMap);
            
            // Более наглядный вывод
            //Console.WriteLine(hashMap.toPrint());
        }

    }

}