using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace CustomizeExportAction.Module.BusinessObjects {
   [DefaultClassOptions, ImageName("BO_Contact")]
   public class Contact : BaseObject {
      public Contact(Session session) : base(session) {
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
