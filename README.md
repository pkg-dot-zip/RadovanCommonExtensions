# RadovanCommonExtensions
Simple class library created to avoid duplicate code in projects. 
I noticed that I kept writing the same extension methods in each project. This library was created to avoid that.

## Features
- Added methods for [`ICollection`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1), such as `IsEmpty()` & `AddAll(params)` !
- Utility methods for [reflection](https://learn.microsoft.com/en-us/dotnet/fundamentals/reflection/reflection-and-generic-types) operations. See Examples for details.

And WAY more to come!

## Examples
Some basic [`ICollection`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1) methods.
```cs
public void Example(IList<int> list)
{
    if (list.IsEmpty()) return; // New IsEmpty() method!

    // Logic here!
}

public void Example(ICollection<bool> collection, ICollection<bool> secondCollection)
{
    collection.AddAll(true, false, true); // Adding using params!
    collection.AddAll(secondCollection); // Adding other IEnumerables!
}
```

Invoking methods with [generics](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics) dynamically so you can pass [Type](https://learn.microsoft.com/en-us/dotnet/api/system.type) as a parameter!
```cs
public class ExampleClass
{
    public bool DoSomethingWithGeneric<T>() => false;
}

public void Example(ExampleClass inst, Type genericType)
{
    inst.InvokeObjWithGenerics(nameof(ExampleClass.DoSomethingWithGeneric), [genericType]);
}
```

## What to expect in the feature
*Technically* any extension method can be added, as long as it:
- Needed in two or more projects I am working on.
- Unit tested in the unit test project of this solution.

If you are using this package, feel free to add suggestions if you need something.