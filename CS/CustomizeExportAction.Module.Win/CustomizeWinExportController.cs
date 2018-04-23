using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Win;
using System.Windows.Forms;
using DevExpress.XtraPrinting;

namespace CustomizeExportAction.Module.Win {
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
        exportController.Exporting += exportController_Exporting;
        exportController.CustomExport += exportController_CustomExport;
        exportController.Exported += exportController_Exported;
    }

    void exportController_CustomExport(object sender, CustomExportEventArgs e) {
        if (e.ExportType == PrintingSystemCommand.ExportXls) {
            GridListEditor gridListEditor = ((DevExpress.ExpressApp.ListView)View).Editor as GridListEditor;
            IPrintable printable = ((IExportableEditor)gridListEditor).Printable;
            XlsExportOptions options = new XlsExportOptions();
            options.SheetName = gridListEditor.Name;
            options.ShowGridLines = true;
            ComponentExporter exporter = new ComponentExporter(printable);
            exporter.Export(ExportTarget.Xls, e.Stream, options);
            e.Handled = true;
        }
    }
    void exportController_Exporting(object sender, CustomExportEventArgs e) {
        GridListEditor gridListEditor =
            ((DevExpress.ExpressApp.ListView)View).Editor as GridListEditor;
        if (gridListEditor != null) {
            XafGridView gridView = gridListEditor.GridView;
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
        exportController.Exporting -= exportController_Exporting;
        exportController.CustomExport -= exportController_CustomExport;
        exportController.Exported -= exportController_Exported;
        base.OnDeactivated();
    }
}
}
