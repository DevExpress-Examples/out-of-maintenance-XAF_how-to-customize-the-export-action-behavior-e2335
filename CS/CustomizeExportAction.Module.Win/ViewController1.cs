using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace CustomizeExportAction.Module.Win {
    public partial class ViewController1 : ViewController {
        public ViewController1() {
            InitializeComponent();
            RegisterActions(components);
        }
    }
}
