namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Settings interface.
/// </summary>
public interface ISettings
{
    //Dodanie ustawień dotyczących kolorystyki poszczególnych ekranów
    string MainScreenColor { get; }
    string AnimalsScreenColor { get; }
    string MammalsScreenColor { get; }
    string DogsScreenColor { get; }
    string CatsScreenColor { get; }
    string LionsScreenColor { get; }
    string ElephantsScreenColor { get; }
    string TigersScreenColor { get; }

    #region Interface Members


    /// <summary>
    /// Version of settings.
    /// </summary>


    #endregion // Interface Members
}

