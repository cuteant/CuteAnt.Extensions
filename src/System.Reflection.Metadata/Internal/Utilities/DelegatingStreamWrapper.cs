using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
#if !NET40
using System.Threading;
using System.Threading.Tasks;
#endif

namespace System.Reflection.Internal
{
    internal sealed class DelegatingStreamWrapper : DelegatingStream
    {
        public DelegatingStreamWrapper(Stream innerStream)
            : base(innerStream)
        {
        }

        public override void Close()
        {
            // Disabled.
        }

        protected override void Dispose(Boolean disposing)
        {
            // Disabled.
        }
    }

    /// <summary>Stream that delegates to inner stream.</summary>
    internal abstract class DelegatingStream : Stream
    {
        #region @@ Fields @@

        private Stream m_innerStream;

        #endregion

        #region @@ Properties @@

        /// <summary>InnerStream</summary>
        protected Stream InnerStream
        {
            get { return m_innerStream; }
        }

        /// <summary>When overridden in a derived class, gets a value indicating whether the current stream supports reading.</summary>
        /// <returns>true if the stream supports reading; otherwise, false.</returns>
        public override Boolean CanRead { get { return m_innerStream.CanRead; } }

        /// <summary>When overridden in a derived class, gets a value indicating whether the current stream supports seeking.</summary>
        /// <returns>true if the stream supports seeking; otherwise, false.</returns>
        public override Boolean CanSeek { get { return m_innerStream.CanSeek; } }

        /// <summary>Gets a value that determines whether the current stream can time out</summary>
        /// <returns>A value that determines whether the current stream can time out.</returns>
        public override Boolean CanTimeout { get { return m_innerStream.CanTimeout; } }

        /// <summary>When overridden in a derived class, gets a value indicating whether the current stream supports writing.</summary>
        /// <returns>true if the stream supports writing; otherwise, false.</returns>
        public override Boolean CanWrite { get { return m_innerStream.CanWrite; } }

        /// <summary>When overridden in a derived class, gets the length in bytes of the stream.</summary>
        /// <returns>A Int64 value representing the length of the stream in bytes.</returns>
        public override Int64 Length { get { return m_innerStream.Length; } }

        /// <summary>When overridden in a derived class, gets or sets the position within the current stream.</summary>
        /// <returns>The current position within the stream.</returns>
        public override Int64 Position { get { return m_innerStream.Position; } set { m_innerStream.Position = value; } }

        /// <summary>Gets or sets a value, in miliseconds, that determines how long the stream will attempt to read before timing out.</summary>
        /// <returns>A value, in miliseconds, that determines how long the stream will attempt to read before timing out.</returns>
        public override Int32 ReadTimeout { get { return m_innerStream.ReadTimeout; } set { m_innerStream.ReadTimeout = value; } }

        /// <summary>Gets or sets a value, in miliseconds, that determines how long the stream will attempt to write before timing out.</summary>
        /// <returns>A value, in miliseconds, that determines how long the stream will attempt to write before timing out.</returns>
        public override Int32 WriteTimeout { get { return m_innerStream.WriteTimeout; } set { m_innerStream.WriteTimeout = value; } }

        #endregion

        #region @@ Constructors @@

        /// <summary>Initializes a new instance of the <see cref="DelegatingStream" /> class.</summary>
        /// <param name="innerStream"></param>
        protected DelegatingStream(Stream innerStream)
        {
            Debug.Assert(innerStream != null);
            m_innerStream = innerStream;
        }

        #endregion

        #region ++ Dispose ++

        protected override void Dispose(Boolean disposing)
        {
            if (disposing) { m_innerStream.Dispose(); }
            base.Dispose(disposing);
        }

        #endregion

        public override IAsyncResult BeginRead(Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback, Object state)
        {
            return m_innerStream.BeginRead(buffer, offset, count, callback, state);
        }

        public override IAsyncResult BeginWrite(Byte[] buffer, Int32 offset, Int32 count, AsyncCallback callback, Object state)
        {
            return m_innerStream.BeginWrite(buffer, offset, count, callback, state);
        }

        public override Int32 EndRead(IAsyncResult asyncResult)
        {
            return m_innerStream.EndRead(asyncResult);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            m_innerStream.EndWrite(asyncResult);
        }

        public override void Flush()
        {
            m_innerStream.Flush();
        }

        public override Int32 Read(Byte[] buffer, Int32 offset, Int32 count)
        {
            return m_innerStream.Read(buffer, offset, count);
        }

        public override Int32 ReadByte()
        {
            return m_innerStream.ReadByte();
        }

        public override Int64 Seek(Int64 offset, SeekOrigin origin)
        {
            return m_innerStream.Seek(offset, origin);
        }

        public override void SetLength(Int64 value)
        {
            m_innerStream.SetLength(value);
        }

        public override void Write(Byte[] buffer, Int32 offset, Int32 count)
        {
            m_innerStream.Write(buffer, offset, count);
        }

        public override void WriteByte(Byte value)
        {
            m_innerStream.WriteByte(value);
        }

#if !NET40
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return m_innerStream.FlushAsync(cancellationToken);
        }

        public override Task<Int32> ReadAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken)
        {
            return m_innerStream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        public override Task WriteAsync(Byte[] buffer, Int32 offset, Int32 count, CancellationToken cancellationToken)
        {
            return m_innerStream.WriteAsync(buffer, offset, count, cancellationToken);
        }

        public override Task CopyToAsync(Stream destination, Int32 bufferSize, CancellationToken cancellationToken)
        {
            return m_innerStream.CopyToAsync(destination, bufferSize, cancellationToken);
        }
#endif
    }
}