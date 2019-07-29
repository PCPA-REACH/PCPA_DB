using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace PCPA_DB
{
    public partial class PCPA_DB : Form
    {
        public PCPA_DB()
        {
            AutoScroll = true;
            InitializeComponent();

            // set properties
            for (int i = 0; i < phaseCBlist.Items.Count; i++)
                phaseCBlist.SetItemChecked(i, true);
            for (int i = 0; i < programCBlist.Items.Count; i++)
                programCBlist.SetItemChecked(i, true);

            #region associate event handlers
            yrMin.Leave += Min_OnExit;
            yrMax.Leave += Max_OnExit;
            projName.Leave += ProjName_OnExit;
            projNum.Leave += ProjNum_OnExit;
            searchbttn.Click += SearchOnClick;
            countryDropdown.DropDown += Countrydd_OnDrop; // resets to no selection upon drop
            countryDropdown.DropDown += Citydd_OnDrop; // resets to no selection upon drop
            clientDropdown.DropDown += Clientdd_OnDrop;
            hMin.Leave += Min_OnExit;
            hMax.Leave += Max_OnExit;
            fhMin.Leave += Min_OnExit;
            fhMax.Leave += Max_OnExit;
            fcMin.Leave += Min_OnExit;
            fcMax.Leave += Max_OnExit;
            gfaMax.Leave += Max_OnExit;
            gfaMin.Leave += Min_OnExit;
            costMin.Leave += Min_OnExit;
            costMax.Leave += Max_OnExit;

            resultList.MouseDoubleClick += Result_OnDoubleClick;
            resultList.SelectedValueChanged += Result_OnSelectChange;
            #endregion

            using (StreamReader sr = new StreamReader(@"D:\REACH\PCPA_DB\PCPA_DB.csv"))
            {
                int i = 0;
                string l;
                while ((l = sr.ReadLine()) != null)
                {
                    if (i == 0)
                    {
                        i++;
                        continue;
                    }
                    string[] attrs = l.Split(',');
                    csvdict[attrs[1]] = attrs; // project number as key, string[] as value
                    string country = attrs[3].Trim();
                    string client = attrs[5].Trim();
                    if (!countryDropdown.Items.Contains(country)) countryDropdown.Items.Add(country);
                    if (!clientDropdown.Items.Contains(client)) clientDropdown.Items.Add(client);
                }
            }
        }
      
        private void Min_OnExit(object sender, EventArgs e)
        {
            TextBox s = sender as TextBox;
            if (s.Text == "")
            {
                s.Text = "Min.";
                switch (s.Name)
                {
                    case "yrMin":
                        yrmin = 0;
                        break;
                    case "hMin":
                        hmin = 0;
                        break;
                    case "fhMin":
                        fhmin = 0;
                        break;
                    case "fcMin":
                        fcmin = 0;
                        break;
                    case "gfaMin":
                        gfamin = 0;
                        break;
                    case "costMin":
                        costmin = 0;
                        break;
                    default:
                        MessageBox.Show("switch case error");
                        break;
                }
            }
            else if (s.Text == "Min.") return;
            else
            {
                try
                {
                    switch (s.Name)
                    {
                        case "yrMin":
                            yrmin = Int32.Parse(s.Text);
                            break;
                        case "hMin":
                            hmin = Int32.Parse(s.Text);
                            break;
                        case "fhMin":
                            fhmin = Int32.Parse(s.Text);
                            break;
                        case "fcMin":
                            fcmin = Int32.Parse(s.Text);
                            break;
                        case "gfaMin":
                            gfamin = Int32.Parse(s.Text);
                            break;
                        case "costMin":
                            costmin = Int32.Parse(s.Text);
                            break;
                        default:
                            MessageBox.Show("switch case error");
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("not able to turn input into valid year number");
                    s.Text = "Min.";
                }
            }
        }

        private void Max_OnExit(object sender, EventArgs e)
        {
            TextBox s = sender as TextBox;
            if (s.Text == "")
            {
                s.Text = "Max.";
                switch (s.Name)
                {
                    case "yrMax":
                        yrmax = 0;
                        break;
                    case "hMax":
                        hmax = 0;
                        break;
                    case "fhMax":
                        fhmax = 0;
                        break;
                    case "fcMax":
                        fcmax = 0;
                        break;
                    case "gfaMax":
                        gfamax = 0;
                        break;
                    case "costMax":
                        costmax = 0;
                        break;
                    default:
                        MessageBox.Show("switch case error");
                        break;
                }
            }
            else if (s.Text == "Max.") return;
            else
            {
                try
                {
                    switch (s.Name)
                    {
                        case "yrMax":
                            yrmax = Int32.Parse(s.Text);
                            break;
                        case "hMax":
                            hmax = Int32.Parse(s.Text);
                            break;
                        case "fhMax":
                            fhmax = Int32.Parse(s.Text);
                            break;
                        case "fcMax":
                            fcmax = Int32.Parse(s.Text);
                            break;
                        case "gfaMax":
                            gfamax = Int32.Parse(s.Text);
                            break;
                        case "costMax":
                            costmax = Int32.Parse(s.Text); ;
                            break;
                        default:
                            MessageBox.Show("switch case error");
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("not able to turn input into valid year number");
                    s.Text = "Max.";
                }
            }
        }
        
        private void Clientdd_OnDrop(object sender, EventArgs e)
        {
            ComboBox s = sender as ComboBox;
            s.SelectedIndex = -1;
        }

        private void Citydd_OnDrop(object sender, EventArgs e)
        {
            ComboBox s = sender as ComboBox;
            s.SelectedIndex = -1;
        }

        private void Countrydd_OnDrop(object sender, EventArgs e)
        {
            ComboBox s = sender as ComboBox;
            s.SelectedIndex = -1;
        }

        private void ProjNum_OnExit(object sender, EventArgs e)
        {
            TextBox s = sender as TextBox;
            projnum = s.Text;
        }

        private void ProjName_OnExit(object sender, EventArgs e)
        {
            TextBox s = sender as TextBox;
            projname = s.Text;
        }
        
        private void Citydd_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = sender as ComboBox;
        }

        private void Countrydd_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox s = sender as ComboBox;
            cityDropdown.SelectedIndex = -1; // reset selection on citydd
            cityDropdown.Items.Clear();
            foreach (string k in csvdict.Keys)
            {
                string[] attrs = csvdict[k];
                if (s.SelectedItem as string == attrs[3].Trim())
                    if (!cityDropdown.Items.Contains(attrs[4].Trim()))
                        cityDropdown.Items.Add(attrs[4].Trim());
            }
        }

        // main search method
        private void SearchOnClick(object sender, EventArgs e)
        {
            /*var pop = new Popup();
            pop.ShowDialog();*/

            resultList.Items.Clear(); // clear result list
            picBox.ImageLocation = ""; // clear preview image
            
            foreach (string k in csvdict.Keys)
            {
                string[] attrs = csvdict[k]; // a row in database

                // year conditionals
                if (Int32.Parse(attrs[0]) > yrmax && yrmax != 0)
                    continue;
                else if (Int32.Parse(attrs[0]) < yrmin && yrmin != 0)
                    continue;

                // project number match
                string header = "";
                if (projA.Checked && !projB.Checked) header = "A";
                else if (projB.Checked && !projA.Checked) header = "B";

                if (header != "" && projnum != "" && attrs[1] != header + projnum)
                    continue;
                else if (header != "" && !attrs[1].StartsWith(header))
                    continue;
                else if (header == "" && projnum != "" && !attrs[1].EndsWith(projnum))
                    continue;

                // project name match
                if (projname != "" && !attrs[2].ToLower().Contains(projname.ToLower()))
                    continue;

                // country match
                if (countryDropdown.SelectedIndex != -1 && (string)countryDropdown.SelectedItem != attrs[3].Trim())
                    continue;

                // city match
                if (cityDropdown.SelectedIndex != -1 && (string)cityDropdown.SelectedItem != attrs[4].Trim())
                    continue;

                // client match
                if (clientDropdown.SelectedIndex != -1 && (string)clientDropdown.SelectedItem != attrs[5].Trim())
                    continue;

                // roof height match
                if (Int32.Parse(attrs[6]) > hmax && hmax != 0)
                    continue;
                else if (Int32.Parse(attrs[6]) < hmin && hmin != 0)
                    continue;

                // feature height match
                if (Int32.Parse(attrs[7]) > fhmax && fhmax != 0)
                    continue;
                else if (Int32.Parse(attrs[7]) < fhmin && fhmin != 0)
                    continue;

                // floor count match
                if (Int32.Parse(attrs[8]) > fcmax && fcmax != 0)
                    continue;
                else if (Int32.Parse(attrs[8]) < fcmin && fcmin != 0)
                    continue;

                // gfa match
                if (Int32.Parse(attrs[9]) > gfamax && gfamax != 0)
                    continue;
                else if (Int32.Parse(attrs[9]) < gfamin && gfamin != 0)
                    continue;

                // cost match
                if (Int32.Parse(attrs[10]) > costmax && costmax != 0)
                    continue;
                else if (Int32.Parse(attrs[10]) < costmin && costmin != 0)
                    continue;

                // phase match
                if (!phaseCBlist.CheckedItems.Contains(attrs[11]))
                    continue;

                // program match
                string[] prgms = attrs[12].Split('|');
                bool prgm_skip = true;
                for (int i=0;i<prgms.Length;i++)
                    if (programCBlist.CheckedItems.Contains(prgms[i]))
                    {
                        prgm_skip = false;
                        continue;
                    }
                if (prgm_skip) continue;


                // add to result if not exited by now
                resultList.Items.Add(string.Join(" _ ", attrs.Take(4)));
            }

        }

        private void Result_OnSelectChange(object sender, EventArgs e)
        {
            ListBox s = sender as ListBox;
            string i = s.SelectedItem as string;
            string k = i.Split(new string[] { " _ " }, StringSplitOptions.RemoveEmptyEntries)[1];
            string pth = csvdict[k].Last();
            try
            {
                picBox.ImageLocation = pth;
            }
            catch { }
        }

        private void Result_OnDoubleClick (object sender, MouseEventArgs e)
        {
            ListBox s = sender as ListBox;
            int i = s.IndexFromPoint(e.Location);
            if (i != ListBox.NoMatches)
            {

            }
        }

        #region fields
        protected int yrmin;
        protected int yrmax;
        protected string projnum="";
        protected string country;
        protected string city;
        protected string projname="";
        protected int hmin;
        protected int hmax;
        protected int fhmin;
        protected int fhmax;
        protected int fcmin;
        protected int fcmax;
        protected int gfamin;
        protected int gfamax;
        protected int costmin;
        protected int costmax;
        protected Dictionary<string, string[]> csvdict = new Dictionary<string, string[]>();
        
        #endregion
    }
}
