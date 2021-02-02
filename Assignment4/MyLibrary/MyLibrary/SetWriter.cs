using System;
using System.IO;

namespace MyLibrary.Writer
{
    public sealed class SetWriter : IDisposable
    {
        private bool _DisposedValue;

        private string? _filePath;

        public string? FilePath
        {
            get => _filePath;
            set => _filePath = value ??
                throw new ArgumentNullException(nameof(value));
        }

        private StreamWriter? fileWriter;

        public StreamWriter? FileWriter
        {
            get => fileWriter;
            set => fileWriter = value ?? 
                throw new ArgumentNullException(nameof(value));
        }

        public SetWriter(string filePath)
        {
            FileWriter = new StreamWriter(filePath);
        }

        public void WriteSet(NumSet numSet)
        {
            FileWriter!.Write(numSet.ToString());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                    FileWriter!.Dispose();

                _DisposedValue = true;
            }
        }
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
