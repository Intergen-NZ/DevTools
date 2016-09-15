/// <summary>
/// Selects a random element from input list using the weights on T to sway selection.
/// T must have a Weight property on it.
/// A simplified implementation of http://programmers.stackexchange.com/a/150642/244423
/// </summary>
public T SelectRandom<T>(List<T> objects)
{
    int totalWeight = 0;
    T selected = default(T);
    foreach (T obj in objects)
    {
        int weight = obg.Weight;
        int r = new Random().Next(totalWeight + obj.Weight);
        
        if (r >= totalWeight)
            selected = obj;
        
        totalWeight += weight; 
    }
    return selected; 
}