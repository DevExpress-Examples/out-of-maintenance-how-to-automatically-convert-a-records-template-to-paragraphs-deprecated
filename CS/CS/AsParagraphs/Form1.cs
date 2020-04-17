// Developer Express Code Central Example:
// How to automatically convert a record's template to paragraphs when a field is inserted into a report
// 
// This example demonstrates how the default record template (Table) can be
// converted to paragraphs automatically when a field is dragged and dropped from
// the Data Explorer.
// In this example, this functionality is implemented in the
// SnapDocument.PrepareSnList
// (http://documentation.devexpress.com/#WindowsForms/DevExpressSnapCoreAPISnapDocument_PrepareSnListtopic)
// event handler.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4903

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Snap.Core.API;

namespace AsParagraphs {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            AddDataSource();
            SubscribeEvents();
        }

        List<DataFieldInfo> dataFields;

        private void snapControl1_DocumentLoaded(object sender, EventArgs e) {
            SubscribeEvents();
        }

        void SubscribeEvents() {
            snapControl1.Document.BeforeInsertSnList += Document_BeforeInsertSnList;
            snapControl1.Document.PrepareSnList += Document_PrepareSnList;
        }

        void AddDataSource() {
            snapControl1.Document.DataSource = new List<SampleTestObject>() {                 
                new SampleTestObject() { ID = 1, Name = "Apple", Color = "Green" },
                new SampleTestObject() { ID = 2, Name = "Banana", Color = "Yellow" },
                new SampleTestObject() { ID = 3, Name = "Strawberry", Color = "Red" }
            };
        }

        void Document_BeforeInsertSnList(object sender, BeforeInsertSnListEventArgs e) {
            this.dataFields = e.DataFields;
        }

        void Document_PrepareSnList(object sender, PrepareSnListEventArgs e) {
            foreach(var field in e.Template.Fields) {
                SnapList list = e.Template.ParseField(field) as SnapList;
                if(object.ReferenceEquals(list, null))
                    continue;
                list.BeginUpdate();
                list.ListHeader.Delete(list.ListHeader.Range);
                SnapDocument template = list.RowTemplate;
                template.Delete(template.Range);
                foreach(DataFieldInfo dataField in this.dataFields) {
                    template.AppendText(string.Format("{0} = ", dataField.DisplayName));
                    template.CreateSnText(template.Range.End, dataField.DataPaths[dataField.DataPaths.Length - 1]);
                    template.Paragraphs.Append();
                }
                template.Paragraphs.Append();
                list.EndUpdate();
                break;
            }
            this.dataFields = null;
        }
    }

    public class SampleTestObject {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color  { get; set; }

    
    }
}
