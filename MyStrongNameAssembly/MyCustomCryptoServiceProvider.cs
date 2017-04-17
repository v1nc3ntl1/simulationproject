
namespace MyStrongNameAssembly
{
  using System.Security.Cryptography;

  public class MyCustomCryptoServiceProvider : SHA1
  {
    private SHA1 innerProviderSha1;

    public SHA1 InnerProviderSha1
    {
      get { return innerProviderSha1 = innerProviderSha1 ?? new SHA1CryptoServiceProvider(); }
      set { innerProviderSha1 = value; }
    }
    
    public override void Initialize()
    {
      InnerProviderSha1.Initialize();
    }

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
      
    }

    protected override byte[] HashFinal()
    {
      return new byte[]
      {
      };
    }
  }
}
