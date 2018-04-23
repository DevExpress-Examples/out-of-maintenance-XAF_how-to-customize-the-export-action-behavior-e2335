using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.Web.SystemModule;
//add a reference to the DevExpress.Web.Export assembly
using DevExpress.Web;
using CustomizeExportAction.Module.Controllers;

namespace CustomizeExportAction.Module.Web.Controllers {
   public partial class CustomizeExportControllerWeb : CustomizeExportController {

      protected override void CustomExport(object sender, DevExpress.ExpressApp.SystemModule.CustomExportEventArgs e) {
         base.CustomExport(sender, e);
         //Export only selected rows
         ASPxGridViewExporter exporter = e.Printable as ASPxGridViewExporter;
         if (exporter != null) {
            exporter.ExportedRowType = GridViewExportedRowType.Selected;
         }
      }
   }
}
