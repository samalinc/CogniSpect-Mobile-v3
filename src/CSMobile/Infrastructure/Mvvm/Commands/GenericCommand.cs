using System;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Mvvm.Commands
{
    public sealed class Command<T> : Command
    {
        public Command([NotNull] Action<T> execute) : base(o => { execute((T) o); })
        {
        }
    }
}