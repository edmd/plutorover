using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PlutoRover.Logic.Tests
{
    [TestClass]
    public class PlanetTests
    {
        private Mock<IPlanet> _planet;

        [TestInitialize]
        public void TestStartup()
        {
            _planet = new Mock<IPlanet>();
            _planet.Setup(x => x.SurfaceArea).Returns(new int[1, 1]);

        }

        [TestMethod]
        public void PlanetDimensionTest()
        {
            Assert.AreEqual(1, _planet.Object.SurfaceArea.GetLength(0));
            Assert.AreEqual(1, _planet.Object.SurfaceArea.GetLength(1));
        }
    }
}