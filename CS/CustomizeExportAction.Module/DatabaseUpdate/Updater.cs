using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;

using CustomizeExportAction.Module.BusinessObjects;

namespace CustomizeExportAction.Module.DatabaseUpdate {
   public class Updater : ModuleUpdater {
      public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) {
      }
      public override void UpdateDatabaseAfterUpdateSchema() {
         base.UpdateDatabaseAfterUpdateSchema();
         if (ObjectSpace.FindObject<Contact>(CriteriaOperator.Parse(
    "FirstName == 'Mary' && LastName == 'Tellitson'")) == null) {
            Contact contact1 = ObjectSpace.CreateObject<Contact>();
            contact1.FirstName = "Mary";
            contact1.LastName = "Tellitson";
            contact1.Department = "Sales Department";
            contact1.Save();
         }
         if (ObjectSpace.FindObject<Contact>(CriteriaOperator.Parse(
             "FirstName == 'John' && LastName == 'Nielsen'")) == null) {
            Contact contact2 = ObjectSpace.CreateObject<Contact>();
            contact2.FirstName = "John";
            contact2.LastName = "Nielsen";
            contact2.Department = "Development Department";
            contact2.Save();
         }
         if (ObjectSpace.FindObject<Contact>(CriteriaOperator.Parse(
             "FirstName == 'Robert' && LastName == 'King'")) == null) {
            Contact contact3 = ObjectSpace.CreateObject<Contact>();
            contact3.FirstName = "Robert";
            contact3.LastName = "King";
            contact3.Department = "Development Department";
            contact3.Save();
         }
      }
   }
}
