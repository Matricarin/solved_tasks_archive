public class LRUCache
{
    private LinkedList<int> _list;
    private Dictionary<int,int> _dict;
    private readonly int _capacity;
    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _dict = new Dictionary<int,int>(capacity);
        _list = new LinkedList<int>();
    }

    public int Get(int key)
    {
        if(_dict.TryGetValue(key, out var value))
        {
            _list.Remove(key);
            _list.AddFirst(key);
            return value;
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
            _dict[key] = value;
            _list.Remove(key);
            _list.AddFirst(key);
        }
        else
        {
            if(_dict.Count < _capacity)
            {
                _dict.Add(key, value);
                _list.AddFirst(key);
            }
            else
            {
                var last = _list.Last;
                _list.RemoveLast();
                _list.AddFirst(key);
                _dict.Remove(last.Value);
                _dict.Add(key, value);
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