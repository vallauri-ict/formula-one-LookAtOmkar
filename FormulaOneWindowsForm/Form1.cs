using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaOneDLL;
using System.Windows.Forms;

namespace FormulaOneWindowsForm
{
    public partial class Form1 : Form
    {
        public const string WORKINGPATH = @"C:\data\FormulaOne\";  /// Creare una cartella su C:\data--> FormulaOne--> countries.sql
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security =True";
        public Tools tool = new Tools(CONNECTION_STRING); 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTable.DataSource = tool.GetTables();
            dgvTable.AutoResizeColumns();
            //Pic.Visible = false;
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = cmbTable.Text;
            dgvTable.ClearSelection();
            dgvTable.AutoResizeColumns();
            dgvTable.DataSource = tool.GetDataTable(table);
        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            MessageBox.Show("--->"+dgvTable.CurrentCell.Value.ToString());
            if(cmbTable.Text.ToUpper()=="CIRCUIT")
            {
                Pic.Visible = true;
                if (dgvTable.CurrentCell.ColumnIndex.Equals(8))
                {
                    Pic.Load(dgvTable.CurrentCell.Value.ToString());
                }
            }
            */
        }
    }
}
