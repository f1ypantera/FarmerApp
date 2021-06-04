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
using FarmerApp.Model;

namespace FarmerApp
{
    public partial class Form1 : Form
    {
        FurmContext db;
        public List<string> listSt = new List<string>();


        public Form1()
        {
            InitializeComponent();
            db = new FurmContext();
            db.FarmModels.Load();

            var culture = db.FarmModels.Select(x => x.Culture).ToList();
            var array = culture.ToArray<object>();
            this.checkedListBox1.Items.AddRange(array);
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Determine if there are any items checked.  
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                string s = "";

                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    s = checkedListBox1.CheckedItems[x].ToString();
                    if (!comboBox1.Items.Contains(s))
                    {

                        comboBox1.Items.Add(s);
                        listSt.Add(s);
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            listSt.Remove(selectedState);
            listBox2.Items.Clear();
            var innerList = new List<string>();
            var test = db.FarmModels.ToList();
            var item = test.FindAll(x => x.Culture == selectedState).Select(x => x.Restrictions).FirstOrDefault();
            string[] subs = item.Split(',');
            foreach (var t in listSt.ToList())
            {
                if (!subs.Contains(t))
                {
                    listBox2.Items.Add(t);
                    innerList.Add(t);
                }
            }
            listBox1.Items.Add(selectedState);
            comboBox1.Items.Clear();

            foreach (var il in innerList)
            {
                comboBox1.Items.Add(il);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                comboBox1.Items.Clear();
            }
        }


    }
}
