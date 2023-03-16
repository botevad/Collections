namespace Collections.UnitTests
{
    public class CollectionsTests
    {


        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            
            // Arrange and Act

            var coll = new Collection<int>();

            //Assert
            Assert.AreEqual(coll.ToString(), "[]");
            
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem() 
        {
            var coll = new Collection<int> (5);
            
            // Assert
            Assert.AreEqual(coll.ToString(), "[5]");

        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var coll = new Collection<int>(5,6);
            var actual = coll.ToString();
            var expected = "[5, 6]";    

            // Assert
            Assert.AreEqual(actual, expected);

        }

        [Test]
        public void Test_Collection_CountAndCapacity() 
        {
            var coll = new Collection<int>(7, 8);

            //Assert
            Assert.AreEqual(coll.Count, 2);
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));

        }

        [Test]
        public void Test_Collection_Add()
        {
            //Arrange
            var coll = new Collection<string>("Ivan", "Petar");

            //Act
            coll.Add("Stefan");

            //Assert
            Assert.AreEqual(coll.ToString(), "[Ivan, Petar, Stefan]");
        }

        [Test]
        public void Test_Collection_GetByIndex()
        {
            //Arrange
            var coll = new Collection<string>("Ivan", "Stoyan");
            var item1 = coll[1];

            //Assert
            Assert.That(item1, Is.EqualTo(coll[1]));

        }

        [Test]
        public void Test_Collection_SetByIndex()
        {
            //Arrange
            var coll = new Collection<string>("Ivan", "Stoyan");
            coll[1] = "Bobi";
            var item1 = coll[1];

            //Assert
            Assert.That(item1, Is.EqualTo("Bobi"));

        }

        [Test]
        public void Test_Collection_GetByInvalidIndex()
        {
            //Arrange
            var coll = new Collection<string>("Ivan", "Stoyan");


            //Assert
            Assert.That(() => { var name = coll[2]; },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void Test_Collection_AddRange()
        {
            //Arrange
            var coll = new Collection<int>();
            //Console.WriteLine(coll.ToString());
            var addedNums = Enumerable.Range(3, 7).ToArray();
            coll.AddRange(addedNums);
            string expectedNums = "[" + string.Join(", ", addedNums) + "]";

            //Assert
            Assert.That(coll.ToString(), Is.EqualTo(expectedNums));

        }

        [Test]
        public void Test_Collection_AddRangeWithGrow()

        {

            var nums = new Collection<int>();

            int oldCapacity = nums.Capacity;

            var newNums = Enumerable.Range(1000, 2000).ToArray();

            nums.AddRange(newNums);
           // Console.WriteLine(nums.ToString());

            string expectedNums = "[" + string.Join(", ", newNums) + "]";

            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));

            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));

            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));

        }

        [Test]

        public void Test_Collection_InsertAtStart()

        {
            //Arrange
            var nums = new Collection<int>(1,2,3);

            //Act
            nums.InsertAt(0, 0);

            //Assert
            Assert.That(nums[0], Is.EqualTo(0));
        }

        [Test]
        public void Test_Collection_InsertAtEnd()

        {
            //Arrange
            var nums = new Collection<int>(1, 2, 3);

            //Act
            nums.InsertAt(3, 4);

            //Assert
            Assert.That(nums[3], Is.EqualTo(4));
        }

        [Test]
        public void Test_Collection_InsertAtMiddle()

        {
            //Arrange
            var nums = new Collection<int>(1, 2, 3);

            //Act
            nums.InsertAt(1, 5);
            Console.WriteLine(nums);
            //Assert
            Assert.That(nums[1], Is.EqualTo(5));
        }

        [Test]
        public void Test_Collection_InsertAtInvalidIndex()
        {
            var coll = new Collection<int>(5, 6, 7, 8);

            var indexOutOfRange = coll.Capacity + 1;

            Assert.That(() => { coll.InsertAt(indexOutOfRange, 55); },
                Throws.InstanceOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void Test_Collection_RemoveAtMiddle()

        {

        }

        [Test]
        public void Test_Collection_RemoveAtStart()

        {

        }

        [Test]
        public void Test_Collection_RemoveAtEnd()

        {

        }

        [Test]
        public void Test_Collection_RemoveAtInvalidIndex()

        {

        }
        [Test]
        public void Test_Collection_RemoveAll()

        {

        }

        [Test]
        public void Test_Collection_Clear()

        {

        }

        [Test]
        public void Test_Collection_ExchangeMiddle()

        {

        }

        [Test]
        public void Test_Collection_ExchangeFirstLast()

        {

        }

        [Test]
        public void Test_Collection_ExchangeInvalidIndexes()

        {

        }

        [Test]
        public void Test_Collection_ToStringEmpty()

        {

        }

        [Test]
        public void Test_Collection_ToStringSingle()

        {

        }

        [Test]
        public void Test_Collection_ToStringMultiple()

        {

        }

        [Test]

        public void Test_Collection_ToStringNestedCollections()

        {

            var names = new Collection<string>("Teddy", "Gerry");

            var nums = new Collection<int>(10, 20);

            var dates = new Collection<DateTime>();

            var nested = new Collection<object>(names, nums, dates);

            string nestedToString = nested.ToString();

            Assert.That(nestedToString,

              Is.EqualTo("[[Teddy, Gerry], [10, 20], []]"));

        }

        [Test]

        [Timeout(1000)]

        public void Test_Collection_1MillionItems()

        {

            const int itemsCount = 1000000;

            var nums = new Collection<int>();

            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());

            Assert.That(nums.Count == itemsCount);

            Assert.That(nums.Capacity >= nums.Count);

            for (int i = itemsCount - 1; i >= 0; i--)

                nums.RemoveAt(i);

            Assert.That(nums.ToString() == "[]");

            Assert.That(nums.Capacity >= nums.Count);

        }








    }
}