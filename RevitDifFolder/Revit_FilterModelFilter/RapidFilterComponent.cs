using System.Collections.Generic;


using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

//快速过滤一般流程
namespace Revit_FilterModelFilter
{
    #region  //快速过滤
    [Transaction(TransactionMode.Manual)]//对类有作用，放在类的前面
    public class RapidFilterComponent : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            _ = TaskDialog.Show("快速过滤", "快速过滤");
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            //创造收集器
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            //快速过滤方法
            //BuiltInCategory:Revit中所有内置类别的列表
            _ = collector.OfCategory(BuiltInCategory.OST_Entourage).OfClass(typeof(FamilyInstance));
            
            //高亮显示实例
            ICollection<ElementId> sel = uidoc.Selection.GetElementIds();
            /*1. 必须在定义时初始化。也就是必须是var s = “abcd”形式，而不能是如下形式: var s; s = “abcd”;
              2. 一但初始化完成，就不能再给变量赋与初始化值类型不同的值了。
              3. var要求是局部变量。
              4. 使用var定义变量和object不同，它在效率上和使用强类型方式定义变量完全一样。*/
            //var sel = uidoc.Selection.GetElementIds();//匿名函数
            int count = 0;
            foreach(var item in collector)
            {
                sel.Add(item.Id);
                count++;
            }
            uidoc.Selection.SetElementIds(sel);
            string mes = "一共有";
            mes += count.ToString();
            mes += "个 BuiltInCategory.OST_Entourage";
            _ = TaskDialog.Show("过滤OST_Entourage", mes);
            return Result.Succeeded;
        }
    }

    #endregion
}
