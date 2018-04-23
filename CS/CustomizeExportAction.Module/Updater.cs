using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace CustomizeExportAction.Module {
    public class Updater : ModuleUpdater {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            if (Session.FindObject<Contact>(CriteriaOperator.Parse(
                "FirstName == 'Mary' && LastName == 'Tellitson'")) == null) {
                Contact contact1 = new Contact(Session);
                contact1.FirstName = "Mary";
                contact1.LastName = "Tellitson";
                contact1.Department = "Sales Department";
                contact1.Save();
            }
            if (Session.FindObject<Contact>(CriteriaOperator.Parse(
                "FirstName == 'John' && LastName == 'Nielsen'")) == null) {
                Contact contact2 = new Contact(Session);
                contact2.FirstName = "John";
                contact2.LastName = "Nielsen";
                contact2.Department = "Development Department";
                contact2.Save();
            }
            if (Session.FindObject<Contact>(CriteriaOperator.Parse(
                "FirstName == 'Robert' && LastName == 'King'")) == null) {
                Contact contact3 = new Contact(Session);
                contact3.FirstName = "Robert";
                contact3.LastName = "King";
                contact3.Department = "Development Department";
                contact3.Save();
            }
        }
    }
}

