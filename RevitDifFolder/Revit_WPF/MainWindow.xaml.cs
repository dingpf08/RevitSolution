using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
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
//wpf窗体应用程序,外部事件主流程
namespace Revit_WPF
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// partial 代表是好几个窗口合并在一起形成的窗口类
    public partial class MainWindow : Window
    {
        public bool IsClicked { get; set; } = false;
        public static bool IsFirstClick { get; set; } = false;
        //注册外部命令
        CreatExternalWall createExeWallCommand = null;
        ExternalEvent createWallEvent = null;
        public MainWindow()
        {
        InitializeComponent();
            //初始化
            createExeWallCommand = new CreatExternalWall();
            createWallEvent = ExternalEvent.Create(createExeWallCommand);
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //执行命令：CreatExternalWall
            //创建属性
            if (IsFirstClick==false)
            {
                createExeWallCommand.m_Dradius = Convert.ToDouble(this.m_R.Text);//控件值给命令
                createExeWallCommand.m_Dradius += 20;
                IsFirstClick = true;
            }
            else
            {
                createExeWallCommand.m_Dradius += 20;
           
            
            }
            this.m_R.Text = Convert.ToString(createExeWallCommand.m_Dradius);
            createWallEvent.Raise();
        }

    }
}
