using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_DataBinding.Commands;
namespace WPF_DataBinding.ViewModels//三个数据属性，两个命令属性
{
    #region 数据属性
    class MainWindowViewModel :NotificationObject
    {
        private double add1;//数据属性
        public double Add1
        {
            get { return add1; }
            set
            {
                add1 = value;
                this.RaisePropertyChanged("Add1");
            }
        }
        private double add2;//数据属性
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
                this.RaisePropertyChanged("Sum");//括号里面的参数要和类名一样
            }
        }
        #endregion

        #region 命令属性
        public DelegateCommand AddCommand { get; set; }
        private void Add(object obj)
        {
            this.sum = this.Add1 + this.Add2;
            this.Add1++;
        }
        public MainWindowViewModel()
            {
            this.AddCommand = new DelegateCommand();
            this.AddCommand.ExecuteAction = new Action<object>(this.Add);//关联
            }
        #endregion
    }
}
