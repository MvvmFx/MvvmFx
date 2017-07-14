using System;
using System.Collections.Generic;
using MvvmFx.Windows.Specifications.Support.Entities;

namespace MvvmFx.Windows.Specifications.Support
{
    public static class TheoryHelper
    {
        public static IEnumerable<Func<IPerson>> PersonFactories
        {
            get
            {
                yield return () => new MvvmFx.Windows.Specifications.Support.Entities.INPC.Person();
                yield return () => new MvvmFx.Windows.Specifications.Support.Entities.XxxChanged.Person();
                yield return () => new MvvmFx.Windows.Specifications.Support.Entities.SystemDOs.Person();
                yield return () => new MvvmFx.Windows.Specifications.Support.Entities.MvvmFxDOs.Person();
            }
        }

        public static IEnumerable<Func<IAddress>> AddressFactories
        {
            get
            {
                yield return () => new MvvmFx.Windows.Specifications.Support.Entities.INPC.Address();
                yield return () => new MvvmFx.Windows.Specifications.Support.Entities.XxxChanged.Address();
                yield return () => new MvvmFx.Windows.Specifications.Support.Entities.SystemDOs.Address();
                yield return () => new MvvmFx.Windows.Specifications.Support.Entities.MvvmFxDOs.Address();
            }
        }
    }
}