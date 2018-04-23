using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Win;
using System.Windows.Forms;

using System.IO;
using CustomizeExportAction.Module.Controllers;
using DevExpress.XtraGrid.Views.Grid;

namespace CustomizeExportAction.Module.Win.Controllers {
   public partial class CustomizeExportControllerWin : CustomizeExportController {
      private WinExportController winExportController;
      protected override void OnActivated() {
         base.OnActivated();
         winExportController = Frame.GetController<WinExportController>();
         winExportController.Exported += new EventHandler<DevExpress.ExpressApp.SystemModule.CustomExportEventArgs>(winExportController_Exported);
      }

      void winExportController_Exported(object sender, DevExpress.ExpressApp.SystemModule.CustomExportEventArgs e) {
         if (e.Stream is FileStream) {
            string fileName = ((FileStream)e.Stream).Name;
            if (File.Exists(fileName)) {
               e.Stream.Close();
               if (WinApplication.Messaging.GetUserChoice("Open the exported file?",
                   GetMessageBoxCaption(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                  Process.Start(fileName);
            }
         }
      }
      protected override void CustomExport(object sender, DevExpress.ExpressApp.SystemModule.CustomExportEventArgs e) {
         base.CustomExport(sender, e);
         //Show a message before exporting a Grid List Editor
         GridListEditor gridListEditor =
             ((DevExpress.ExpressApp.ListView)View).Editor as GridListEditor;
         if (gridListEditor != null) {
            GridView gridView = gridListEditor.GridView;
            if (HasCollapsedGroups(gridView)) {
               string message =
                  "There are collapsed groups in the grid. Expand all groups in the exported file?";
               gridView.OptionsPrint.ExpandAllGroups =
                  WinApplication.Messaging.GetUserChoice(message, GetMessageBoxCaption(),
                  MessageBoxButtons.YesNo)
                  == DialogResult.Yes;
            }
         }
      }
      private bool HasCollapsedGroups(GridView gridView) {
         if (gridView.GroupCount > 0) {
            int rowHandle = -1;
            while (gridView.IsValidRowHandle(rowHandle)) {
               if (!gridView.GetRowExpanded(rowHandle))
                  return true;
               rowHandle--;
            }
         }
         return false;
      }
      private string GetMessageBoxCaption() {
         return String.Format(
             "{0} {1}", winExportController.ExportAction.Caption,
                 winExportController.ExportAction.SelectedItem);
      }
      protected override void OnDeactivated() {
         winExportController.Exported -= new EventHandler<DevExpress.ExpressApp.SystemModule.CustomExportEventArgs>(winExportController_Exported);
         base.OnDeactivated();
      }
   }
}
