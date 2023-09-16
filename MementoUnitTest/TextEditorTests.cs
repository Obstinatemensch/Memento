using Microsoft.VisualStudio.TestTools.UnitTesting;
using Memento;

namespace MementoUnitTest
{
    /// <summary>
    /// Unit tests for the TextEditor class and related functionality.
    /// </summary>
    [TestClass]
    public class TextEditorTests
    {
        /// <summary>
        /// Tests whether the TextEditor creates a valid memento.
        /// </summary>
        [TestMethod]
        public void TextEditor_CreatesMemento_CreatesValidMemento()
        {
            // Arrange
            var textEditor = new TextEditor();

            // Act
            textEditor.Text = "Initial text";
            var memento = textEditor.CreateMemento();

            // Assert
            Assert.IsNotNull(memento);
            Assert.AreEqual("Initial text", memento.SavedText);
        }

        /// <summary>
        /// Tests whether the TextEditor restores the state correctly from a memento.
        /// </summary>
        [TestMethod]
        public void TextEditor_RestoreMemento_RestoresState()
        {
            // Arrange
            var textEditor = new TextEditor();
            var caretaker = new TextEditorCaretaker();

            textEditor.Text = "Original text";
            caretaker.Memento = textEditor.CreateMemento();

            textEditor.Text = "Modified text";

            // Act
            textEditor.RestoreMemento(caretaker.Memento);

            // Assert
            Assert.AreEqual("Original text", textEditor.Text);
        }

        /// <summary>
        /// Tests whether the TextEditor creates and stores multiple mementos correctly.
        /// </summary>
        [TestMethod]
        public void TextEditor_CreatesMultipleMementos_StoresEachState()
        {
            // Arrange
            var textEditor = new TextEditor();
            var caretaker = new TextEditorCaretaker();

            // Act
            textEditor.Text = "State 1";
            caretaker.Memento = textEditor.CreateMemento();

            textEditor.Text = "State 2";
            var secondMemento = textEditor.CreateMemento();

            // Assert
            Assert.AreEqual("State 1", caretaker.Memento.SavedText);
            Assert.AreEqual("State 2", secondMemento.SavedText);
        }

        /// <summary>
        /// Tests whether the TextEditor correctly restores multiple mementos to their respective states.
        /// </summary>
        [TestMethod]
        public void TextEditor_RestoreMultipleMementos_RestoresToCorrectState()
        {
            // Arrange
            var textEditor = new TextEditor();
            var caretaker = new TextEditorCaretaker();

            textEditor.Text = "State 1";
            caretaker.Memento = textEditor.CreateMemento();

            textEditor.Text = "State 2";
            var secondMemento = textEditor.CreateMemento();

            // Act
            textEditor.RestoreMemento(caretaker.Memento);

            // Assert
            Assert.AreEqual("State 1", textEditor.Text);

            // Act again to restore the second state
            textEditor.RestoreMemento(secondMemento);

            // Assert
            Assert.AreEqual("State 2", textEditor.Text);
        }

        /// <summary>
        /// Tests whether the TextEditor saves and restores an empty string correctly.
        /// </summary>
        [TestMethod]
        public void TextEditor_SaveAndRestore_EmptyString()
        {
            // Arrange
            var textEditor = new TextEditor();
            var caretaker = new TextEditorCaretaker();

            // Act
            textEditor.Text = "Original text";
            caretaker.Memento = textEditor.CreateMemento();
            textEditor.Text = "";
            textEditor.RestoreMemento(caretaker.Memento);

            // Assert
            Assert.AreEqual("Original text", textEditor.Text);
        }

        /// <summary>
        /// Tests whether the TextEditor correctly restores the state after saving and restoring.
        /// </summary>
        [TestMethod]
        public void TextEditor_SaveAndRestore_ReturnsCorrectState()
        {
            // Arrange
            var textEditor = new TextEditor();

            // Act
            textEditor.Text = "Original text";
            var memento = textEditor.CreateMemento();
            textEditor.Text = "Modified text";
            textEditor.RestoreMemento(memento);

            // Assert
            Assert.AreEqual("Original text", textEditor.Text);
        }
    }
}
