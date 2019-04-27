using System;

namespace CSMobile.Infrastructure.Common
{
    public class DyingWrapper<TDying> : IDisposable where TDying : IDisposable
    {
        public bool IsDead { get; private set; }

        public TDying Dying { get; }
        
        private readonly object _lockObject = new object();

        public DyingWrapper(TDying dying)
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