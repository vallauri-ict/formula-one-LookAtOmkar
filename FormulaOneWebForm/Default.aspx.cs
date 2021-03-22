using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormulaOneDLL;
using System.Net;
using System.IO;

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
                DropDownList.DataSource = dbTools.GetTables();
                DropDownList.DataBind();
            }
        }

        protected void cmbDatabase_changed(object sender, EventArgs e)
        {
            database = DropDownList.Text;
            gridViewData.DataSource = dbTools.GetDataTable(database);
            gridViewData.DataBind();
        }

        protected void Esegui(object sender,EventArgs e)
        {
            GetCountry();
        }

        private void GetCountry(string isoCode = "")
        {
           HttpWebRequest request = WebRequest.Create("https://localhost:62220/api/Country/"+isoCode+ "") as HttpWebRequest;
           string ApiResponse = "";

            try
            {
                using(HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    ApiResponse = sr.ReadToEnd();
                    List<Country> countries = Newtonsoft.Json.JsonConvert.DeserializeObject <List<Country>>(ApiResponse);
                    gridViewData.DataSource = countries;
                    gridViewData.DataBind();   
                }
            }
            catch(Exception err)
            {
                Console.WriteLine("ERROR : "+err.Message);
                throw;
            }
        }
    }
}