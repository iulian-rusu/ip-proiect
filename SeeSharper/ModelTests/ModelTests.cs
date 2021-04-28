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
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile("\\"), "");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void LoadDrawingTestInvalidPath()
        {
            DrawingMemento drawingMemento = new DrawingMemento(Image.FromFile(""), "");
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

        /*
         to add tests about: - Loading a valid image
                             - Saving an image  
                             - Description Getters
        */
    }
}