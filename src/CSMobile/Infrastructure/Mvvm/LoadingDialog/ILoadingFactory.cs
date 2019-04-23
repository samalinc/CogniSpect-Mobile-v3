using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Mvvm.LoadingDialog
{
    public interface ILoadingFactory
    {
        [NotNull]
        ILoading Create(string message = null);
    }
}