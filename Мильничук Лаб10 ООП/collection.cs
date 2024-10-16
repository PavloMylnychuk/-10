using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            yield return elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
