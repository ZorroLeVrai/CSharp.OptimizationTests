namespace Exploration.Dictionaries;

internal class MyDico<TKey, TValue>
{
    private List<BucketData>[] buckets;
    private int bucketCapacity;

    public int Count
    {
        get; private set;
    }

    public MyDico(int capacity = 32)
    {
        buckets = new List<BucketData>[capacity];
        bucketCapacity = capacity;
    }

    private void ResizeBuckets(int newCapacity)
    {
        var newBuckets = new List<BucketData>[newCapacity];
        foreach (var bucket in buckets)
        {
            if (bucket == null)
                continue;

            foreach (var bucketData in bucket)
            {
                var newBucketIndex = GetBucketIndex(bucketData.HashCode, newCapacity);
                if (newBuckets[newBucketIndex] == null)
                    newBuckets[newBucketIndex] = new List<BucketData> { bucketData };

                newBuckets[newBucketIndex].Add(bucketData);
            }
        }

        buckets = newBuckets;
        bucketCapacity = newCapacity;
    }

    private int GetBucketIndex(int hashCode, int capacity) => hashCode % capacity;

    private BucketInfo GetBucketInfo(TKey key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var hashCode = key.GetHashCode();
        var bucketIndex = GetBucketIndex(hashCode, bucketCapacity);
        return new BucketInfo(hashCode, bucketIndex, buckets[bucketIndex]);
    }

    private bool TryGetBucketDataWithKey(TKey key, out BucketData? bucketKeyData)
    {
        var bucketInfo = GetBucketInfo(key);
        if (bucketInfo.BucketData == null)
        {
            bucketKeyData = null;
            return false;
        }

        bucketKeyData = bucketInfo.BucketData.FirstOrDefault(b => b.Key!.Equals(key));
        return bucketKeyData != null;
    }

    public bool ContainsKey(TKey key)
    {
        return TryGetBucketDataWithKey(key, out BucketData? _);
    }

    private void IncrementCount()
    {
        ++Count;

        if (buckets.Length * 0.75 < Count)
            ResizeBuckets(buckets.Length * 2);
    }

    public void Add(TKey key, TValue value)
    {
        var (hashCode, bucketIndex, storedData) = GetBucketInfo(key);
        var newBucketData = new BucketData(hashCode, key, value);

        if (storedData == null)
        {
            buckets[bucketIndex] = new List<BucketData> { newBucketData };
        }
        else
        {
            if (storedData.Any(b => b.Key!.Equals(key)))
                throw new ArgumentException("An element with the same key already exists in the dictionary.");

            storedData.Add(newBucketData);
        }

        IncrementCount();
    }

    public TValue this[TKey key]
    {
        get
        {
            if (!TryGetBucketDataWithKey(key, out var bucketData))
                throw new KeyNotFoundException();

            return bucketData!.Value;
        }
        set
        {
            var (hashCode, bucketIndex, storedData) = GetBucketInfo(key);
            if (storedData == null)
            {
                //new bucket
                buckets[bucketIndex] = new List<BucketData> { new BucketData(hashCode, key, value) };
                IncrementCount();
            }
            else
            {
                BucketData? bucketDataItem = storedData.Find(b => b.Key!.Equals(key));
                if (bucketDataItem == null)
                {
                    //new key in existing bucket
                    storedData.Add(new BucketData(hashCode, key, value));
                    IncrementCount();
                }
                else
                {
                    //update existing key in existing bucket
                    bucketDataItem.Value = value;
                }
            }
        }
    }

    private record BucketInfo(int HashCode, int BucketIndex, List<BucketData> BucketData);

    private record BucketData(int HashCode, TKey Key, TValue Value)
    {
        public TValue Value { get; set; } = Value;
    }
}
