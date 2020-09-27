using MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM.ViewModels
{
    class MainWindowViewModel:NotificationObject
    {
        #region 数据属性
        private double add1;

        public double Add1
        {
            get { return add1; }
            set
            {
                add1 = value;
                this.RaisePropertyChanged("Add1");
            }
        }
        private double add2;
        public double Add2
        {
            get { return add2; }
            set
            {
                add2 = value;
                this.RaisePropertyChanged("Add2");
            }
        }

        private double sum;
        public double Sum
        {
            get { return sum; }
            set
            {
                sum = value;
                this.RaisePropertyChanged("Sum");
            }
        }

        #endregion

        #region 命令属性
        public  DelegateCommand AddCommand { get; set; }
        private void Add(object parameter)
        {
            this.Sum = this.Add1 + this.Add2;
        }
        #endregion
        public MainWindowViewModel()
        {
            this.AddCommand = new DelegateCommand();
            this.AddCommand.ExecuteAction = new Action<object>(this.Add);
        }
    }
}
