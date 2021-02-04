using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary
{
    public class NumSet
    {
        private HashSet<int>? mySet;

        public HashSet<int>? MySet 
        { 
            get => mySet; 
            set => mySet = value ??
                throw new ArgumentNullException(nameof(value)); 
        }

        public NumSet(params int[] array)
        {
            mySet = new HashSet<int>(array);
        }

        public override string ToString()
        {
            return String.Join(", ", MySet!);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not NumSet)
                return false;

            return MySet == ((NumSet)obj).MySet;
        }

        public override int GetHashCode()
        {
            int rv = 197;
            rv ^= MySet!.GetHashCode() * 197;
            return rv;
        }

        public static bool operator ==(NumSet first, NumSet second)
        {
            if (first is null && second is null)
                return true;
            
            if (first is null ^ second is null)
                return false;
    
            return first!.Equals(second);
        }

        public static bool operator !=(NumSet first, NumSet second)
            => !(first == second);

        public int[] ReturnArray()
            => MySet!.ToArray();

        public static implicit operator int[](NumSet numSet) => numSet.ReturnArray();
    }
}

/*
Instructions
Create both a class library project and a unit test project.

You may pick any reasonable name you want for the project, but unit test project should have a .Tests suffix (ie. .Tests)
Projects should all target net5.
Ensure you enable nullable reference types, warnings as errors, and enabled .NET analyzers for both projects

Write an NumSet class (not a record) with the following behavior
-A constructor that accepts a variable number of integers (params array)
-ToString method should display all of the numbers in the set.
-Equals/GetHashCode implementation should be based on the integers within the NumSet. Because this is a set, the order of the items should not matter (ie. A set with (1, 2, 3) should equal a set with (3, 2, 1))
-Add equality operators (== and !=) for NumSet
-Add a method to return an array with the number from the set. Modifying the returned array should not change the NumSet in any way.
-Use appropriate access modifiers for all members. Follow the principle of least access; if it doesn't need to be public use a different accessor.
-All members should be fully unit tested

Write a SetWriter class this class will be responsible for writing the set to a file.
-This class should be in a nested namespace
-This class should take in a file to write to in its constructor. In the constructor create a StreamWriter instance to use to write the file.
-This class should have a method that writes the values in the set to the file.
-This class should implement IDispoable following the disposable pattern. Clean up the StreamWriter instance that was created in the constructor.
-This class should be fully unit tested

Extra Credit
-Write an implicit cast operator to converter NumSet a C# array. Ensure null cases are properly handled. This should also be unit tested.
-The process of constantly setting up your projects with duplicate properties can be simplified by using a Directory.Build.props file. Implement this in your pull request. Ensure that properties set in that file are not set within the project files.
*/
