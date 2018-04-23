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
using System.IO;
using DevExpress.ExpressApp.Win;
using System.Windows.Forms;

namespace CustomizeExportAction.Module.Win {
    public partial class CustomizeXtraGridExportController : ViewController {
        public CustomizeXtraGridExportController() {
            InitializeComponent();
            RegisterActions(components);
        }
        private XtraGridExportController exportController;
        protected override void OnActivated() {
            base.OnActivated();
            exportController = Frame.GetController<XtraGridExportController>();
            exportController.CustomExport += exportController_CustomExport;
            exportController.Exported += exportController_Exported;
        }
        void exportController_Exported(object sender, CustomExportEventArgs e) {
            if (File.Exists(e.FileName)) {
                e.Stream.Close();
                if (WinApplication.Messaging.GetUserChoice("Open the exported file?",
                    "Export", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Process.Start(e.FileName);
            }
        }
        void exportController_CustomExport(object sender, CustomExportEventArgs e) {
            GridListEditor gridListEditor =
                ((DevExpress.ExpressApp.ListView)View).Editor as GridListEditor;
            XafGridView gridView = gridListEditor.GridView;
            if (HasCollapsedGroups(gridView)) {
                if (WinApplication.Messaging.GetUserChoice(
                    "There are collapsed groups in the grid. Expand all groups in the exported file?",
                    "Export", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    gridView.OptionsPrint.ExpandAllGroups = true;
                else gridView.OptionsPrint.ExpandAllGroups = false;
            }
        }
        private bool HasCollapsedGroups(XafGridView gridView) {
            if (gridView.GroupCount > 0) {
                int rowHandle = -1;
                while (gridView.IsValidRowHandle(rowHandle)) {
                    if (!gridView.GetRowExpanded(rowHandle)) return true;
                    rowHandle--;
                }
            }
            return false;
        }
        protected override void OnDeactivating() {
            base.OnDeactivating();
            exportController.CustomExport -= exportController_CustomExport;
            exportController.Exported -= exportController_Exported;
        }
    }
}
