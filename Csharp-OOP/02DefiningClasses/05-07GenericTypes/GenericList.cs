using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GenericList<T>
{
    private const int defaultCapacity = 3;
    private T[] list;
    private uint elementsCount = 0;

    public GenericList()
        : this(defaultCapacity) { }

    public GenericList(uint capacity)
    {
        this.list = new T[capacity];
    }

    public void Add(T element)
    {
        CheckListCapacity();
        list[elementsCount] = element;
        elementsCount++;
    }

    public void RemoveAt(int index)
    {
        if (index >= 0 && index < this.list.Length)
        {
            for (int i = index; i < elementsCount; i++)
            {
                list[i] = list[i + 1];
            }
            elementsCount--;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void InsertAt(int index, T element)
    {
        if (index >= 0 && index <= this.list.Length)
        {
            for (int i = this.list.Length - 1; i >= index; i--)
            {
                list[i] = list[i - 1];
            }
            list[index] = element;
            elementsCount++;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void Clear()
    {
        this.list = new T[list.Length];
        elementsCount = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index < elementsCount && index >= 0)
            {
                return list[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }

    public int IndexOf(T value)
    {
        for (int i = 0; i < this.list.Length; i++)
        {
            if (list[i].Equals(value))
            {
                return i;
            }
        }
        return -1;
    }

    private void CheckListCapacity()
    {
        if (this.elementsCount >= this.list.Length)
        {
            T[] bufferList = this.list;
            this.list = new T[this.list.Length * 2];
            for (int i = 0; i < bufferList.Length; i++)
            {
                this.list[i] = bufferList[i];
            }
        }
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < this.elementsCount; i++)
        {
            output.AppendFormat("[{0}] => {1}, ", i, list[i]);
        }
        return output.ToString();
    }

    public T Max()
    {
        dynamic maxElement = int.MinValue;
        for (int i = 0; i < this.list.Length; i++)
        {
            if (this.list[i] > maxElement)
            {
                maxElement = this.list[i];
            }
        }

        return maxElement;
    }

    public T Min()
    {
        dynamic minElement = int.MaxValue;
        for (int i = 0; i < this.list.Length; i++)
        {
            if (this.list[i] < minElement)
            {
                minElement = this.list[i];
            }
        }

        return minElement;
    }
}