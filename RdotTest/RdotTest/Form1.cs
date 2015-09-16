using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RDotNet;

namespace RdotTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             
            string dlldir = @"C:\Program Files\R\R-3.2.1\bin\i386";
            REngine.SetEnvironmentVariables(dlldir);
           

        }
      
 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void readBtn_Click(object sender, EventArgs e)
        {
           REngine engine = REngine.GetInstance();
 
            try
            {
                // import csv file
                DataFrame dataset = engine.Evaluate("dataset<-read.table(file.choose(), header=TRUE, sep = ',')").AsDataFrame();
 
                // retrieve the data frame
                

                for (int i = 0; i < dataset.ColumnCount; ++i)
                {
                    dataGridView1.ColumnCount++;
                    dataGridView1.Columns[i].Name = dataset.ColumnNames[i];
                }

                for (int i = 0; i < dataset.RowCount; ++i)
                {
                    dataGridView1.RowCount++;
                    dataGridView1.Rows[i].HeaderCell.Value = dataset.RowNames[i];

                    for (int k = 0; k < dataset.ColumnCount; ++k)
                    {
                        dataGridView1[k, i].Value = dataset[i, k];

                    }

                }
                

              
            }
 
            catch
            {
                MessageBox.Show(@"Equation error.");
            }

            
        }
        }
    
}
