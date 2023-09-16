using System;

namespace Memento
{
    /// <summary>
    /// Represents a caretaker that manages and keeps track of mementos for the text editor.
    /// </summary>
    public class TextEditorCaretaker
    {
        /// <summary>
        /// Gets or sets the memento object.
        /// </summary>
        public TextEditorMemento? Memento { get; set; }
    }
}
