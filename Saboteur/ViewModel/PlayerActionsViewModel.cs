using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Saboteur.Annotations;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class PlayerActionsViewModel : ViewModelBase
    {
        private RelayCommand _buildCommand;

        public ICommand BuildCommand => _buildCommand ?? (_buildCommand =
            new RelayCommand(ExecuteBuildCommand, CanExecuteBuildCommand));

        private void ExecuteBuildCommand(object obj)
        {
            MessageBox.Show("ololo");
        }

        private bool CanExecuteBuildCommand(object obj)
        {
            return true;
        }
    }
}
