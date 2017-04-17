using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patch
{
  using System.Security.Cryptography;
  using Sitecore.Events.Hooks;

  public class EncryptionHook : IHook
  {
    public void Initialize()
    {
      CryptoConfig.AddAlgorithm(typeof(SHA256CryptoServiceProvider), "Rijndael",
        "System.Security.Cryptography.Rijndael", "System.Security.Cryptography.RijndaelManaged");
      CryptoConfig.AddAlgorithm(typeof(SHA256CryptoServiceProvider), "MD5",
        "System.Security.Cryptography.MD5", "System.Security.Cryptography.MD5CryptoServiceProvider",
        "System.Security.Cryptography.MD5Managed");
    }
  }
}
