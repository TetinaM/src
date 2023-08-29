using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }
    public List<ICat> Cats { get; set; }
    public List<ILion> Lions { get; set; }
    public List<IElephant> Elephants { get; set; }
    public List<ITiger> Tigers { get; set; }

    #endregion // IMammals Implementation

    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        Cats = new List<ICat>();
        Lions = new List<ILion>();
        Elephants = new List<IElephant>();
        Tigers = new List<ITiger>();
    }

    #endregion // Ctors
}
