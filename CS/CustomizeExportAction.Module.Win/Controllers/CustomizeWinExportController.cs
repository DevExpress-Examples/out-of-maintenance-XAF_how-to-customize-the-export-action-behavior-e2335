using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Win;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using System.IO;

namespace CustomizeExportAction.Module.Win.Controllers {
   public partial class CustomizeWinExportController : ViewController {
      public CustomizeWinExportController() {
         InitializeComponent();
         RegisterActions(components);
         this.TargetViewType = ViewType.ListView;
      }
      private WinExportController exportController;
      protected override void OnActivated() {
         base.OnActivated();
         exportController = Frame.GetController<WinExportController>();
         exportController.CustomExport += exportController_CustomExport;
         exportController.Exported += exportController_Exported;
      }

      void exportController_CustomExport(object sender, CustomExportEventArgs e) {

         //Show message before exporting a Grid List Editor

         GridListEditor gridListEditor = ((DevExpress.ExpressApp.ListView)View).Editor as GridListEditor;
         if (gridListEditor != null) {
            XafGridView gridView = gridListEditor.GridView;
            if (HasCollapsedGroups(gridView)) {
               string message =
                   "There are collapsed groups in the grid. Do you need to expand all groups in the exported file?";
               gridView.OptionsPrint.ExpandAllGroups =
                   WinApplication.Messaging.GetUserChoice(message, GetMessageBoxCaption(),
                   MessageBoxButtons.YesNo)
                   == DialogResult.Yes;
            }
         }
         //Customize Export Options
         if (e.ExportTarget == ExportTarget.Xls) {
            IPrintable printable = exportController.Exportable.Printable;
            XlsExportOptions options = (XlsExportOptions)e.ExportOptions;
            if (options == null) {
               options = new XlsExportOptions();
            }
            options.SheetName = View.Caption;
            options.ShowGridLines = true;
            e.ExportOptions = options;
         }
      }

      private bool HasCollapsedGroups(XafGridView gridView) {
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
             "{0} {1}", exportController.ExportAction.Caption,
                 exportController.ExportAction.SelectedItem);
      }
      void exportController_Exported(object sender, CustomExportEventArgs e) {
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
      protected override void OnDeactivated() {
         exportController.CustomExport -= exportController_CustomExport;
         exportController.Exported -= exportController_Exported;
         base.OnDeactivated();
      }
   }

}
