﻿/**************************************************************************
 *                                                                        *
 *  File:        ModelTests.cs                                            *
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

using Memento;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strategy;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Model.Tests
{
    /// <summary>
    /// Model unit test class - contains the unit test methods and the initialization and cleanup methods for the test fixture
    /// </summary>
    [TestClass()]
    public class ModelTests
    {
        #region Private Fields
        private Model _model;
        #endregion

        #region Initialization and Cleanup  Methods
        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            _model = new Model();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            // After the last test is executed, we delete the file generated by the unit tests.
            File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage2.png");
        }
        #endregion

        #region Unit tests
        [TestMethod()]
        public void HasSaveFileNameTestNull()
        {
            Assert.AreEqual(_model.HasSaveFileName(), false);
        }

        [TestMethod()]
        public void HasSaveFileNameTestNotNull()
        {
            _model.SetSaveFileName("DummyText");
            Assert.AreEqual(_model.HasSaveFileName(), true);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LoadDrawingTestFileNotFound()
        {
            Assert.IsNull(_model.LoadDrawing("\\"));
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void LoadDrawingTestInvalidPath()
        {
            Assert.IsNull(_model.LoadDrawing(""));
        }

        [TestMethod()]
        public void LoadDrawingTestFileFound()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";

            Assert.IsNotNull(_model.LoadDrawing(validImagePath));
        }

        [TestMethod()]
        public void GetPaintingStrategyTestsBrushStrategy()
        {
            Assert.IsInstanceOfType(_model.GetPaintingStrategy(PaintingTool.Brush), typeof(BrushStrategy));
        }

        [TestMethod()]
        public void GetPaintingStrategyTestsLineStrategy()
        {
            Assert.IsInstanceOfType(_model.GetPaintingStrategy(PaintingTool.Line), typeof(LineStrategy));
        }

        [TestMethod()]
        public void GetPaintingStrategyTestsCircleStrategy()
        {
            Assert.IsInstanceOfType(_model.GetPaintingStrategy(PaintingTool.Circle), typeof(CircleStrategy));
        }

        [TestMethod()]
        public void GetPaintingStrategyTestsElipseStrategy()
        {
            Assert.IsInstanceOfType(_model.GetPaintingStrategy(PaintingTool.Ellipse), typeof(ElipseStrategy));
        }

        [TestMethod()]
        public void GetPaintingStrategyTestsSquareStrategy()
        {
            Assert.IsInstanceOfType(_model.GetPaintingStrategy(PaintingTool.Square), typeof(SquareStrategy));
        }

        [TestMethod()]
        public void GetPaintingStrategyTestsRectangleStrategy()
        {
            Assert.IsInstanceOfType(_model.GetPaintingStrategy(PaintingTool.Rectangle), typeof(RectangleStrategy));
        }

        [TestMethod()]
        public void GetPaintingStrategyTestsIsoscelesTriangleStrategy()
        {
            Assert.IsInstanceOfType(_model.GetPaintingStrategy(PaintingTool.IsoscelesTriangle), typeof(IsoscelesTriangleStrategy));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SaveDrawingTestInvalidPath()
        {
            string fileName = String.Empty;
            string description = String.Empty;

            _model.SetSaveFileName(fileName);
            _model.SaveDrawing(new DrawingMemento(Image.FromFile(fileName), description));
        }

        [TestMethod()]
        public void SaveDrawingTestOK()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string otherValidImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage2.png";
            string description = String.Empty;
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);

            _model.SetSaveFileName(otherValidImagePath);
            _model.SaveDrawing(drawingMemento);

            Assert.IsTrue(File.Exists(otherValidImagePath));
        }

        [TestMethod()]
        public void GetNextUndoDescriptionTest()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string description = "DummyDescription";
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);

            _model.AddMemento(drawingMemento);

            Assert.AreEqual(description, _model.GetNextUndoDescription());
        }

        [TestMethod()]
        public void GetNextRedoDescriptionTest()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string description = "DummyDescription";
            string anotherDescription = "AnotherDummyDescription";
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);
            DrawingMemento anotherDrawingMemento = new DrawingMemento(Image.FromFile(validImagePath), anotherDescription);

            _model.AddMemento(drawingMemento);
            _model.AddMemento(anotherDrawingMemento);
            _model.Undo();

            Assert.AreEqual(anotherDescription, _model.GetNextRedoDescription());
        }

        [TestMethod()]
        public void DropMementosTest()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string description = "DummyDescription";
            string anotherDescription = "AnotherDummyDescription";
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);
            DrawingMemento anotherDrawingMemento = new DrawingMemento(Image.FromFile(validImagePath), anotherDescription);

            _model.AddMemento(drawingMemento);
            _model.AddMemento(anotherDrawingMemento);
            _model.DropMementos();

            Assert.AreEqual(String.Empty, _model.GetNextRedoDescription());
        }

        [TestMethod()]
        public void RedoTest()
        {
            string validImagePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\testImage.jpg";
            string description = "DummyDescription";
            string anotherDescription = "AnotherDummyDescription";
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(validImagePath), description);
            DrawingMemento anotherDrawingMemento = new DrawingMemento(Image.FromFile(validImagePath), anotherDescription);

            _model.AddMemento(drawingMemento);
            _model.AddMemento(anotherDrawingMemento);
            _model.AddMemento(drawingMemento);

            _model.Undo();
            _model.Redo();

            Assert.AreEqual(String.Empty, _model.GetNextRedoDescription());
            Assert.AreEqual(description, _model.GetNextUndoDescription());
        }

        // the purpose of these tests is to assure that there are no problems when calling undo and redo related methods
        // when the event stack (undo stack) is empty
        [TestMethod()]
        public void UndoWithEmptyStack()
        {
            _model.Undo();
            Assert.AreEqual(String.Empty, _model.GetNextRedoDescription());
        }

        [TestMethod()]
        public void RedoWithEmptyStack()
        {
            _model.Redo();
            Assert.AreEqual(String.Empty, _model.GetNextUndoDescription());
        }
        #endregion
    }
}