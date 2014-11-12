#region

using System;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace PacketAnalyzer
{
    public partial class PAForm : Form
    {
        public PAForm()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //PGridSend.Columns.Clear();
        }

        private void DeleteAll(byte header)
        {
            foreach (var row in
                PGridSend.Rows.Cast<DataGridViewRow>()
                    .Where(row => StringToByteArray(row.Cells[1].ToString())[0] == header))
            {
                row.Selected = true;
                DeleteRow_Click(new object(), new EventArgs());
            }
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            var rowToDelete = PGridSend.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            PGridSend.Rows.RemoveAt(rowToDelete);
            PGridSend.ClearSelection();
        }

        public static byte[] StringToByteArray(string hex)
        {
            return
                Enumerable.Range(0, hex.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                    .ToArray();
        }

        private void PGridSend_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var hti = PGridSend.HitTest(e.X, e.Y);
                PGridSend.ClearSelection();
                PGridSend.Rows[hti.RowIndex].Selected = true;
                textBox1.Text = Program.SendPackets[hti.RowIndex].Dump();

            }
        }

        private void PGridRecv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var hti = PGridRecv.HitTest(e.X, e.Y);
                PGridRecv.ClearSelection();
                PGridRecv.Rows[hti.RowIndex].Selected = true;
                textBox1.Text = Program.RecvPackets[hti.RowIndex].Dump();
            }
        }
    }
}