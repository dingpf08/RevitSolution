using Autodesk.Revit.UI;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Revit_RibbonUI
{
    class Revit_Application : IExternalApplication
    {
        Result IExternalApplication.OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        //启动时候执行操作
        Result IExternalApplication.OnStartup(UIControlledApplication application)
        {
            //创建一个RibbonTab
            application.CreateRibbonTab("Dingpf08_RevitUITab");//创建tab
            //在Dingpf08_RevitUITab 中创建UIPanel
            RibbonPanel rp = application.CreateRibbonPanel("Dingpf08_RevitUITab","DingpfUIPanel_Large");
            //指定程序集的名称以及所使用的类名,
            // string assemblyPath = @"E:\工作单位\中铁建工工作资料\装配式建筑技术研发中心\我的工作\Revit二次开发\Revit二次开发项目\RevitDifFolder\Revit_RibbonUI\bin\Debug\Revit_RibbonUI.dll";//绝对路径
            string assemblyPath =Assembly.GetExecutingAssembly().Location;//相对路径
            //revit路径
            //string revitExeLocation = Process.GetCurrentProcess().MainModule.FileName;//获得revit.exe的位置
           
            string classNameRevit_RibbonUI = "Revit_RibbonUI.Revit_RibbonUI";//命名空间+类名
            //创建按钮pushbutton
            PushButtonData pbd = new PushButtonData("RevitInnerName", "Revit_RibbonUI", assemblyPath, classNameRevit_RibbonUI);
                 //将PushButton添加到面板
            PushButton pushButton = rp.AddItem(pbd) as PushButton;
                 //给按钮设置一个图片（32X ）按钮图片
                 //绝对路径
            //string absoluteImgPath = @"E:\工作单位\中铁建工工作资料\装配式建筑技术研发中心\我的工作\Revit二次开发\Revit二次开发项目\RevitDifFolder\Revit_RibbonUI\pic\angry.png";
            //相对路径
            string RelativeImgPath = "pack://application:,,,/Revit_RibbonUI;component/pic/angry.png"; 
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri(RelativeImgPath, UriKind.Absolute));
            pushButton.LargeImage = imageBrush.ImageSource;
            //给按钮设置tooltips提示信息
            pushButton.ToolTip = "Dingpf08'First (32X32)Revit_RibbonUI";



            //再增加一个按钮,小按钮加不上，原因未知
            RibbonPanel rp1 = application.CreateRibbonPanel("Dingpf08_RevitUITab", "DingpfUIPanel_Small");
            string classNameRevit_SmallRibbonUI = "Revit_SmallRibbonUI.Revit_SmallRibbonUI";//命名空间+类名
            //创建按钮pushbutton
            PushButtonData pbd1 = new PushButtonData("RevitInnerName1", "Revit_SmallRibbonUI", assemblyPath, classNameRevit_SmallRibbonUI);
            //将PushButton添加到面板
            PushButton pushButton1 = rp1.AddItem(pbd1) as PushButton;
        //给按钮设置一个图片（16X）按钮图片
            //string imgPath1 = @"E:\工作单位\中铁建工工作资料\装配式建筑技术研发中心\我的工作\Revit二次开发\Revit二次开发项目\RevitDifFolder\Revit_RibbonUI\pic\bug.png";
            string RelativeImgPath1 = "pack://application:,,,/Revit_RibbonUI;component/pic/bug.png";
            ImageBrush imageBrush1 = new ImageBrush();
            imageBrush1.ImageSource = new BitmapImage(new Uri(RelativeImgPath1, UriKind.Absolute));
            pushButton1.Image = imageBrush1.ImageSource;
            //给按钮设置tooltips提示信息
            pushButton1.ToolTip = "Dingpf08'Second (16x16)Revit_RibbonUI";



            return Result.Succeeded;
        }
    }
}
