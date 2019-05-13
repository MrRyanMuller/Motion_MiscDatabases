using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_ControlNumberLog
{
    public partial class InsertData : Form
    {
        public InsertData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (dataGridView1.RowCount > 0)
                    dataGridView1.Rows.Clear();

                bool columnsAdded = true;
                List<string> pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n").ToList();

                for (int i = 0; i < pastedRows.Count; i++)
                {
                    int test = pastedRows[i].Split('\t').Length - 1;
                    while (test < (dataGridView1.ColumnCount - 1))
                    {
                        string temp = pastedRows[i];
                        pastedRows[i] = pastedRows[i] + pastedRows[i + 1];
                        temp = pastedRows[i];
                        pastedRows.RemoveAt(i + 1);
                        test = pastedRows[i].Split('\t').Length - 1;
                    }
                }



                int j = 0;
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });

                    if (!columnsAdded)
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dataGridView1.Columns.Add("col" + i, pastedRowCells[i]);

                        columnsAdded = true;
                        continue;
                    }

                    dataGridView1.Rows.Add();
                    int myRowIndex = dataGridView1.Rows.Count - 1;


                    using (DataGridViewRow dataGridView1Row = dataGridView1.Rows[j])
                    {
                        for (int i = 0; i < pastedRowCells.Length; i++)
                            dataGridView1Row.Cells[i].Value = pastedRowCells[i];
                    }
                    j++;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                int A = Convert.ToInt32(row.Cells[0].Value.ToString());
                string B = row.Cells[1].Value.ToString();
                string C = row.Cells[2].Value.ToString();
                string D = row.Cells[3].Value.ToString();
                string E = row.Cells[4].Value.ToString();
                string F = row.Cells[5].Value.ToString();
                string G = row.Cells[6].Value.ToString();

                controlNumberLogTableAdapter.Insert(A, B, C, D, E, F, G);
            }


            MessageBox.Show("Done!");
            dataGridView1.Rows.Clear();
        }

        private void InsertData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'motionDataDataSet1.ControlNumberLog' table. You can move, or remove it, as needed.
            this.controlNumberLogTableAdapter.Fill(this.motionDataDataSet1.ControlNumberLog);

        }
    }
}
