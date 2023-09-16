using System;

namespace Memento
{
    /// <summary>
    /// Represents a memento object that stores the saved state of the text editor.
    /// </summary>
    public class TextEditorMemento
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextEditorMemento"/> class.
        /// </summary>
        /// <param name="text">The text content to be saved.</param>
        public TextEditorMemento(string text)
        {
            SavedText = text;
        }

        /// <summary>
        /// Gets the saved text content.
        /// </summary>
        public string SavedText { get; }
    }
}
