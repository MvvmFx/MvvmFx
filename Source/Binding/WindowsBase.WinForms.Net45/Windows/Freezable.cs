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
// Copyright (c) 2007 Novell, Inc. (http://www.novell.com)
//
// Authors:
//	Chris Toshok (toshok@ximian.com)
//
using System;
using System.Diagnostics.CodeAnalysis;

namespace MvvmFx.Windows
{
    /// <summary>
    /// Freezable
    /// </summary>
    /// <remarks>This class isn't implemented.</remarks>
    public abstract class Freezable : DependencyObject
    {
        protected Freezable()
        {
        }

        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        public Freezable Clone()
        {
            throw new NotImplementedException("Freezable.Clone");
        }

        protected virtual void CloneCore(Freezable sourceFreezable)
        {
            throw new NotImplementedException("Freezable.CloneCore");
        }

        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        public Freezable CloneCurrentValue()
        {
            throw new NotImplementedException("Freezable.CloneCurrentValue");
        }

        protected virtual void CloneCurrentValueCore(Freezable sourceFreezable)
        {
            throw new NotImplementedException("Freezable.CloneCurrentValueCore");
        }

        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected Freezable CreateInstance()
        {
            throw new NotImplementedException("Freezable.CreateInstance");
        }

        protected abstract Freezable CreateInstanceCore();

        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        public void Freeze()
        {
            throw new NotImplementedException("Freezable.CreateInstanceCore");
        }

        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        protected static bool Freeze(Freezable freezable, bool isChecking)
        {
            throw new NotImplementedException("Freezable.Freeze");
        }

        protected virtual bool FreezeCore(bool isChecking)
        {
            throw new NotImplementedException("Freezable.FreezeCore");
        }

        [SuppressMessage("Microsoft.Design", "CA1024", Justification = "Signature compatibility.")]
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        public Freezable GetAsFrozen()
        {
            throw new NotImplementedException("Freezable.GetAsFrozen");
        }

        protected virtual void GetAsFrozenCore(Freezable sourceFreezable)
        {
            throw new NotImplementedException("Freezable.GetAsFrozenCore");
        }

        [SuppressMessage("Microsoft.Design", "CA1024", Justification = "Signature compatibility.")]
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        public Freezable GetCurrentValueAsFrozen()
        {
            throw new NotImplementedException("Freezable.GetCurrentValueAsFrozen");
        }

        protected virtual void GetCurrentValueAsFrozenCore(Freezable sourceFreezable)
        {
            throw new NotImplementedException("Freezable.GetCurrentValueAsFrozenCore");
        }

        protected virtual void OnChanged()
        {
            throw new NotImplementedException("Freezable.OnChanged");
        }

        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected void OnFreezablePropertyChanged(DependencyObject oldValue, DependencyObject newValue)
        {
            throw new NotImplementedException("Freezable.OnFreezablePropertyChanged");
        }

        [SuppressMessage("Microsoft.Usage", "CA1801", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected void OnFreezablePropertyChanged(DependencyObject oldValue, DependencyObject newValue, DependencyProperty property)
        {
            throw new NotImplementedException("Freezable.OnFreezablePropertyChanged");
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException("Freezable.OnPropertyChanged");
        }

        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected void ReadPreamble()
        {
            throw new NotImplementedException("Freezable.ReadPreamble");
        }

        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected void WritePostscript()
        {
            throw new NotImplementedException("Freezable.WritePostscript");
        }

        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        protected void WritePreamble()
        {
            throw new NotImplementedException("Freezable.WritePreamble");
        }

        public bool CanFreeze
        {
            get { return FreezeCore(true); }
        }

        [SuppressMessage("Microsoft.Design", "CA1065", Justification = "The feature isn't implemented.")]
        [SuppressMessage("Microsoft.Performance", "CA1822", Justification = "The feature isn't implemented.")]
        public bool IsFrozen
        {
            get { throw new NotImplementedException("Freezable"); }
        }

#pragma warning disable 67
        public event EventHandler Changed;
#pragma warning restore 67
    }
}
