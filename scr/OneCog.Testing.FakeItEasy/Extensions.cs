using FakeItEasy.Configuration;
using FakeItEasy.Core;
using System;
using System.Collections.Generic;

namespace OneCog.Testing.FakeItEasy
{
    public static class Extensions
    {
        public static IAfterCallSpecifiedWithOutAndRefParametersConfiguration ReturnsInSequence<T>(this IReturnValueArgumentValidationConfiguration<T> source, params Func<IFakeObjectCall, T>[] results)
        {
            Stack<Func<IFakeObjectCall, T>> sequence = new Stack<Func<IFakeObjectCall, T>>(results);

            return source.ReturnsLazily(call => sequence.Pop()(call));
        }
    }
}
