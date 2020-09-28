using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
//外部事件
namespace Revit_WPF
{
    //创建外部命令
    class CreatExternalWall : IExternalEventHandler
    {
        public double m_Dradius { get; set; }
        public void Execute(UIApplication app)
        {

            //获取当前文档
            UIDocument uidoc = app.ActiveUIDocument;
            Document doc = uidoc.Document;
            //获取CW 102-50-100p类型的墙体
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            Element ele = collector.OfCategory(BuiltInCategory.OST_Walls).OfClass(typeof(WallType))
                .FirstOrDefault(e => e.Name == "CW 102-50-100p");
            WallType walltype = ele as WallType;
            //获取标高
            Level level = new FilteredElementCollector(doc).OfClass(typeof(Level)).FirstOrDefault(x => x.Name == "标高 1") as Level;
            //创建线
            XYZ start = new XYZ(0, 0, 0);
            XYZ end = new XYZ(10, 10, 0);
            XYZ ptOnArc = new XYZ(10, 0, 0);
            Line geonline = Line.CreateBound(start, end);


            double startAngle = 0;
            double endAngle = 3.1415926;
            //double radius = Convert.ToDouble(mainWindow.m_radius.Text);//wpf给程序传值，通过自定义属性

            //
            double radius = m_Dradius;//wpf给程序传值，通过自定义属性
            XYZ normal = new XYZ(0, 0, 1);
            XYZ origin = new XYZ(0, 0, 0);
            Plane plane = Plane.CreateByNormalAndOrigin(normal, origin);
            Arc geoArc = Arc.Create(plane, radius, startAngle, endAngle); ;
            //创建墙体的高度和偏移量
            double height = 15 / 0.3048;//英尺换算
            double offset = 0;
            //创建墙
            Transaction trans = new Transaction(doc, "创建墙体");
            trans.Start();
            //直线墙
            // Wall wall = Wall.Create(doc, geonline, walltype.Id,level.Id,height,offset,false,false);//如果创建错了，会返回错误的东西，好像就是事务没有提交一样
            //弧形墙
            Wall arcwall = Wall.Create(doc, geoArc, walltype.Id, level.Id, height, offset, false, false);//如果创建错了，会返回错误的东西，好像就是事务没有提交一样
                                                                                                         //弧形墙
            trans.Commit();
        }

        public string GetName()//返回类名
        {
            return "CreatExternalWall";
        }
    }
}
