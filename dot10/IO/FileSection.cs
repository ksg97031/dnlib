﻿using System.Diagnostics;
using System.IO;
using dot10.IO;

namespace dot10.IO {
	/// <summary>
	/// Base class for classes needing to implement IFileSection
	/// </summary>
	[DebuggerDisplay("O:{startOffset.val} L:{size} {GetType().Name}")]
	public class FileSection : IFileSection {
		/// <summary>
		/// The start file offset of this section
		/// </summary>
		protected FileOffset startOffset;

		/// <summary>
		/// Size of the section
		/// </summary>
		protected uint size;

		/// <inheritdoc/>
		public FileOffset StartOffset {
			get { return startOffset; }
		}

		/// <inheritdoc/>
		public FileOffset EndOffset {
			get { return startOffset + size; }
		}

		/// <summary>
		/// Set <see cref="startOffset"/> to <paramref name="reader"/>'s current position
		/// </summary>
		/// <param name="reader">The reader</param>
		protected void SetStartOffset(IImageStream reader) {
			startOffset = new FileOffset(reader.Position);
		}

		/// <summary>
		/// Set <see cref="size"/> according to <paramref name="reader"/>'s current position
		/// </summary>
		/// <param name="reader">The reader</param>
		protected void SetEndoffset(IImageStream reader) {
			size = (uint)(reader.Position - startOffset.Value);
			startOffset = reader.FileOffset + startOffset.Value;
		}
	}
}
