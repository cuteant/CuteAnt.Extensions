// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.FileProviders.Internal;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.FileProviders.Physical.Internal;
using Microsoft.Extensions.Primitives;

namespace Microsoft.Extensions.FileProviders
{
    /// <summary>
    /// Looks up files using the on-disk file system
    /// </summary>
    /// <remarks>
    /// When the environment variable "DOTNET_USE_POLLING_FILE_WATCHER" is set to "1" or "true", calls to
    /// <see cref="Watch(string)" /> will use <see cref="PollingFileChangeToken" />.
    /// </remarks>
    public class PhysicalFileProvider : IFileProvider, IDisposable
    {
        private const string PollingEnvironmentKey = "DOTNET_USE_POLLING_FILE_WATCHER";

        private static readonly char[] _pathSeparators = new[]
            {Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar};

        private readonly PhysicalFilesWatcher _filesWatcher;

        /// <summary>
        /// Initializes a new instance of a PhysicalFileProvider at the given root directory.
        /// </summary>
        /// <param name="root">The root directory. This should be an absolute path.</param>
        public PhysicalFileProvider(string root)
            : this(root, CreateFileWatcher(root))
        {
        }

        internal PhysicalFileProvider(string root, PhysicalFilesWatcher physicalFilesWatcher)
        {
            if (!Path.IsPathRooted(root))
            {
                throw new ArgumentException("The path must be absolute.", nameof(root));
            }
            var fullRoot = Path.GetFullPath(root);
            // When we do matches in GetFullPath, we want to only match full directory names.
            Root = PathUtils.EnsureTrailingSlash(fullRoot);
            if (!Directory.Exists(Root))
            {
                throw new DirectoryNotFoundException(Root);
            }

            _filesWatcher = physicalFilesWatcher;
        }

        private static PhysicalFilesWatcher CreateFileWatcher(string root)
        {
            var environmentValue = Environment.GetEnvironmentVariable(PollingEnvironmentKey);
            var pollForChanges = string.Equals(environmentValue, "1", StringComparison.Ordinal) ||
                                 string.Equals(environmentValue, "true", StringComparison.OrdinalIgnoreCase);

            root = PathUtils.EnsureTrailingSlash(Path.GetFullPath(root));
            return new PhysicalFilesWatcher(root, new FileSystemWatcher(root), pollForChanges);
        }

        /// <summary>
        /// Disposes the provider. Change tokens may not trigger after the provider is disposed.
        /// </summary>
        public void Dispose()
        {
            _filesWatcher.Dispose();
        }

        /// <summary>
        /// The root directory for this instance.
        /// </summary>
        public string Root { get; }

        private string GetFullPath(string path)
        {
            if (PathUtils.PathNavigatesAboveRoot(path))
            {
                return null;
            }

            string fullPath;
            try
            {
                fullPath = Path.GetFullPath(Path.Combine(Root, path));
            }
            catch
            {
                return null;
            }

            if (!IsUnderneathRoot(fullPath))
            {
                return null;
            }

            return fullPath;
        }

        private bool IsUnderneathRoot(string fullPath)
        {
            return fullPath.StartsWith(Root, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Locate a file at the given path by directly mapping path segments to physical directories.
        /// </summary>
        /// <param name="subpath">A path under the root directory</param>
        /// <returns>The file information. Caller must check Exists property. </returns>
        public IFileInfo GetFileInfo(string subpath)
        {
            if (string.IsNullOrEmpty(subpath) || PathUtils.HasInvalidPathChars(subpath))
            {
                return new NotFoundFileInfo(subpath);
            }

            // Relative paths starting with leading slashes are okay
            subpath = subpath.TrimStart(_pathSeparators);

            // Absolute paths not permitted.
            if (Path.IsPathRooted(subpath))
            {
                return new NotFoundFileInfo(subpath);
            }

            var fullPath = GetFullPath(subpath);
            if (fullPath == null)
            {
                return new NotFoundFileInfo(subpath);
            }

            var fileInfo = new FileInfo(fullPath);
            if (FileSystemInfoHelper.IsHiddenFile(fileInfo))
            {
                return new NotFoundFileInfo(subpath);
            }

            return new PhysicalFileInfo(fileInfo);
        }

        /// <summary>
        /// Enumerate a directory at the given path, if any.
        /// </summary>
        /// <param name="subpath">A path under the root directory. Leading slashes are ignored.</param>
        /// <returns>
        /// Contents of the directory. Caller must check Exists property. <see cref="NotFoundDirectoryContents" /> if
        /// <paramref name="subpath" /> is absolute, if the directory does not exist, or <paramref name="subpath" /> has invalid
        /// characters.
        /// </returns>
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            try
            {
                if (subpath == null || PathUtils.HasInvalidPathChars(subpath))
                {
                    return NotFoundDirectoryContents.Singleton;
                }

                // Relative paths starting with leading slashes are okay
                subpath = subpath.TrimStart(_pathSeparators);

                // Absolute paths not permitted.
                if (Path.IsPathRooted(subpath))
                {
                    return NotFoundDirectoryContents.Singleton;
                }

                var fullPath = GetFullPath(subpath);
                if (fullPath == null || !Directory.Exists(fullPath))
                {
                    return NotFoundDirectoryContents.Singleton;
                }

                return new PhysicalDirectoryContents(fullPath);
            }
            catch (DirectoryNotFoundException)
            {
            }
            catch (IOException)
            {
            }
            return NotFoundDirectoryContents.Singleton;
        }

        /// <summary>
        ///     <para>Creates a <see cref="IChangeToken" /> for the specified <paramref name="filter" />.</para>
        ///     <para>Globbing patterns are interpreted by <seealso cref="Microsoft.Extensions.FileSystemGlobbing.Matcher" />.</para>
        /// </summary>
        /// <param name="filter">
        /// Filter string used to determine what files or folders to monitor. Example: **/*.cs, *.*,
        /// subFolder/**/*.cshtml.
        /// </param>
        /// <returns>
        /// An <see cref="IChangeToken" /> that is notified when a file matching <paramref name="filter" /> is added,
        /// modified or deleted. Returns a <see cref="NullChangeToken" /> if <paramref name="filter" /> has invalid filter
        /// characters or if <paramref name="filter" /> is an absolute path or outside the root directory specified in the
        /// constructor <seealso cref="PhysicalFileProvider(string)" />.
        /// </returns>
        public IChangeToken Watch(string filter)
        {
            if (filter == null || PathUtils.HasInvalidFilterChars(filter))
            {
                return NullChangeToken.Singleton;
            }

            // Relative paths starting with leading slashes are okay
            filter = filter.TrimStart(_pathSeparators);

            return _filesWatcher.CreateFileChangeToken(filter);
        }
    }
}