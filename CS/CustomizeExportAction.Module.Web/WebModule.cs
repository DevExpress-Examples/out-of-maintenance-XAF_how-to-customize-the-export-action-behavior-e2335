using System;
using System.ComponentModel;

using DevExpress.ExpressApp;

namespace CustomizeExportAction.Module.Web {
   [ToolboxItemFilter("Xaf.Platform.Web")]
   public sealed partial class CustomizeExportActionAspNetModule : ModuleBase {
      public CustomizeExportActionAspNetModule() {
         InitializeComponent();
      }
   }
}
