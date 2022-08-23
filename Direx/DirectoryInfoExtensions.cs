//MIT License

//Copyright (c) 2022 9ualaBanana

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

namespace System.IO;

public static class DirectoryInfoExtensions
{
    /// <inheritdoc cref="DeleteAfter(DirectoryInfo, Action{DirectoryInfo}, DeletionMode)"/>
    public static void DeleteAfter(
        this DirectoryInfo directory,
        Action action,
        DeletionMode deletionMode = default)
    {
        action();
        directory.Delete(deletionMode);
    }

    /// <summary>
    /// Deletes the <paramref name="directory"/> using specified <paramref name="deletionMode"/> after <paramref name="action"/> is executed.
    /// </summary>
    /// <param name="directory">The directory to delete.</param>
    /// <param name="action">The action after which directory will be deleted.</param>
    /// <param name="deletionMode">The mode to use for directory deletion.</param>
    public static void DeleteAfter(
        this DirectoryInfo directory,
        Action<DirectoryInfo> action,
        DeletionMode deletionMode = default)
    {
        action(directory);
        directory.Delete(deletionMode);
    }

    /// <summary>
    /// Deletes the <paramref name="directory"/> using specified <paramref name="deletionMode"/> after <paramref name="action"/> is executed.
    /// </summary>
    /// <param name="directory">The directory to delete.</param>
    /// <param name="action">The action after which directory will be deleted.</param>
    /// <param name="fullName">The flag specifying which form of directory name will be passed to the action.</param>
    /// <param name="deletionMode">The mode to use for directory deletion.</param>
    public static void DeleteAfter(
        this DirectoryInfo directory,
        Action<string> action,
        bool fullName = true,
        DeletionMode deletionMode = default)
    {
        action(fullName ? directory.FullName : directory.Name);
        directory.Delete(deletionMode);
    }

    /// <inheritdoc cref="DeleteAfter{T}(DirectoryInfo, Func{DirectoryInfo, T}, DeletionMode)"/>
    public static T DeleteAfter<T>(
        this DirectoryInfo directory,
        Func<T> action,
        DeletionMode deletionMode = default)
    {
        var result = action();
        directory.Delete(deletionMode);
        return result;
    }

    /// <summary>
    /// Deletes the <paramref name="directory"/> using specified <paramref name="deletionMode"/> after <paramref name="action"/> is executed.
    /// </summary>
    /// <typeparam name="T">The type of action result.</typeparam>
    /// <param name="directory">The directory to delete.</param>
    /// <param name="action">The action after which directory will be deleted.</param>
    /// <param name="deletionMode">The mode to use for directory deletion.</param>
    /// <returns>The action result.</returns>
    public static T DeleteAfter<T>(
        this DirectoryInfo directory,
        Func<DirectoryInfo, T> action,
        DeletionMode deletionMode = default)
    {
        var result = action(directory);
        directory.Delete(deletionMode);
        return result;
    }

    /// <summary>
    /// Deletes the <paramref name="directory"/> using specified <paramref name="deletionMode"/> after <paramref name="action"/> is executed.
    /// </summary>
    /// <typeparam name="T">The type of action result.</typeparam>
    /// <param name="directory">The directory to delete.</param>
    /// <param name="action">The action after which directory will be deleted.</param>
    /// <param name="fullName">The flag specifying which form of directory name will be passed to the action.</param>
    /// <param name="deletionMode">The mode to use for directory deletion.</param>
    /// <returns>The action result.</returns>
    public static T DeleteAfter<T>(
        this DirectoryInfo directory,
        Func<string, T> action,
        bool fullName = true,
        DeletionMode deletionMode = default)
    {
        var result = action(fullName ? directory.FullName : directory.Name);
        directory.Delete(deletionMode);
        return result;
    }



    /// <inheritdoc cref="DeleteAfter(DirectoryInfo, Action{DirectoryInfo}, DeletionMode)"/>
    public static async Task DeleteAfterAsync(
        this DirectoryInfo directory,
        Func<Task> action,
        DeletionMode deletionMode = default)
    {
        await action();
        directory.Delete(deletionMode);
    }

    /// <inheritdoc cref="DeleteAfter(DirectoryInfo, Action{string}, bool, DeletionMode)"/>
    public static async Task DeleteAfterAsync(
        this DirectoryInfo directory,
        Func<string, Task> action,
        bool fullName = true,
        DeletionMode deletionMode = default)
    {
        await action(fullName ? directory.FullName : directory.Name);
        directory.Delete(deletionMode);
    }

    /// <inheritdoc cref="DeleteAfter{T}(DirectoryInfo, Func{DirectoryInfo, T}, DeletionMode)"/>
    public static async Task<T> DeleteAfterAsync<T>(
        this DirectoryInfo directory,
        Func<Task<T>> action,
        DeletionMode deletionMode = default)
    {
        var result = await action();
        directory.Delete(deletionMode);
        return result;
    }

    /// <inheritdoc cref="DeleteAfter{T}(DirectoryInfo, Func{DirectoryInfo, T}, DeletionMode)"/>
    public static async Task<T> DeleteAfterAsync<T>(
        this DirectoryInfo directory,
        Func<DirectoryInfo, Task<T>> action,
        DeletionMode deletionMode = default)
    {
        var result = await action(directory);
        directory.Delete(deletionMode);
        return result;
    }

    /// <inheritdoc cref="DeleteAfter{T}(DirectoryInfo, Func{string, T}, bool, DeletionMode)"/>
    public static async Task<T> DeleteAfterAsync<T>(
        this DirectoryInfo directory,
        Func<string, Task<T>> action,
        bool fullName = true,
        DeletionMode deletionMode = default)
    {
        var result = await action(fullName ? directory.FullName : directory.Name);
        directory.Delete(deletionMode);
        return result;
    }



    /// <summary>
    /// Deletes the <paramref name="directory"/> using specified <paramref name="deletionMode"/>.
    /// </summary>
    /// <param name="directory">The directory to delete.</param>
    /// <param name="deletionMode">The mode to use for directory deletion.</param>
    public static void Delete(this DirectoryInfo directory, DeletionMode deletionMode)
    {
        if (deletionMode is DeletionMode.NonRecursive) directory.Delete();
        else
        {
            if (deletionMode is DeletionMode.Wipe) directory.PrepareForWipe();
            directory.Delete(true);
        }
    }

    static void PrepareForWipe(this DirectoryInfo directory)
    {
        directory.Attributes &= ~FileAttributes.ReadOnly;
        foreach (var nestedDirectory in directory.EnumerateDirectories("*", SearchOption.AllDirectories)
            .Where(directory => directory.Attributes.HasFlag(FileAttributes.ReadOnly)))
        { nestedDirectory.Attributes &= ~FileAttributes.ReadOnly; }
        foreach (var file in directory.EnumerateFiles("*", SearchOption.AllDirectories).Where(file => file.IsReadOnly))
            file.IsReadOnly = false;
    }
}

