namespace System.IO;

/// <summary>
/// Extended version of the flag used in <see cref="Directory.Delete(string, bool)"/>.
/// </summary>
public enum DeletionMode
{
    /// <summary>
    /// Same as <see cref="Recursive"/> but also deletes read-only files and directories
    /// instead of throwing <see cref="UnauthorizedAccessException"/> or <see cref="IOException"/>.
    /// </summary>
    Wipe,
    /// <summary>
    /// Correesponds to flag in <see cref="Directory.Delete(string, bool)"/> set to true.
    /// </summary>
    Recursive,
    /// <summary>
    /// Correesponds to flag in <see cref="Directory.Delete(string, bool)"/> set to false.
    /// </summary>
    NonRecursive
}
