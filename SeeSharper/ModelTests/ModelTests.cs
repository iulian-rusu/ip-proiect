/**************************************************************************
 *                                                                        *
 *  File:        ModelTests                                               *
 *  Copyright:   (c) 2021, Baltariu Ionut-Alexandru                       *
 *  E-mail:      ionut-alexandru.baltariu@student.tuiasi.ro               *
 *  Description: Used to unit test the Model class                        *
 *                                                                        *
 *  This code and information is provided "as is" without warranty of     *
 *  any kind, either expressed or implied, including but not limited      *
 *  to the implied warranties of merchantability or fitness for a         *
 *  particular purpose. You are free to use this source code in your      *
 *  applications as long as the original copyright notice is included.    *
 *                                                                        *
 **************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Memento;
using System.Drawing;
using System.IO;
using System;
using Strategy;
using System.Reflection;

namespace Model.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model model;
        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            model = new Model();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage2.png");
        }

        [TestMethod()]
        public void HasSaveFileNameTestNull()
        {
            Assert.AreEqual(model.HasSaveFileName(), false);
        }

        [TestMethod()]
        public void HasSaveFileNameTestNotNull()
        {
            model.SetSaveFileName("DummyText");
            Assert.AreEqual(model.HasSaveFileName(), true);
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LoadDrawingTestFileNotFound()
        {
            string description = String.Empty;
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile("\\"), description);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void LoadDrawingTestInvalidPath()
        {
            string description = String.Empty;
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(""), description);
        }

        [TestMethod()]
        public void LoadDrawingTestFileFound()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string description = String.Empty;
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);

            Assert.IsNotNull(drawingMemento);
        }

        [TestMethod()]
        public void GetPaintingStrategyTests()
        {
            Assert.IsInstanceOfType(model.GetPaintingStrategy(PaintingTool.Brush), typeof(BrushStrategy));
            Assert.IsInstanceOfType(model.GetPaintingStrategy(PaintingTool.Line), typeof(LineStrategy));
            Assert.IsInstanceOfType(model.GetPaintingStrategy(PaintingTool.Circle), typeof(CircleStrategy));
            Assert.IsInstanceOfType(model.GetPaintingStrategy(PaintingTool.Ellipse), typeof(ElipseStrategy));
            Assert.IsInstanceOfType(model.GetPaintingStrategy(PaintingTool.Square), typeof(SquareStrategy));
            Assert.IsInstanceOfType(model.GetPaintingStrategy(PaintingTool.Rectangle), typeof(RectangleStrategy));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SaveDrawingTestInvalidPath()
        {
            string fileName = String.Empty;
            string description = String.Empty;

            model.SetSaveFileName(fileName);
            model.SaveDrawing(new DrawingMemento(Image.FromFile(fileName), description));
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void SaveDrawingTestInvalidExtension()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string invalidImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\dummyFile.invalidExtension";
            string description = String.Empty;
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);

            model.SetSaveFileName(invalidImagePath);
            model.SaveDrawing(drawingMemento);

            DrawingMemento nonExistentDrawingMemento = new DrawingMemento(Image.FromFile(invalidImagePath), description);
        }

        [TestMethod()]
        public void SaveDrawingTestOK()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string otherValidImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage2.png";
            string description = String.Empty;
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);
            DrawingMemento existentDrawingMemento = null;

            model.SetSaveFileName(otherValidImagePath);
            model.SaveDrawing(drawingMemento);

            existentDrawingMemento = new DrawingMemento(Image.FromFile(otherValidImagePath), description);

            Assert.IsNotNull(existentDrawingMemento);
        }

        [TestMethod()]
        public void GetNextUndoDescriptionTest()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string description = "DummyDescription";
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);

            model.AddMemento(drawingMemento);

            Assert.AreEqual(description, model.GetNextUndoDescription());
        }

        [TestMethod()]
        public void GetNextRedoDescriptionTest()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string description = "DummyDescription";
            string anotherDescription = "AnotherDummyDescription";
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);
            DrawingMemento anotherDrawingMemento = new DrawingMemento(Image.FromFile(validImagePath), anotherDescription);

            model.AddMemento(drawingMemento);
            model.AddMemento(anotherDrawingMemento);
            model.Undo();

            Assert.AreEqual(anotherDescription, model.GetNextRedoDescription());
        }

        [TestMethod()]
        public void DropMementosTest()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string description = "DummyDescription";
            string anotherDescription = "AnotherDummyDescription";
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);
            DrawingMemento anotherDrawingMemento = new DrawingMemento(Image.FromFile(validImagePath), anotherDescription);

            model.AddMemento(drawingMemento);
            model.AddMemento(anotherDrawingMemento);
            model.DropMementos();

            Assert.AreEqual(String.Empty, model.GetNextRedoDescription());
        }
    }
}