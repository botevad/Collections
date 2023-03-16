using System.Collections.ObjectModel;

namespace Collection.UnitTests
{
    public class CollectionTests
    {


        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            //Arrange and Act
            var coll = new Collection

            //Assert
            Assert.AreEqual(coll.ToString(), "[}");
        }
    }
}