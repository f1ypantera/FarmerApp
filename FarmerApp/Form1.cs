using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                    s = checkedListBox1.CheckedItems[x].ToString() + "\n";
                    listSt.Add(checkedListBox1.CheckedItems[x].ToString());
                }

                if (!listBox1.Items.Contains(s))
                {
                    listBox1.Items.Add(s);
                }
               
               // MessageBox.Show(s);
            }
        }
    }
}
