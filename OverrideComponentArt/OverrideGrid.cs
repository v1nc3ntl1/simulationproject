
namespace OverrideComponentArt
{
  using System;
  using System.ComponentModel;
  using ComponentArt.Licensing.Providers;
  using ComponentArt.Web.UI;

  [System.ComponentModel.LicenseProvider(typeof(OverrideRegistryFileLicenseProvider))]
  public class OverrideGrid : Grid
  {

  }

  public class OverrideRegistryFileLicenseProvider : RegistryFileLicenseProvider
  {
    public override System.ComponentModel.License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
    {
      return new OverrideLicense(this, "", 1);
    }
  }

  public class OverrideLicense : System.ComponentModel.License
  {
    private RegistryFileLicenseProvider owner;
    private string key;
    private int state;

    public override string LicenseKey
    {
      get
      {
        return this.key;
      }
    }

    public int State
    {
      get
      {
        return this.state;
      }
    }

    public OverrideLicense(RegistryFileLicenseProvider owner, string key)
    {
      this.owner = owner;
      this.key = key;
      this.state = 0;
    }

    public OverrideLicense(RegistryFileLicenseProvider owner, string key, int state)
    {
      this.owner = owner;
      this.key = key;
      this.state = state;
    }

    public override void Dispose()
    {
    }
  }
}
