using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//命令属性
namespace WPF_DataBinding.Commands
{
    class DelegateCommand:ICommand//委托命令
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)//命令是否可以执行
        {
            if (this.CanExecuteFunc==null)
            {
                return true;
            }
            return this.CanExecuteFunc(parameter);
        }

        public void Execute(object parameter)//执行命令后想做啥事情
        {
            if (this.ExecuteAction==null)
            {
                return;
            }
            this.ExecuteAction(parameter);
        }
        public Action<object> ExecuteAction { get; set; }//没有返回值
        public Func<object,bool> CanExecuteFunc{get;set;}//最后一个参数为返回值

    }
}
