using RadovanCommonExtensions.Extensions;
using Shouldly;

namespace RadovanCommonExtensionsTests.Extensions
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class ICollectionExtensionsTests
    {
        #region IsEmpty

        [TestMethod]
        public void IsEmpty_ListContainsNoValues_ReturnsTrue()
        {
            // Arrange.
            List<int> list = [];

            // Act.
            var isEmpty = list.IsEmpty();

            // Assert.
            isEmpty.ShouldBeTrue("no items were added to the list");
        }

        [TestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 3 })]
        public void IsEmpty_ListContainsValues_ReturnsFalse(int[] integers)
        {
            // Arrange.
            List<int> list = [];
            list.AddRange(integers);

            // Act.
            var isEmpty = list.IsEmpty();

            // Assert.
            isEmpty.ShouldBeFalse("items were added to the list");
        }

        #endregion

        #region AddAll

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 8, 2, 3 })]
        [DataRow(new int[] { -2398, 21985, 12598 })]
        [DataRow(new int[] { -298, 215, -198 })]
        public void AddAllEnumerable_IntData_Contains_IntData_ReturnTrue(int[] value)
        {
            // Arrange.
            var list = new List<int>();
            var listToAddFrom = value.ToList();

            // Act.
            list.AddAll(listToAddFrom);

            // Assert.
            list.Count.ShouldNotBe(0);

            foreach (var i in listToAddFrom)
            {
                list.ShouldContain(i);
            }
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 8, 2, 3 })]
        [DataRow(new int[] { -2398, 21985, 12598 })]
        [DataRow(new int[] { -298, 215, -198 })]
        public void AddAllParams_IntData_Contains_IntData_ReturnTrue(int[] value)
        {
            // Arrange.
            var list = new List<int>();

            // Act.
            list.AddAll(value);

            // Assert.
            list.Count.ShouldNotBe(0);

            foreach (var i in value)
            {
                list.ShouldContain(i);
            }
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(123)]
        [DataRow(-1241)]
        [DataRow(int.MaxValue)]
        [DataRow(int.MinValue)]
        public void AddAllEnumerable_Int_EndsWith_Int_ReturnTrue(int value)
        {
            // Arrange.
            var list = new List<int> { 98, 912, 173, 123 };
            var listToAddFrom = new List<int> { value };

            // Act.
            list.AddAll(listToAddFrom);

            // Assert.
            listToAddFrom.Last().ShouldBe(value);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(123)]
        [DataRow(-1241)]
        [DataRow(int.MaxValue)]
        [DataRow(int.MinValue)]
        public void AddAllParams_Int_EndsWith_Int_ReturnTrue(int value)
        {
            // Arrange.
            var list = new List<int> { 98, 912, 173, 123 };
            var listToAddFrom = new[] { value };

            // Act.
            list.AddAll(listToAddFrom);

            // Assert.
            listToAddFrom.Last().ShouldBe(value);
        }

        #endregion
    }
}