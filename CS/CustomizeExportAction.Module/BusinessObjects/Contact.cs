using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace CustomizeExportAction.Module.BusinessObjects {
   [DefaultClassOptions]
   public class Contact : BaseObject {
      public Contact(Session session)
         : base(session) {
         // This constructor is used when an object is loaded from a persistent storage.
         // Do not place any code here or place it only when the IsLoading property is false:
         // if (!IsLoading){
         //    It is now OK to place your initialization code here.
         // }
         // or as an alternative, move your initialization code into the AfterConstruction method.
      }
      public override void AfterConstruction() {
         base.AfterConstruction();
         // Place here your initialization code.
      }
      private string lastName;
      public string LastName {
         get {
            return lastName;
         }
         set {
            SetPropertyValue("LastName", ref lastName, value);
         }
      }
      private string firstName;
      public string FirstName {
         get {
            return firstName;
         }
         set {
            SetPropertyValue("FirstName", ref firstName, value);
         }
      }
      private string department;
      public string Department {
         get {
            return department;
         }
         set {
            SetPropertyValue("Department", ref department, value);
         }
      }
   }

}
