using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommonLibrary.Tcp;
using Saboteur.Annotations;
using Saboteur.MVVM;

namespace Saboteur.ViewModel
{
    public class PlayerActionsViewModel : ViewModelBase
    {
        #region Fields

        private readonly TcpClient _client;
        private NetworkStream _stream;

        #endregion

        #region Constructors

        public PlayerActionsViewModel()
        {
            _client = new TcpClient();
            _client.Connect(TcpConfig.Ip, TcpConfig.Port);
            _stream = _client.GetStream();
        }

        #endregion

        #region Commands

        private RelayCommand _buildCommand;

        public ICommand BuildCommand => _buildCommand ?? (_buildCommand =
            new RelayCommand(ExecuteBuildCommand, CanExecuteBuildCommand));

        private void ExecuteBuildCommand(object obj)
        {
            string response = "Build!";
            byte[] data = Encoding.UTF8.GetBytes(response);
            _stream.Write(data, 0, data.Length);
        }

        private bool CanExecuteBuildCommand(object obj)
        {
            return true;
        }

        #endregion
    }
}
