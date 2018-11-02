using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PlutoRover.Logic.Tests
{
    [TestClass]
    public class RoverTests
    {
        // Might need to rework App in order to test these methods (covered by blackbox tests though)
        //void CalculateRoute(string commands)
        //void ExecuteRoute()

        private Mock<IRover> _rover;

        [TestInitialize]
        public void TestStartup()
        {
            _rover = new Mock<IRover>();
            _rover.Setup(x => x.CalculateRoute("F F F"));
            _rover.Setup(x => x.Forward()).Returns("N 1, 1");
            _rover.Setup(x => x.Back()).Returns("S 0, 1");
            _rover.Setup(x => x.Left()).Returns("E 0, 0");
            _rover.Setup(x => x.Right()).Returns("W 1, 1");
            _rover.Setup(x => x.FinalPosition()).Returns("N 10, 56");
            _rover.Setup(x => x.Route).Returns(new Action[5]);

        }

        [TestMethod]
        public void RouteLengthTest()
        {
            Assert.AreEqual(5, _rover.Object.Route.Length);
        }

        [TestMethod]
        public void RoverOperationsTest()
        {
            Assert.AreEqual("N 1, 1", _rover.Object.Forward());
            Assert.AreEqual("S 0, 1", _rover.Object.Back());
            Assert.AreEqual("E 0, 0", _rover.Object.Left());
            Assert.AreEqual("W 1, 1", _rover.Object.Right());
            Assert.AreEqual("N 10, 56", _rover.Object.FinalPosition());
        }
    }
}