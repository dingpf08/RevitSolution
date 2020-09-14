using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

//过滤某种类型的构件，获取某一个特性实例
namespace Revit_FilterModelFilter
{

    #region  //快速过滤
    #endregion  //快速过滤

    #region//快速过滤具体某一种
    [Transaction(TransactionMode.Manual)]//对类有作用，放在类的前面
    public class FilterSpecificComponent : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            _ = TaskDialog.Show("快速过滤", "过滤具体某一种");
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            var sel = uidoc.Selection.GetElementIds();
            //创造收集器
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            _ = collector.OfCategory(BuiltInCategory.OST_Entourage).OfClass(typeof(FamilyInstance));
            //collector.OfCategory(BuiltInCategory.OST_Entourage).OfClass(typeof(Family));
            //获取类型下族实例
            List<Element> elementlist = new List<Element>();
            int count = 0;
            foreach (var item in collector)
            {
                if(item.Name== "M_RPC Beetle")
                {
                    elementlist.Add(item);
                    count++;
                }
                if (item is Wall)
                {
                    Wall wallInstance = item as Wall;
                    if (wallInstance!=null)//转换成功
                    {
                        TaskDialog.Show("嘿嘿嘿","Wall 转换成功");
                    }
                }
                else if (item is WallType)
                {
                    WallType walltypeinstance = item as WallType;
                    if (walltypeinstance!=null)
                    {
                        TaskDialog.Show("哈哈哈", "WallType 转换成功");
                    }
                }
            }
            //有多个实例，获取其中一个，使用ElementId
            Element ele = doc.GetElement(new ElementId(243274));//这是一个屋顶
            if (ele!=null)
            {
                TaskDialog.Show("选择到了已有的屋顶", ele.Name);
                sel.Add(ele.Id);
                uidoc.Selection.SetElementIds(sel);
            }


            ele = doc.GetElement(new ElementId(-100)); ;
            if (ele==null)
            {
                TaskDialog.Show("呵呵", "选个p啊，为空的");

            }
            else
            {
                TaskDialog.Show("选择到了未知的东西", ele.Name);
            }
            
            string mes = "一共有";
            mes += count.ToString();
            mes += "个 M_RPC Beetle";
            _ = TaskDialog.Show("过滤 M_RPC Beetle", mes);

            
            foreach (var item in elementlist)
            {
                sel.Add(item.Id);
            }
            uidoc.Selection.SetElementIds(sel);
            return Result.Succeeded;
        }
    }

    #endregion
}
