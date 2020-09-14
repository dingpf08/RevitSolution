using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
//画一个心形的柱子阵列
namespace Revit_CreatFamilyInstance.增_删_改_查
{
    [Transaction(TransactionMode.Manual)]//对类有作用，放在类的前面
    class CreateColumnForFun : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            //获取CW 102-50-100p类型的墙体
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            Element ele = collector.OfCategory(BuiltInCategory.OST_Columns).OfClass(typeof(FamilySymbol))
                .FirstOrDefault(x=>x.Name== "457 x 475mm");
            FamilySymbol columnType = ele as FamilySymbol;

            columnType.Activate();

            //获取标高
            //通过链式编程，一句话搞定
            Level level = new FilteredElementCollector(doc).
                OfClass(typeof(Level)).FirstOrDefault(x => x.Name == "标高 1") as Level;
            //创建放置点
            int countcircle = 72;
            List<XYZ> xyzlist = new List<XYZ>();
            for (int i = 0; i < countcircle; i++)
            {
                double x = 10 * (2 * Math.Cos(2 * Math.PI / countcircle * i) - Math.Cos(2 * 2 * Math.PI / countcircle * i));
                double y= 10 * (2 * Math.Sin(2 * Math.PI / countcircle * i) - Math.Sin(2 * 2 * Math.PI / countcircle * i));
                XYZ start = new XYZ(x, y, 0);
                xyzlist.Add(start);
            }

            double height = 15 / 0.3048;
            double offset = 0;
            //创建事务
            List<FamilyInstance> familyInstance = new List<FamilyInstance>();
            Transaction trans = new Transaction(doc,"创建柱子");

            foreach (XYZ item in xyzlist)
            {
                trans.Start();
                FamilyInstance colum = doc.Create.NewFamilyInstance(item, columnType, level, StructuralType.NonStructural);
                trans.Commit();
                //刷新界面，出现动画效果
                System.Windows.Forms.Application.DoEvents();//动画步骤一
                //使用线程来控制实践
                Thread.Sleep(100);//动画步骤二
                familyInstance.Add(colum);
            }

                //旋转柱子
                Transaction transRotate = new Transaction(doc, "旋转柱子");
                for(int i=0;i<100;i++)
                {
                    transRotate.Start();
                    for (int j = 0; j < xyzlist.Count; j++)
                    {
                        Line line = Line.CreateBound(xyzlist[j],new XYZ(xyzlist[j].X, xyzlist[j].Y,10));
                        ElementTransformUtils.RotateElement(doc,familyInstance[j].Id,line,Math.PI/6);
                    }
                    transRotate.Commit();
                    System.Windows.Forms.Application.DoEvents();
                }



            return Result.Succeeded;

        } 


    }
}
