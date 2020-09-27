using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_DataBinding.ViewModels;

namespace WPF_DataBinding
{
   public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();//为View绑定一个ViewModle,这个窗口背后的数据就是MainWindowViewModel这个类
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double a1 = double.Parse(this.Add1.Text);
            double a2 = double.Parse(this.Add2.Text);
            double s = a1+a2;
            this.Sum.Text = s.ToString();
        }

        private void Save_Dlg(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
        }

        private void Slider_Click(object sender, RoutedEventArgs e)
        {
            this.ss.Value = this.s1.Value + this.s2.Value;
        }
    }
}
