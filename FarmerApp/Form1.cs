using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Entity;

namespace FarmerApp
{
    public partial class Form1 : Form
    {
        FurmContext db;

        public Form1()
        {
            InitializeComponent();

            db = new FurmContext();
            db.FarmModels.Load();

            var culture = db.FarmModels.Select(x => x.Culture).ToList();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Determine if there are any items checked.  
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                string s = "";
                var listSt = new List<string>();
                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    s = checkedListBox1.CheckedItems[x].ToString();    
                    if (!listBox1.Items.Contains(s))
                    {
                        listBox1.Items.Add(s);           
                    }

                }

                foreach(var str in listBox1.Items)
                {
                    listSt.Add(str.ToString());
                }

                // MessageBox.Show(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                listBox1.Items.Clear();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
