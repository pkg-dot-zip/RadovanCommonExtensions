using RadovanCommonExtensions.Extensions.Reflection;
using Shouldly;

namespace RadovanCommonExtensionsTests.Extensions.Reflection
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        #region TestClasses

        private const int TestNumber1 = 10;
        private const int TestNumber2 = 11;
        private const int TestNumber3 = 12;

        public class TestClass1
        {
            public static int GetNumber() => TestNumber1;

            public static Type GetTypeStatic<T>() => typeof(T);
        }

        public class TestClass2()
        {
            public static int GetNumber() => TestNumber2;
            public int GetNumber2() => TestNumber3;

            public static Type GetTypeStatic<T>() => typeof(T);
            public Type GetType<T>() => typeof(T);
        }

        #endregion

        #region InvokeObj

        [TestMethod]
        public void InvokeObj_StaticMethod_CallsAndReturnsCorrectValue()
        {
            var obj = new TestClass1();
            var value = obj.InvokeObj(nameof(obj.GetNumber));
            if (value is int val)
            {
                val.ShouldBe(TestNumber1);
            }
            else
            {
                Assert.Fail("{0} should be of type {1}.", nameof(value), nameof(Int32));
            }
        }

        [TestMethod]
        public void InvokeObj_NonStaticMethod_CallsAndReturnsCorrectValue()
        {
            var obj = new TestClass2();
            var value = obj.InvokeObj(nameof(obj.GetNumber2));
            if (value is int val)
            {
                val.ShouldBe(TestNumber3);
            }
            else
            {
                Assert.Fail("{0} should be of type {1}.", nameof(value), nameof(Int32));
            }
        }

        [TestMethod]
        public void InvokeObj_NonStaticMethod_MethodDoesNotExist_ThrowsException()
        {
            var obj = new TestClass1();
            var action = () => obj.InvokeObj("Non-existing-method");
            action.ShouldThrow<Exception>();
        }

        #endregion

        #region InvokeObjWithGenerics

        [TestMethod]
        [DataRow(typeof(int))]
        [DataRow(typeof(double))]
        [DataRow(typeof(char))]
        public void InvokeObjWithGenerics_StaticMethod_CallsAndReturnsCorrectValue(Type type)
        {
            var obj = new TestClass1();
            var value = obj.InvokeObjWithGenerics(nameof(TestClass1.GetTypeStatic), [type]);
            if (value is Type val)
            {
                val.ShouldBe(type);
            }
            else
            {
                Assert.Fail("{0} should be of type {1}.", nameof(value), nameof(Type));
            }
        }

        [TestMethod]
        [DataRow(typeof(int))]
        [DataRow(typeof(double))]
        [DataRow(typeof(char))]
        public void InvokeObjWithGenerics_NonStaticMethod_CallsAndReturnsCorrectValue(Type type)
        {
            var obj = new TestClass2();
            var value = obj.InvokeObjWithGenerics(nameof(obj.GetType), [type]);
            if (value is Type val)
            {
                val.ShouldBe(type);
            }
            else
            {
                Assert.Fail("{0} should be of type {1}.", nameof(value), nameof(Type));
            }
        }

        [TestMethod]
        [DataRow(typeof(int))]
        [DataRow(typeof(double))]
        [DataRow(typeof(char))]
        public void InvokeObjWithGenerics_NonStaticMethod_MethodDoesNotExist_ThrowsException(Type type)
        {
            var obj = new TestClass1();
            var action = () => obj.InvokeObjWithGenerics("Non-existing-method", [type]);
            action.ShouldThrow<Exception>();
        }

        #endregion
    }
}