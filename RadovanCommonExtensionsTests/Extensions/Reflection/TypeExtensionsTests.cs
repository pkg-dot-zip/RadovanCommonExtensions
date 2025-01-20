using Shouldly;
using RadovanCommonExtensions.Extensions.Reflection;

namespace RadovanCommonExtensionsTests.Extensions.Reflection
{
    [TestClass]
    public class TypeExtensionsTests
    {
        #region InvokeType

        #region TestClasses

        private const int TestNumber1 = 10;
        private const int TestNumber2 = 11;
        private const int TestNumber3 = 12;

        public static class StaticClass1
        {
            public static int GetNumber() => TestNumber1;

            public static Type GetTypeStatic<T>() => typeof(T);
        }

        public class NonStaticTestClass1()
        {
            public static int GetNumber() => TestNumber2;
            public int GetNumber2() => TestNumber3;

            public static Type GetTypeStatic<T>() => typeof(T);
            public Type GetType<T>() => typeof(T);
        }

        #endregion

        [TestMethod]
        public void InvokeType_StaticMethodInStaticClass_CallsAndReturnsCorrectValue()
        {
            var value = typeof(StaticClass1).InvokeType(nameof(StaticClass1.GetNumber), null!);
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
        public void InvokeType_StaticMethodInNonStaticClass_CallsAndReturnsCorrectValue()
        {
            var value = typeof(NonStaticTestClass1).InvokeType(nameof(NonStaticTestClass1.GetNumber), null!);
            if (value is int val)
            {
                val.ShouldBe(TestNumber2);
            }
            else
            {
                Assert.Fail("{0} should be of type {1}.", nameof(value), nameof(Int32));
            }
        }

        [TestMethod]
        public void InvokeType_NonStaticMethodInNonStaticClass_CallsAndReturnsCorrectValue()
        {
            var instance = new NonStaticTestClass1();
            var value = typeof(NonStaticTestClass1).InvokeType(nameof(NonStaticTestClass1.GetNumber2), instance);
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
        public void InvokeType_NonStaticMethodInNonStaticClass_CalledWithNullInstance_ThrowsException()
        {
            var action = () => typeof(NonStaticTestClass1).InvokeType(nameof(NonStaticTestClass1.GetNumber2), null!);
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void InvokeType_NonStaticMethodInNonStaticClass_MethodDoesNotExist_ThrowsException()
        {
            var instance = new NonStaticTestClass1();
            var action = () => typeof(NonStaticTestClass1).InvokeType("Non-existing-method", instance);
            action.ShouldThrow<Exception>();
        }

        #endregion

        #region InvokeTypeWithGenerics

        [TestMethod]
        [DataRow(typeof(int))]
        [DataRow(typeof(double))]
        [DataRow(typeof(char))]
        public void InvokeTypeWithGenerics_StaticMethodInStaticClass_CallsAndReturnsCorrectValue(Type type)
        {
            var value = typeof(StaticClass1).InvokeTypeWithGenerics(nameof(StaticClass1.GetTypeStatic), [type], null!);
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
        public void InvokeTypeWithGenerics_StaticMethodInNonStaticClass_CallsAndReturnsCorrectValue(Type type)
        {
            var value = typeof(NonStaticTestClass1).InvokeTypeWithGenerics(nameof(NonStaticTestClass1.GetTypeStatic), [type], null!);
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
        public void InvokeTypeWithGenerics_NonStaticMethodInNonStaticClass_CallsAndReturnsCorrectValue(Type type)
        {
            var instance = new NonStaticTestClass1();
            var value = typeof(NonStaticTestClass1).InvokeTypeWithGenerics(nameof(NonStaticTestClass1.GetType), [type], instance);
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
        public void InvokeTypeWithGenerics_NonStaticMethodInNonStaticClass_CalledWithNullInstance_ThrowsException(Type type)
        {
            var action = () => typeof(NonStaticTestClass1).InvokeTypeWithGenerics(nameof(NonStaticTestClass1.GetType), [type], null!);
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        [DataRow(typeof(int))]
        [DataRow(typeof(double))]
        [DataRow(typeof(char))]
        public void InvokeTypeWithGenerics_NonStaticMethodInNonStaticClass_MethodDoesNotExist_ThrowsException(Type type)
        {
            var instance = new NonStaticTestClass1();
            var action = () => typeof(NonStaticTestClass1).InvokeTypeWithGenerics("Non-existing-method", [type], instance);
            action.ShouldThrow<Exception>();
        }

        #endregion
    }
}