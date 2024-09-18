using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{
    public class MainViewModel : ViewModelBase
    {
        static decimal result = 3;

        private string process = "";


        public decimal Result 
        { 
            get { return result; } 
            set 
            { 
                result = value;
                OnPropertyChanged(nameof(Result));
            } 
        }

        public string Process
        { 
            get { return process; } 
            set { process = value; } 
        }
        public ICommand PlusCommand { get; }

        public MainViewModel()
        {
            PlusCommand = new RelayCommand(plus);
        }
        public void plus()
        {
            Result += 1;
        }

    }
}
