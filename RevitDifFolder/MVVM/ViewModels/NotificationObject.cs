using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
//数据属性
//dabanding通知View viewmodel的数值变化了，把数值传输到view上去
namespace MVVM.ViewModels
{
    class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string proertyName)
        {
            if (this.PropertyChanged!=null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(proertyName));//哪个属性的值发生了改变
            }
        }
    }
}
