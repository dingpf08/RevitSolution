using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Revit_SmallRibbonUI
{
    [Transaction(TransactionMode.Manual)]
    public class Revit_SmallRibbonUI : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            //提示对话框，提示信息
            TaskDialog.Show("UITest", "Hello UI，SmallRibbon_UI");
            return Result.Succeeded;
        }
    }
}
