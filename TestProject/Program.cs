using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
  using System.Collections.ObjectModel;
  using System.Data;
  using System.Security.Cryptography.X509Certificates;

  class Program
  {
    static void Main(string[] args)
    {
      int noOfTimes = 1;
      string stringTimes = string.Empty;
      do
      {
        Console.WriteLine("Please select (N) number of times the event handler get registered : ");
        stringTimes = Console.ReadLine();
      }
      while (!int.TryParse(stringTimes, out noOfTimes));
      Publisher publisher = new Publisher();
      Subscriber subscriber1 = new Subscriber(noOfTimes, publisher);
      Console.WriteLine("Main before Calling publisher Save() method");
      publisher.Save();
      Console.WriteLine("Main After Calling publisher Save() method");
      Console.ReadLine();
    }
  }

  public class Publisher
  {
    public event EventHandler SaveEvent;

    //private Collection<Subscriber> _Subscribers;

    //public Publisher()
    //{
    //  _Subscribers = new Collection<Subscriber>();  
    //}

    //public void Subsribe(Subscriber subscriber)
    //{
    //  _Subscribers.Add(subscriber);
    //}

    public void Save()
    {
      Console.WriteLine("Calling Publisher Save() method.");
      if (SaveEvent != null)
      {
        SaveEvent(this, EventArgs.Empty);
      }
      Console.WriteLine("Ending Publisher Save() method.");
    }
  }

  public class Subscriber
  {
    private Publisher _publisher;
    public static int _times = 0;

    public Subscriber(int times, Publisher publisher)
    {
      _times = 0;
      _publisher = publisher;
      do
      {
        publisher.SaveEvent += SaveImpl;
        times -= 1;
      }
      while (times > 0);
    }

    public Subscriber(Publisher publisher)
      : this(1, publisher)
    {
    }

    private void SaveImpl(object sender, EventArgs e)
    {
      _times += 1;
      Console.WriteLine(string.Format("Calling SaveEvent event handler {0:N}", _times));
    }
  }
}
