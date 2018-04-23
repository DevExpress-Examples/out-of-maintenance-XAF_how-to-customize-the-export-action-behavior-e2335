using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.SystemModule;

using DevExpress.XtraPrinting;

namespace CustomizeExportAction.Module.Controllers {
   public partial class CustomizeExportController : ViewController {
      public CustomizeExportController() {
         InitializeComponent();
         RegisterActions(components);
         TargetViewType = ViewType.ListView;
      }
      private ExportController exportController;
      protected override void OnActivated() {
         base.OnActivated();
         exportController = Frame.GetController<ExportController>();
         exportController.CustomGetDefaultFileName += exportController_CustomGetDefaultFileName;
         exportController.CustomExport += new EventHandler<CustomExportEventArgs>(CustomExport);
    }

      protected virtual void CustomExport(object sender, CustomExportEventArgs e) {
         //Customize Export Options
         if (e.ExportTarget == ExportTarget.Xls) {
            XlsExportOptions options = (XlsExportOptions)e.ExportOptions;
            if (options == null) {
               options = new XlsExportOptions();
            }
            options.SheetName = View.Caption;
            options.ShowGridLines = true;
            e.ExportOptions = options;
         }
      }
      void exportController_CustomGetDefaultFileName(object sender, CustomGetDefaultFileNameEventArgs e) {
#if EASYTEST
			 //Provide a custom file name
         e.FileName = e.FileName + "_06.25.12";
#else
          //Provide a custom file name
         e.FileName = e.FileName + "_" + DateTime.Now.ToString("MM.dd.yy");
#endif
      }
      protected override void OnDeactivated() {
         exportController.CustomGetDefaultFileName -= exportController_CustomGetDefaultFileName;
         exportController.CustomExport -= new EventHandler<CustomExportEventArgs>(CustomExport);
         base.OnDeactivated();
      }
   }
}
