public class LRUCache
{
    private LinkedList<ValueTuple<int, int>> _list;
    private Dictionary<int, LinkedListNode<ValueTuple<int, int>>> _dict;
    private readonly int _capacity;
    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _dict = new Dictionary<int, LinkedListNode<ValueTuple<int, int>>>(capacity);
        _list = new LinkedList<ValueTuple<int, int>>();
    }

    public int Get(int key)
    {
        if(_dict.TryGetValue(key, out var value))
        {
            _list.Remove(value);
            _list.AddFirst(value);
            return value.Value.Item2;
        }
        else
        {
            return -1;
        }
    }

    public void Put(int key, int value)
    {
        if(_dict.ContainsKey(key))
        {
            _dict[key].Value = new (key, value);
            _list.Remove(_dict[key]);
            _list.AddFirst(_dict[key]);
        }
        else
        {
            var item = new LinkedListNode<ValueTuple<int, int>>(new (key, value));
            if(_dict.Count < _capacity)
            {
                _dict.Add(key, item);
                _list.AddFirst(item);
            }
            else
            {
                var last = _list.Last;
                _list.RemoveLast();
                _list.AddFirst(item);
                _dict.Remove(last.Value.Item1);
                _dict.Add(key, item);
            }
        }
        
    }
}


/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */