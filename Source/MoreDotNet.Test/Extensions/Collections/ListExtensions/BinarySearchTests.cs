namespace MoreDotNet.Tests.Extensions.Collections.ListExtensions
{
    using System;
    using System.Collections.Generic;
    using MoreDotNet.Extensions.Collections;
    using Xunit;

    public class BinarySearchTests
    {
        [Fact]
        public void BinarySearch_NullList_ShouldThrowArgumentNullException()
        {
            IList<string> testList = null;
            Assert.Throws<ArgumentNullException>(
                () => testList.BinarySearch(x => { return x; }, null));
        }

        [Fact]
        public void BinarySearch_NullKeySelectorShould_ThrowArgumentNullException()
        {
            IList<string> testList = new List<string>();
            Assert.Throws<ArgumentNullException>(
                () => testList.BinarySearch(null, string.Empty));
        }

        [Fact]
        public void BinarySearch_EmptyList_ShouldThrowArgumentOutOfRangeException()
        {
            IList<string> testList = new List<string>();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => testList.BinarySearch(x => x, string.Empty));
        }

        [Fact]
        public void BinarySearch_ListItemNotFound_ShouldThrowArgumentOutOfRangeException()
        {
            IList<string> testList = new List<string> { "TestItem" };
            Assert.Throws<InvalidOperationException>(
                () => testList.BinarySearch(x => x, "doesNotExist"));
        }

        [Fact]
        public void BinarySearch_OneItemListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "TestItem" };
            var item = testList.BinarySearch(x => x, "TestItem");

            Assert.Equal("TestItem", item);
        }

        [Fact]
        public void BinarySearch_ItemFirstInEvenNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem" };
            var item = testList.BinarySearch(x => x, "Item");

            Assert.Equal("Item", item);
        }

        [Fact]
        public void BinarySearch_ItemLastInEvenNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem" };
            var item = testList.BinarySearch(x => x, "OtherItem");

            Assert.Equal("OtherItem", item);
        }

        [Fact]
        public void BinarySearch_ItemFirstInOddNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem", "ZItem" };
            var item = testList.BinarySearch(x => x, "Item");

            Assert.Equal("Item", item);
        }

        [Fact]
        public void BinarySearch_ItemMiddleInOddNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem", "ZItem" };
            var item = testList.BinarySearch(x => x, "OtherItem");

            Assert.Equal("OtherItem", item);
        }

        [Fact]
        public void BinarySearch_ItemLastInOddNumberListSearchForItem_ShouldReturnItem()
        {
            IList<string> testList = new List<string> { "Item", "OtherItem", "ZItem" };
            var item = testList.BinarySearch(x => x, "ZItem");

            Assert.Equal("ZItem", item);
        }
    }
}
