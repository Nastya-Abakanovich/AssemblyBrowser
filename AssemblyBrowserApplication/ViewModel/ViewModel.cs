using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using AssemblyBrowserApplication.Model;
using AssemblyBrowserLibrary.AssemblyComposition;


namespace AssemblyBrowserApplication.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string _assemblyPath = "";
        private List<Node> _assemblyTree;

        public string AssemblyPath
        {
            get => _assemblyPath;
            set
            {
                _assemblyPath = value;
                AssemblyTree = AssemblyInfoToTreeConverter.Convert(Core.GetTree(AssemblyPath));                
                OnPropertyChanged(nameof(AssemblyTree));
            }
        }

        public List<Node> AssemblyTree
        {
            get => _assemblyTree;
            set => _assemblyTree = value;
        }

        private OpenFileDialogCommand? _openFileDialog;
        public OpenFileDialogCommand OpenFileDialog
        {
            get
            {
                return _openFileDialog ??
                  (_openFileDialog = new OpenFileDialogCommand(o => OpenAssembly()));
            }
        }

        private void OpenAssembly()
        {

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Assembly";
            dialog.DefaultExt = ".dll";
            dialog.Filter = "Dynamic link library (.dll)|*.dll";
            dialog.Title = "Select assembly";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                AssemblyPath = dialog.FileName;
                OnPropertyChanged(nameof(AssemblyPath));
            }
        }
    }
}


