using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.IO;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>

public class SettingsService : ISettingsService
{

    public ISettings LoadSettings(string filePath)
    {
        ISettings settings = new Settings();
        return settings;
    }

    public void SaveSettings(string filePath, ISettings settings)
    {
       
    }
    #region ISettings Implementation

    /// <inheritdoc/>
    public ISettings? Read(string jsonPath)
    {
        ISettings? result = null;

        return result;
    }

    /// <inheritdoc/>
    public void Write(ISettings settings, string jsonPath)
    {
        
    }

    #endregion // ISettings Implementation
}