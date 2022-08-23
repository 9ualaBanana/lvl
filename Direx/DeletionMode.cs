namespace System.IO;

/// <summary>
/// Extended version of the flag used in <see cref="Directory.Delete(string, bool)"/>.
/// </summary>
/// <remarks>
/// <see cref="Recursive"/> and <see cref="NonRecursive"/> correspond to flag in <see cref="Directory.Delete(string, bool)"/>
/// and <see cref="Wipe"/> is the same as <see cref="Recursive"/> but also deletes read-only files and directories
/// instead of throwing <see cref="UnauthorizedAccessException"/> or <see cref="IOException"/>.
/// </remarks>
public enum DeletionMode
{
    Wipe,
    Recursive,
    NonRecursive
}
