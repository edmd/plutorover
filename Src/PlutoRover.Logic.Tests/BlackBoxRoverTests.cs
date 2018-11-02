using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PlutoRover.Logic.Tests
{
    [TestClass]
    public class BlackBoxRoverTests
    {
        private Mock<IPlanet> _planet;

        [TestInitialize]
        public void TestStartup()
        {
            _planet = new Mock<IPlanet>();
            var surfaceArea = new int[4, 4]
                { { 0, 1, 0, 0 },
                  { 0, 0, 1, 0 },
                  { 1, 1, 0, 0 },
                  { 0, 0, 0, 0 } };

            _planet.Setup(x => x.SurfaceArea).Returns(surfaceArea);

            /* 0 0 1 0
             * 1 0 1 0
             * 0 1 0 0
             * 0 0 0 0
             */
        }

        [DataRow("F F L F R", "N 3, 2")]
        [DataRow("R F R F L L", "N 1, 1")]
        [DataRow("R F L F R F F", "E 3, 3")]
        [DataRow("F L F R F F R", "E 3, 1")]
        [DataRow("F L F R F F R F R", "S 3, 1")] // Obstacle encountered. Move aborted.
        [DataTestMethod]
        public void CoordinateTesting(string route, string expectedPosition)
        {
            IRover rover = new Rover(_planet.Object, route);
            rover.ExecuteRoute();
            Assert.AreEqual(rover.FinalPosition(), expectedPosition);
        }
    }
}