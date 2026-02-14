using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ListCreate;


class MyList<T> where T: IComparable<T>
{
    private int size=0;
    private bool isSort = false;
    private Node<T> head;
    private Node<T> tail = null;

    public MyList(T val)
    {
        this.head=  new Node<T>(val);
        this.tail = head;
        this.size = size + 1;
    }

    public int ListSize()
    {
        return this.size;
    }

    public Node<T> ReturnHead()
    {
        if (this.head != null)
            return this.head;
        else
            return null;
    }

    public void Swap(T val1, T val2)
    {
        bool forVal1 = false;
        bool forVal2 = false;
        Node<T> current = head;
        Node<T> tmp1=new Node<T>();
        Node<T> tmp2=new Node<T>();
        while (current!=null)
        {
            if (!forVal1 && (current.val.CompareTo(val1)==0))
            {
                tmp1 = current;
                forVal1 = true;
            }
            else if(! forVal2 && (current.val.CompareTo(val2)==0))
            {
                tmp2 = current;
                forVal2 = true;
            }

            if (forVal1 && forVal2) break;
            current = current.next;
        }

        T exchangeVal=tmp1.val;
        tmp1.val = tmp2.val;
        tmp2.val = exchangeVal;
        

    } 

    public static void Marge(int st,int mid ,int end,T []array)
    
    {
        List<T> list= new List<T>();
        int i = st;
        int j = mid + 1;
        while (i <= mid && j <= end)
        {
            if (array[i].CompareTo(array[j])<=0)
            {
                list.Add(array[i]);
                i++;
            }
            else
            {
                list.Add(array[j]);
                j++;
            }
        }

        while (i <= mid)
        {
            list.Add(array[i]);
            i++;
        }

        while (j<=end)
        {
            list.Add(array[j]);
            j++;
        }

        for (int it = 0; it < list.Count ; it++)
        {
            array[it+st] = list[it];
        }
        
    }

    public void Delete(T val)
    {
        bool flag = false;
        if (this.size == 0)
        {
            throw new InvalidOperationException("List has no item to delete");
        }
        Node<T> tmp;
        if (this.head.val.CompareTo(val) == 0)
        {
            tmp = this.head;
            this.head = tmp.next;
            tmp = null;
            flag = true;
        }
        else
        {
            Node<T> current=this.head;
            while (current.next != null)
            {
                if (current.next.val.CompareTo(val) == 0)
                {
                    tmp = current.next;
                    current.next = tmp.next;
                    tmp = null;
                    flag = true;
                    break;
                }

                current = current.next;
            }
        }
        if (!flag)
        {
            throw new InvalidOperationException("List has no item to delete");
        }
    }

    public int CountElementNumber(T val)
    {
        bool flag = false;
        if (this.size == 0)
        {
            throw new InvalidOperationException("No Element in List");
        }
        Node<T> tmp=this.head;
        int count = 0;
        while (tmp!=null)
        {
            if (tmp.val.CompareTo(val) == 0)
            {
                count++;
                flag = true;
            }
            tmp = tmp.next;
        }

        if (!flag)
        {
            throw new InvalidOperationException("Element not found");
        }
        
        return count;
    }
    public static void MargeSort(int st,int end,T [] array)
    {
        if (st < end)
        {
            int mid = st + (end - st) / 2;
            MargeSort(st,mid,array);
            MargeSort(mid+1,end,array);
            Marge(st,mid,end,array);
        }
    }

    public static int BinarySearch(T val,int st,int end,T[]array)
    {
        while (st<=end)
        {
            int mid = st + (end - st) / 2;
            if (array[mid].CompareTo(val) == 0)
            {
                return mid;
            }
            else if (array[mid].CompareTo(val)<0)
            {
                st = mid + 1;
            }
            else if (array[mid].CompareTo(val)>0)
            {
                end = mid - 1;
            }
                
        }

        return -1;
    }

    public T Max()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("Invalid list size");
        }
        Node<T> tmp = this.head;
        T maxVal = tmp.val;

        while (tmp != null)
        {
            if (tmp.val.CompareTo(maxVal)>0)
            {
                maxVal = tmp.val;
            }

            tmp = tmp.next;
        }

        return maxVal;
    }
    
    
    public T Min()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("Invalid list size");
        }
        Node<T> tmp = this.head;
        T minVal = tmp.val;

        while (tmp != null)
        {
            if (tmp.val.CompareTo(minVal)<0)
            {
                minVal = tmp.val;
            }

            tmp = tmp.next;
        }

        return minVal;
    }

    public void Replace(T OldVal, T NewVal)
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("replace is not possible in a empty List");
        }
        bool find = false;
        Node<T> tmp = this.head;
        while (tmp != null)
        {
            if (tmp.val.CompareTo(OldVal) == 0)
            {
                tmp.val = NewVal;
                find = true;
            }
            tmp = tmp.next;
        }

        if (!find)
        {
            throw new InvalidOperationException("Element is not find ");
        }
    }

    public bool Search(T val)
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("Search for Invalid sized list");
        }

        T[] arr = new T[this.size];
        Node<T> tmp = this.head;
        int i = 0;
        while (tmp != null)
        {
            arr[i++] = tmp.val;
            tmp = tmp.next;
        }
        if (this.isSort)
        {
            if (BinarySearch(val,0,this.size-1,arr) >=0) return true;
            else
            {
                return false;
            }
        }
        else
        {
            tmp = this.head;
            while (tmp != null)
            {
                if (tmp.val.CompareTo(val) == 0)
                {
                    return true;
                    break;
                }

                tmp = tmp.next;
            }
        }
        

        return false;
    }
    public void Sort()
    {
        if (this.size == 0)
        {
            throw new InvalidOperationException("Sort for Invalid sized list");
        }
        Node<T> tmp = this.head;
        T[]arr=new T[this.size];
        for (int i = 0; i < this.size; i++)
        {
            arr[i] = tmp.val;
            tmp = tmp.next;
        }
        MargeSort(0, this.size - 1, arr);
        tmp = this.head;
        for (int i = 0; i < this.size; i++)
        {
            tmp.val=arr[i];
            tmp = tmp.next;
        }

        this.isSort = true;
    }

    public void push_back(T val)
    {
        Node<T> NewNode = new Node<T>(val);
        this.tail.next = NewNode;
        this.tail = NewNode;
        this.size = this.size + 1;
    }
}


class Node<T>
{
    public T val;
    public Node<T> next;

    public Node(T val)
    {
        this.val = val;
        this.next = null;
    }

    public Node()
    {
        this.next = null;
    }
}