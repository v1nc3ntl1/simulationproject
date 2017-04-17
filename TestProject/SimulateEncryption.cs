using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
  using System.Collections.ObjectModel;
  using System.Data;
  using System.Security.Cryptography;
  using System.Security.Cryptography.X509Certificates;
  using System.Threading;
  using Sitecore;

  public class SimulateEncryption
  {
    private static void Main(string[] args)
    {
      var mybute = Encoding.Unicode.GetBytes("hello world");
      var a = MD5.Create();

      var hash = a.ComputeHash(mybute);

      Console.WriteLine(new Guid(hash).ToString());
      //Thread.Sleep(10000);

      var mybute2 = Encoding.Unicode.GetBytes("hello world");
      var hash2 = a.ComputeHash(mybute2);

      Console.WriteLine(new Guid(hash2).ToString());
      Console.ReadLine();

      var d = GuidUtility.Create(GuidUtility.DnsNamespace, "vincent", 5);
      Console.WriteLine(d.ToString());

      Thread.Sleep(5000);

      var e = GuidUtility.Create(GuidUtility.DnsNamespace, "vincent", 5);
      Console.WriteLine(e.ToString());

      Console.ReadLine();

      Console.Write(MainUtil.GetMD5Hash("vincent li meng han hello world wassup this is for testing no other purpose. yoyo . Yes, i like it..woohhoo"));
    }
  }
}
