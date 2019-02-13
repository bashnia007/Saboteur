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

        private readonly Client _client;
        private NetworkStream _stream;

        #endregion

        #region Constructors
        /*
        public PlayerActionsViewModel()
        {
            _client = new Client();
            _client.Connect(TcpConfig.Ip, TcpConfig.Port);
            _stream = _client.GetStream();
        }*/

        #endregion

        #region Commands

        #region BuildCommand

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

        #region TakeCommand

        private RelayCommand _takeCommand;

        public ICommand TakeCommand => _takeCommand ?? (_takeCommand =
                                            new RelayCommand(ExecuteTakeCommand, CanExecuteTakeCommand));

        private void ExecuteTakeCommand(object obj)
        {
            string response = "Take!";
            byte[] data = Encoding.UTF8.GetBytes(response);
            _stream.Write(data, 0, data.Length);
        }

        private bool CanExecuteTakeCommand(object obj)
        {
            return true;
        }

        #endregion

        #region MakeActionCommand

        private RelayCommand _makeActionCommand;

        public ICommand MakeActionCommand => _makeActionCommand ?? (_makeActionCommand =
                                           new RelayCommand(ExecuteMakeActionCommand, CanExecuteMakeActionCommand));

        private void ExecuteMakeActionCommand(object obj)
        {
            string response = "Make action!";
            byte[] data = Encoding.UTF8.GetBytes(response);
            _stream.Write(data, 0, data.Length);
        }

        private bool CanExecuteMakeActionCommand(object obj)
        {
            return true;
        }

        #endregion

        #endregion
    }
}
