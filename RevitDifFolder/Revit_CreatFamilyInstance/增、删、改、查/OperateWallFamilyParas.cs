using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
//查、获取墙体的属性，获取族参数
namespace Revit_CreatFamilyInstance
{
    [Transaction(TransactionMode.Manual)]//对类有作用，放在类的前面
    class OperateWallFamilyParas : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //获取当前文档
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            //获取CW 102-50-100p类型的墙体
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            Wall wall = collector.OfCategory(BuiltInCategory.OST_Walls).OfClass(typeof(Wall)).FirstOrDefault(e => e.Name == "CW 102-50-100p") as Wall;
            //获取墙的属性
            //获取墙体高度，不同类型的参数
            double height = 0;
            height = wall.LookupParameter("无连接高度").AsDouble()*0.3048;
            double vol = wall.LookupParameter("体积").AsDouble()* Math.Pow(0.3048, 3);

            string roombandkey = "房间边界";
            int roomband = wall.LookupParameter("房间边界").AsInteger();
            string notestr = wall.LookupParameter("备注").AsString();
            //字符串格式化
            TaskDialog.Show("墙体高度",$"墙体高度为:{height}\n墙体体积为:{vol}\n房间边界为:{roomband}\n备注为{notestr}");
            
            return Result.Succeeded;
        }

    }
}
