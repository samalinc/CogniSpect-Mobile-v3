using System;
using System.Threading.Tasks;
using CSMobile.Infrastructure.Mvvm.ViewModelsCore;
using JetBrains.Annotations;

namespace CSMobile.Infrastructure.Mvvm.Commands
{
    public class CommandConfigs
    {
        public CommandConfigs(
            [NotNull] Func<Task> action,
            [NotNull] BasePageViewModel rootPageViewModel,
            bool isGlobalLoading = default(bool))
        {
            Action = action;
            RootPageViewModel = rootPageViewModel;
            IsGlobalLoading = isGlobalLoading;
        }

        [NotNull]
        public Func<Task> Action { get; set; }

        [NotNull]
        public BasePageViewModel RootPageViewModel { get; set; }

        public bool IsGlobalLoading { get; set; }
    }
}