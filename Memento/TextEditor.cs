using System;

namespace Memento
{
    /// <summary>
    /// Represents the text editor whose state we want to save and restore.
    /// </summary>
    public class TextEditor
    {
        private string? text;

        /// <summary>
        /// Gets or sets the text content of the text editor.
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                Console.WriteLine("Updating text: " + value);
                text = value;
            }
        }

        /// <summary>
        /// Creates a memento to save the current state of the text editor.
        /// </summary>
        /// <returns>A memento object containing the current state.</returns>
        public TextEditorMemento CreateMemento()
        {
            return new TextEditorMemento(text);
        }

        /// <summary>
        /// Restores the state of the text editor from a memento object.
        /// </summary>
        /// <param name="memento">The memento object to restore from.</param>
        public void RestoreMemento(TextEditorMemento memento)
        {
            text = memento.SavedText;
            Console.WriteLine("Restored text: " + text);
        }
    }
}
