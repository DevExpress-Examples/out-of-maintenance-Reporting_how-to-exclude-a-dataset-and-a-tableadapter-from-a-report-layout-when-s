using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraReports.UI;

namespace SaveComponents {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

    private void Form1_Load(object sender, EventArgs e) {
        XtraReport1 report = new XtraReport1();
        report.SaveComponents += new 
            EventHandler<SaveComponentsEventArgs>(report_SaveComponents);
        report.ShowDesignerDialog();
    }

    void report_SaveComponents(object sender, SaveComponentsEventArgs e) {
        int tableAdapterIdx = GetItemIndex(e.Components, typeof(Component));
        if (tableAdapterIdx >= 0)
            e.Components.RemoveAt(tableAdapterIdx);
        int dsIdx = GetItemIndex(e.Components, typeof(DataSet));
        if (dsIdx >= 0)
            e.Components.RemoveAt(dsIdx);
    }

    private static int GetItemIndex(IList components, Type targetType) {
        int idx = -1;
        for (int i = 0; i < components.Count; i++) {
            if (components[i].GetType().BaseType == targetType) {
                idx = i;
                break;
            } 
        }

        return idx;
    }
    }
}