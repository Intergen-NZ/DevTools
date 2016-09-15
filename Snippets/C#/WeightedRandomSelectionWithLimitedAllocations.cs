/// <summary>
/// Selects a random element from input list using the allocations remaining to sway selection
/// T must have AllocationRemaining, Weight and Id properties on it.
/// A modified implementation of the solution found at http://programmers.stackexchange.com/a/150642/244423
/// </summary>
public T SelectRandom<T>(List<T> objects)
{
    int totalWeight = 0;
    T selected = default(T);
    foreach (T obj in objects)
    {
        int weight = data.AllocationsRemaining;
        if (weight == 0) continue;
        
        int r = new Random().Next(totalWeight + weight);
        if (r >= totalWeight)
            selected = data;
            
        totalWeight += weight; 
    }

    if (selected == default(T))
        return objects.Where(t => t.Weight > 0).RandomElement();
    
    objects.First(t => t.Id == selected.Id).AllocationsRemaining--;
    return selected; 
}

/// <summary>
/// Allocating depending on weights, for the method above
/// </summary>
public void Allocate<T>(List<t> objects, int totalAllocations)
{
    double totalSegments = objects.Sum(t => t.Weight);
    double allocationsPerSegment = totalAllocations / totalSegments;

    foreach (T obj in objects)
    {
        obj.AllocationsRemaining = Convert.ToInt16(Math.Round(obg.Weight * allocationsPerSegment, MidpointRounding.AwayFromZero));
    }
}