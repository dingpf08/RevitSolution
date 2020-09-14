using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_conversion;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
//修改墙体属性
namespace Revit_CreatFamilyInstance.增_删_改_查
{
    [Transaction(TransactionMode.Manual)]//对类有作用，放在类的前面
    class ModifiyParameters : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //获取当前文档
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            //获取CW 102-50-100p类型的墙体
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            Wall wall = collector.OfCategory(BuiltInCategory.OST_Walls).OfClass(typeof(Wall)).FirstOrDefault(e => e.Name == "CW 102-50-100p") as Wall;


            //创建墙
            double wallModifyHeight = 69.7 / 0.3048;
            Transaction trans = new Transaction(doc, "修改墙体高度");
            trans.Start();
            //直线墙
            //1 英尺=0.3048 米,这里输入的是英尺数，Revit显示的是米
            wall.LookupParameter("无连接高度").Set(wallModifyHeight);//如果创建错了，会返回错误的东西，好像就是事务没有提交一样
            trans.Commit();

            double modifynum = wall.LookupParameter("无连接高度").AsDouble()*0.3048;
            string notestr = wall.LookupParameter("备注").AsString() ;
            TaskDialog.Show("修改墙体",$"墙体修改后的高度为{modifynum}米\n墙体的备注为:{notestr}");
            return Result.Succeeded;
        }
    }
}
