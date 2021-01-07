using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormulaOneDLL;

namespace FormulaOneWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        public const string WORKINGPATH = @"C:\data\FormulaOne\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + "FormulaOne.mdf;Integrated Security=True;Connect Timeout=30";
        private string database;
        public  Tools dbTools = new Tools(CONNECTION_STRING);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //FARE SHOWTABLE--> CARICARE I DATI RICEVUTI SU UNA COMBOBOX
                //dbTools.ShowTable() = mi permette di avere tutte le tabelle del mio database FormulaOne.mdf
                DropDownList.DataSource = dbTools.ShowTable();
                DropDownList.DataBind();
            }
        }

        protected void cmbDatabase_changed(object sender, EventArgs e)
        {
            database = DropDownList.Text;
            gridViewData.DataSource = dbTools.GetDataTable(DropDownList.Text);
            gridViewData.DataBind();
        }
    }
}