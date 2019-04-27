using System;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Common
{
    public class DyingWrapper<TDying> : IDisposable where TDying : IDisposable
    {
        public bool IsDead { get; private set; }

        [NotNull] public TDying Dying { get; }

        private readonly object _lockObject = new object();

        public DyingWrapper([NotNull] TDying dying)
        {
            Dying = dying;
        }

        public void Dispose()
        {
            KillDying();
        }

        private void KillDying()
        {
            lock (_lockObject)
            {
                if (IsDead)
                {
                    return;
                }

                Dying.Dispose();
                IsDead = true;
            }
        }
    }
}