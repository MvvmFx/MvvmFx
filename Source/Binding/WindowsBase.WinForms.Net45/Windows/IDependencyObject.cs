//
// IDependencyObject.cs
//
// Author:
//   Tiago Freitas Leal
//
// (C) 2012 MvvmFx project
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Bindings
{
    /// <summary>
    /// Defines methods and properties that an object implements to use <see cref="MvvmFx.Bindings.DependencyProperty"/>.
    /// </summary>
    public interface IDependencyObject
    {
        bool IsSealed { get; }

        DependencyObjectType DependencyObjectType { get; }

        void ClearValue(DependencyPropertyKey key);

        void ClearValue(DependencyProperty dp);

        void CoerceValue(DependencyProperty dp);

        [SuppressMessage("Microsoft.Design", "CA1024", Justification = "Signature compatibility.")]
        LocalValueEnumerator GetLocalValueEnumerator();

        object GetValue(DependencyProperty dp);

        void InvalidateProperty(DependencyProperty dp);

        object ReadLocalValue(DependencyProperty dp);

        void SetValue(DependencyPropertyKey key, object value);

        void SetValue(DependencyProperty dp, object value);
    }
}
