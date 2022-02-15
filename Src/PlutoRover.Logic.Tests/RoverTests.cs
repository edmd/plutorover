using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PlutoRover.Logic.Tests
{
    [TestClass]
    public class RoverTests
    {
        private IRover _sut;
        private readonly Mock<IPlanet> _planet = new Mock<IPlanet>();

        [TestInitialize]
        public void TestStartup()
        {
            _planet.SetupGet(x => x.SurfaceArea).Returns(new int[100, 100]);
            _sut = new Rover(_planet.Object);
        }

        [TestMethod]
        public void RoverOperationsTest()
        {
            Assert.AreEqual("E 0, 0", _sut.TurnRight());
            Assert.AreEqual("E 1, 0", _sut.MoveForward());
            Assert.AreEqual("S 1, 0", _sut.TurnRight());
            Assert.AreEqual("S 1, 1", _sut.MoveForward());
            Assert.AreEqual("E 1, 1", _sut.TurnLeft());
            Assert.AreEqual("E 2, 1", _sut.MoveForward());
            
            Assert.AreEqual("E 2, 1", _sut.CurrentPosition());
        }
    }
}