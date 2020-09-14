
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
//程序架构
namespace RevitSayHelloToWorld
{
    /*由于Revit API对于Revit事务没有默认值，用户必须显式地指定标签值。
      用户在实现IExternalCommand接口时必须指定执行命令所使用的TransactionMode属性*/
    [Transaction(TransactionMode.Manual)]
    public class Revit_SayHelloToWorld : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            TaskDialog.Show("丁鹏飞", "你好呀，Revit！");
            return Result.Succeeded;
            //throw new NotImplementedException();
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class DingPf_Revit_SayHelloToWorld : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            //提示对话框，提示信息
            TaskDialog.Show("DingPf_丁鹏飞", "你好呀，DingPf_Revit！");
            return Result.Succeeded;
            //throw new NotImplementedException();
        }
    }


}
