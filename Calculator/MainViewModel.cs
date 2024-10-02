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
        /// <summary>
        /// 결과값
        /// </summary>
        private decimal mResult = 0;

        /// <summary>
        /// 이전 입력값
        /// </summary>
        private decimal mInput = 0;

        /// <summary>
        /// 계산 과정
        /// </summary>
        private string mProcess = "";

        /// <summary>
        /// 연산자
        /// </summary>
        private OperatorEnum mOperator = 0;

        /// <summary>
        /// 연산자 Enum
        /// </summary>
        public enum OperatorEnum
        {
            Add, Subtract, Multiple, Divide 
        }

        public decimal Result 
        { 
            get { return mResult; } 
            set 
            {
                mResult = value;
                OnPropertyChanged(nameof(Result));
            } 
        }

        public decimal Input
        {
            get { return mInput; }
            set
            {
                mInput = value;
                OnPropertyChanged(nameof(Input));
            }
        }

        public OperatorEnum Operator
        {
            get { return mOperator; }
            set
            {
                mOperator = value;
                OnPropertyChanged(nameof(Operator));
            }

        }

        public string Process
        { 
            get { return mProcess; } 
            set 
            { 
                mProcess = value;
                OnPropertyChanged(nameof(Process));
            } 
        }

        public ICommand PlusCommand { get; }
        
        public ICommand CalculateCommand { get; }

        public MainViewModel()
        {
            PlusCommand = new RelayCommand(plus);
            CalculateCommand = new RelayCommand(calculate);
        }
        public void plus()
        {
            if(Process != null)
            {
                Process = "";
            }

            Process += mResult + " + ";

            
            mOperator = OperatorEnum.Add;
            //mProcess += mResult + " + ";
            
            Input = Result;
            Result = 0;
            
        }

        public void calculate()
        {
            switch (Operator)
            {
                case OperatorEnum.Add:
                    {
                        Process += mResult + " = ";
                        Result = mResult + mInput; 
                        break;
                    }

                case OperatorEnum.Subtract: Result = mResult - mInput; break;
                case OperatorEnum.Multiple: Result = mResult * mInput; break;
                case OperatorEnum.Divide: Result = mResult / mInput; break;
            }
            Operator = 0;
        }

    }
}
