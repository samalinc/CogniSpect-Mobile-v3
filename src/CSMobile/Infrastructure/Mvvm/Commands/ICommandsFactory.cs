using System.Windows.Input;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Mvvm.Commands
{
    public interface ICommandsFactory
    {
        [NotNull]
        ICommand Command([NotNull] CommandConfigs configs);
    }
}