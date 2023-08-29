using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Mammals collection.
/// </summary>
public interface IMammals
{
    #region Interface Members

    /// <summary>
    /// Dogs collection.
    /// </summary>
    List<IDog> Dogs { get; set; }
    List<ICat> Cats { get; set; }
    List<ILion> Lions { get; set; }
    List<IElephant> Elephants { get; set; }
    List<ITiger> Tigers { get; set; }

    #endregion // Interface Members
}
