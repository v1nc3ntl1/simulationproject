
namespace MyStrongNameAssembly
{
  using System.Security.Cryptography;

  public class RijnDaelWrapper : Rijndael
  {
    private AesCryptoServiceProvider underlyingProvider;

    public AesCryptoServiceProvider UnderlyingProvider
    {
      get { return underlyingProvider = underlyingProvider ?? new AesCryptoServiceProvider(); }
      set { underlyingProvider = value; }
    }

    public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
    {
      return UnderlyingProvider.CreateEncryptor(rgbKey, rgbIV);
    }

    public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
    {
      return UnderlyingProvider.CreateDecryptor(rgbKey, rgbIV);
    }

    public override void GenerateKey()
    {
      UnderlyingProvider.GenerateKey();
    }

    public override void GenerateIV()
    {
      UnderlyingProvider.GenerateIV();
    }
  }
}
