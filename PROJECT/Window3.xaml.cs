using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        

        string dbConnectionString = @"Data Source=hospital.sqlite;Version=3;";

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(dbConnectionString);
            try
            {
                con.Open();
                string Query = "insert into patientinfo (fname,lname,address,dob,ssn,phone,gender,veteran) values('" + this.fname_txt.Text + "','" + this.lname_txt.Text + "','" + this.address_txt.Text + "','" + this.dob_txt.Text + "','" + this.ssn_txt.Password + "','" + this.phone_txt.Text + "','" + this.gender_combo.Text + "','" + this.veteran_combo.Text + "')";
                SQLiteCommand cmd = new SQLiteCommand(Query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("SAVED!");
                con.Close();
                //,address,dob,ssn,phone,gender,veteran
                //,'" + this.address_txt.Text + "','" + this.dob_txt.Text + "','" + this.ssn_txt.Password + "','" + this.phone_txt.Text + "','" + this.gender_combo.Text + "''" + this.veteran_combo.Text + "'

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

      /*  private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            this.Hide();
            win2.ShowDialog();
        }*/
    }
}
