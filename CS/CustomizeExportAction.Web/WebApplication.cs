using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;

namespace CustomizeExportAction.Web {
   public partial class CustomizeExportActionAspNetApplication : WebApplication {
      private DevExpress.ExpressApp.SystemModule.SystemModule module1;
      private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
      private CustomizeExportAction.Module.CustomizeExportActionModule module3;
      private CustomizeExportAction.Module.Web.CustomizeExportActionAspNetModule module4;
      private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
      private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule module6;
      private DevExpress.ExpressApp.Validation.ValidationModule module5;

      public CustomizeExportActionAspNetApplication() {
         InitializeComponent();
      }

      private void CustomizeExportActionAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
            e.Updater.Update();
            e.Handled = true;
      }

      private void InitializeComponent() {
         this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
         this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
         this.module3 = new CustomizeExportAction.Module.CustomizeExportActionModule();
         this.module4 = new CustomizeExportAction.Module.Web.CustomizeExportActionAspNetModule();
         this.module5 = new DevExpress.ExpressApp.Validation.ValidationModule();
         this.module6 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
         this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
         ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
         // 
         // module5
         // 
         this.module5.AllowValidationDetailsAccess = true;
         // 
         // CustomizeExportActionAspNetApplication
         // 
         this.ApplicationName = "CustomizeExportAction";
         this.Modules.Add(this.module1);
         this.Modules.Add(this.module2);
         this.Modules.Add(this.module6);
         this.Modules.Add(this.securityModule1);
         this.Modules.Add(this.module3);
         this.Modules.Add(this.module4);
         this.Modules.Add(this.module5);
         this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.CustomizeExportActionAspNetApplication_DatabaseVersionMismatch);
         ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

      }
   }
}
