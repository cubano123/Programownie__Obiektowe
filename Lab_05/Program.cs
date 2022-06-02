using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Program
{
    public static void Main()
    {
        //ObservableList1<int> list1 = CreateList2();
        //list1.Add(1);
        //list1.Add(2);
        //list1.Add(3);
        //list1.Set(0, 5);
        //list1.Set(1, 5);
        //list1.Set(2, 5);
        
    }
    public static ObservableList1<int> CreateList()
    {
        ObservableList1<int> list1 = new ObservableList1<int>();
        list1.Added += (object sender, AddedEventArgs<int> e) =>
        {
            // logowanie operacj iw konsoli
             Console.WriteLine("logowanie operacj iw konsoli: Added index=" + e.Index + " value=" + e.Value);
        };       
        return list1;
    }
    public static ObservableList1<int> CreateList2()
    {
        ObservableList1<int> list1 = CreateList();
        list1.Added += (object sender, AddedEventArgs<int> e) =>
        {
            // zapis do bazy / do pliku
            Console.WriteLine("zapis do bazy / do pliku: Added: index=" + e.Index + " value=" + e.Value);
        };
        return list1;
    }
}
public class ObservableList1<T>
{
    private List<T> list = new List<T>();
    public event EventHandler<AddedEventArgs<T>> Added;
    protected virtual void OnAdded(AddedEventArgs<T> e)
    {
        EventHandler<AddedEventArgs<T>> handler = this.Added;
        
        handler?.Invoke(this, e);
    }
    internal void Add(T value)
    {
        this.list.Add(value);
        this.OnAdded(new AddedEventArgs<T> { Index = this.list.Count - 1, Value = value });
    }
    internal void Set(int index, T value)
    {
        this.list[index] = value;
    }
    internal void Get()
    {
        
    }
    internal void RemoveAt()
    {

    }
}
public class ObservableList2<T>
{

}

public class ObservableList3<T>
{
    public delegate void Added3(T value);
}
public class AddedEventArgs<T> : EventArgs
{
    public int Index { get; set; }
    public T Value { get; set; }
}