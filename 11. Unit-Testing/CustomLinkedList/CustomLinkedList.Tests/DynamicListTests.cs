using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomLinkedList.Tests
{
    [TestClass]
    public class DynamicListTests
    {
        [TestMethod]
        public void TestInitializingDynamicList()
        {
            var dynamicList = new DynamicList<int>();
            int initialSize = dynamicList.Count;
            Assert.AreEqual(0, initialSize, "Dynamic list should have a size of 0 after initialization.");
        }

        [TestMethod]
        public void TestAddOneElementToDynamicList()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();
            dynamicList.Add(5);
            Assert.AreEqual(1, dynamicList.Count, "Dynamic list should have one item.");
        }
    }
}
