using System.Security.Cryptography;
using System.Text;
using Sitecore.Configuration;

namespace Sitecore.SecurityModel.Cryptography {

  /// <summary>
  /// Interface for accessing HashEncryption
  /// </summary>
  internal interface IHashEncryption
  {
    /// <summary>
    /// Encrypt a string
    /// </summary>
    /// <param name="sData">The s data.</param>
    /// <returns>The <see cref="string"/>.</returns>
    string Hash(string sData);

    /// <summary>
    /// Hashes the specified data bytes.
    /// </summary>
    /// <param name="dataBytes">The data bytes.</param>
    /// <returns></returns>
    byte[] ComputeHash(byte[] dataBytes);
  }

  /// <summary>
  /// Represents a class for hash encryption.
  /// </summary>
  public class HashEncryption : IHashEncryption
  {

    #region Types

    /// <summary>
    /// Type of encryption provider.
    /// </summary>
    public enum EncryptionProvider : int {
      /// <summary>MD5.</summary>
      MD5, 
      /// <summary>SHA1.</summary>
      SHA1, 
      /// <summary>SHA256.</summary>
      SHA256, 
      /// <summary>SHA384.</summary>
      SHA384, 
      /// <summary>SHA512.</summary>
      SHA512,
      /// <summary>The sha1 fps compliant crypto service provider </summary>
      SHA1FIPS,
      /// <summary>The sha256 fps compliant crypto service provider </summary>
      SHA256FIPS,
      /// <summary>The sha384 fps compliant crypto service provider </summary>
      SHA384FIPS,
      /// <summary>The sha512 fps compliant crypto service provider </summary>
      SHA512FIPS
    }

    #endregion

    #region Fields

    internal HashAlgorithm m_crypto;

    #endregion

    #region Property


    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="HashEncryption"/> class.
    /// </summary>
    public HashEncryption()
      : this(EncryptionProvider.MD5)
    {
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="HashEncryption"/> class.
    /// </summary>
    /// <param name="provider">The provider.</param>
    public HashEncryption(EncryptionProvider provider) : this(provider, new CryptoSettingsWrapper()) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="HashEncryption"/> class.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <param name="cryptoSettings">cryptoSettings</param>
    public HashEncryption(EncryptionProvider provider, ICryptoSettingsWrapper cryptoSettings)
    {
      if (cryptoSettings.AllowOnlyFipsAlgorithmsSettings)
      {
        switch (provider)
        {
          case EncryptionProvider.MD5:
          case EncryptionProvider.SHA1:
          case EncryptionProvider.SHA256:
          case EncryptionProvider.SHA384:
          case EncryptionProvider.SHA512:
            m_crypto = new SHA256CryptoServiceProvider();
            return;
        }
      }

      switch (provider)
      {
        case EncryptionProvider.MD5:
          m_crypto = new MD5CryptoServiceProvider();
          break;
        case EncryptionProvider.SHA1:
          m_crypto = new SHA1Managed();
          break;
        case EncryptionProvider.SHA256:
          m_crypto = new SHA256Managed();
          break;
        case EncryptionProvider.SHA384:
          m_crypto = new SHA384Managed();
          break;
        case EncryptionProvider.SHA512:
          m_crypto = new SHA512Managed();
          break;
        case EncryptionProvider.SHA1FIPS:
          m_crypto = new SHA1CryptoServiceProvider();
          break;
        case EncryptionProvider.SHA256FIPS:
          m_crypto = new SHA256CryptoServiceProvider();
          break;
        case EncryptionProvider.SHA384FIPS:
          m_crypto = new SHA384CryptoServiceProvider();
          break;
        case EncryptionProvider.SHA512FIPS:
          m_crypto = new SHA512CryptoServiceProvider();
          break;
      }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="provider">The provider.</param>
    public HashEncryption(HashAlgorithm provider) {
      m_crypto = provider;
    }

    #endregion

    #region Public methods

    /// <summary>
    /// Encrypt a string
    /// </summary>
    /// <param name="sData">The s data.</param>
    /// <returns>The <see cref="string"/>.</returns>
    public string Hash(string sData) {
      //Put the string into a byte array
      byte[] data = Encoding.Unicode.GetBytes(sData);

      byte[] hash = m_crypto.ComputeHash(data);
      
      StringBuilder ret = new StringBuilder();

      foreach(byte b in hash){
        //Format as hex
        ret.AppendFormat("{0:X2}", b);
      } 
      
      return ret.ToString();
    }

    /// <summary>
    /// Hashes the specified data bytes.
    /// </summary>
    /// <param name="dataBytes">The data bytes.</param>
    /// <returns></returns>
    public byte[] ComputeHash(byte[] dataBytes)
    {
      return m_crypto.ComputeHash(dataBytes);
    }

    #endregion
  }

}
