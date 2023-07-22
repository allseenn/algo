using System.Text;

namespace Task4
{
    public class HashMap<K, V>
    {
        private static readonly int INIT_BUCKET_COUNT = 16;
        private static readonly double LOAD_FACTOR = 1; 
        private int size;
        public Bucket<K,V>[] buckets;
        public class Entity
        {
            public K? key;
            public V? value;
        }
        public class Bucket<I, J>
        {
            public Node? head;
            public class Node
            {
                public Node? next;

                public Entity? nodeValue;
            }
            public V Add(Entity entity)
            {
                Node node = new Node();
                node.nodeValue = entity;

                if (head == null)
                {
                    head = node;
                    return default(V);
                }
                Node currentNode = head;
                while (true)
                {
                    if (currentNode.nodeValue.key.Equals(entity.key))
                    {
                        V buf = currentNode.nodeValue.value;
                        currentNode.nodeValue.value = entity.value;
                        return buf;
                    }
                    if (currentNode.next != null)
                    {
                        currentNode = currentNode.next;
                    }
                    else
                    {
                        currentNode.next = node;
                        return default(V);
                    }
                }
            }
            public V Get(K key)
            {
                Node node = head;
                while (node != null)
                {
                    if (node.nodeValue.key.Equals(key))
                    {
                        return node.nodeValue.value;
                    }
                    node = node.next;
                }
                return default(V);
            }
            public V Remove(K key)
            {
                if (head == null)
                    return default(V);
                if (head.nodeValue.key.Equals(key))
                {
                    V buf = head.nodeValue.value;
                    head = head.next;
                    return buf;
                }
                else
                {
                    Node node = head;
                    while (node.next != null)
                    {
                        if (node.next.nodeValue.key.Equals(key))
                        {
                            V buf = node.next.nodeValue.value;
                            node.next = node.next.next;
                            return buf;
                        }
                        node = node.next;
                    }
                    return default(V);
                }
            }

        }
        public int CalculateBucketIndex(K key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }
        public void Recalculate()
        {
            size = 0;
            Bucket<K, V>[] old = buckets;
            buckets = new Bucket<K, V>[old.Length * 2];
            for (int i = 0; i < old.Length; i++)
            {
                Bucket<K, V> bucket = old[i];
                if (bucket != null)
                {
                    Bucket<K,V>.Node node = bucket.head;
                    while (node != null)
                    {
                        Put(node.nodeValue.key, node.nodeValue.value);
                        node = node.next;
                    }
                }
                old[i] = null;
            }
        }
        public V Put(K key, V value)
        {
            if (buckets.Length * LOAD_FACTOR <= size)
                Recalculate();
            int index = CalculateBucketIndex(key);
            Bucket<K, V> bucket = buckets[index];
            if (bucket == null)
            {
                bucket = new Bucket<K, V>();
                buckets[index] = bucket;
            }
            Entity entity = new Entity();
            entity.key = key;
            entity.value = value;
            V ret = bucket.Add(entity);
            if (ret == null)
            {
                size++;
            }
            return ret;
        }
        public V Get(K key)
        {
            int index = CalculateBucketIndex(key);
            Bucket<K, V> bucket = buckets[index];
            if (bucket == null)
                return default(V);
            return bucket.Get(key);
        }
        public V Remove(K key)
        {
            int index = CalculateBucketIndex(key);
            Bucket<K, V> bucket = buckets[index];
            if (bucket == null)
                return default(V);
            V ret = bucket.Remove(key);
            if (ret != null)
            {
                size--;
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    var node = bucket.head;
                    while (node != null)
                    {
                        if (first)
                        {
                            first = false;
                        }
                        else
                        {
                            sb.Append("\n");
                        }
                        sb.Append(node.nodeValue.key);
                        sb.Append(", ");
                        sb.Append(node.nodeValue.value);
                        node = node.next;
                    }
                }
            }
            return sb.ToString();
        }

        public string toPrint()
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            for (int i = 0; i < buckets.Length; i++)
            {
                var bucket = buckets[i];
                if (bucket != null)
                {
                    var node = bucket.head;
                    int nodeNumber = 0;
                    while (node != null)
                    {
                        if (first)
                        {
                            first = false;
                        }
                        else
                        {
                            sb.Append("\n");
                        }
                        sb.Append("Bucket: ");
                        sb.Append(i);
                        sb.Append(", Node: ");
                        sb.Append(nodeNumber); 
                        sb.Append(", Key: ");
                        sb.Append(node.nodeValue.key);
                        sb.Append(", Value: ");
                        sb.Append(node.nodeValue.value);
                        node = node.next;
                        nodeNumber++; 
                    }
                }
            }
            return sb.ToString();
        }


        public HashMap() : this(INIT_BUCKET_COUNT)
        {

        }
        public HashMap(int initCount)
        {
            buckets = new Bucket<K, V>[initCount];
        }
    }
}
