namespace UnitTest;

using ForestFireSimulation.Entities;

public class Tests
{
    [TestFixture]
    public class TreeTests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            int x = 5;
            int y = 10;
            bool displayMode = true;

            var tree = new Tree(x, y, displayMode);

            Assert.AreEqual(x, tree.X);
            Assert.AreEqual(y, tree.Y);
            Assert.AreEqual(TreeState.Alive, tree.State);
            Assert.AreEqual(displayMode, tree.DisplayMode);
        }

        [Test]
        public void Ignite_ChangesStateToBurning()
        {
            var tree = new Tree(0, 0, false);

            tree.Ignite();

            Assert.AreEqual(TreeState.Burning, tree.State);
        }

        [Test]
        public void Update_BurningTreeTurnsToBurnedAfterMaxTurns()
        {
            var tree = new Tree(0, 0, false);
            tree.Ignite();

            for (int i = 0; i < 3; i++)
            {
                tree.Update();
            }

            Assert.AreEqual(TreeState.Burned, tree.State);
        }

        [Test]
        public void Regrow_ChangesStateToAlive()
        {
            var tree = new Tree(0, 0, false);
            tree.Ignite();
            for (int i = 0; i < 3; i++)
            {
                tree.Update();
            }

            tree.Regrow();

            Assert.AreEqual(TreeState.Alive, tree.State);
        }

        [Test]
        public void Display_DoesNotThrowException()
        {
            var tree = new Tree(0, 0, true);

            Assert.DoesNotThrow(() => tree.Display());
        }
    }
}