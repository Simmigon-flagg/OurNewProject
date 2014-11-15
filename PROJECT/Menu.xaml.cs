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
    /// Interaction logic for Menu.xaml
    /// </summary>.
    public partial class Menu : Window
    {
        addPatient UCadd = new addPatient();
        patientInfo UCInfo = new patientInfo();
        searchControl UCsearch = new searchControl();
        viewPatientInfo UCViewPat = new viewPatientInfo();
        NameSearch UCHeaderTextboxes = new NameSearch();
        SQLiteConnection con;
        SQLiteCommand cmd;
        SQLiteDataReader sqlite_datareader;
        Menu OurMenu;
         
        string firstName;
        string lastName;
        string dbConnectionString = @"Data Source=hospital.sqlite;Version=3;";
       
        public Menu()
        {
            InitializeComponent();
             
             btnSave.IsEnabled = false;
             btnUpdate.IsEnabled = false;
             
             MenuGrid.Children.Add(UCHeaderTextboxes);
             MenuGrid.Children.Add(UCViewPat);
           
        }
        private void GoToNewSearch(object sender, RoutedEventArgs e) 
        {
            viewPatientInfo viewPat = (viewPatientInfo)e.OriginalSource;
        }
        private void enterDataBase(object sender, RoutedEventArgs e)
        {
            addPatient addP = (addPatient)e.OriginalSource;
           con = new SQLiteConnection(dbConnectionString);
            try
            {
                con.Open();
                string Query = "insert into patientinfo (fname,lname,address,dob,ssn,phone,gender,veteran,healthConcern,descr) values('"
                    + addP.txtFname.Text + "','"
                    + addP.txtLname.Text + "','"
                    + addP.txtAddress.Text + "','"
                    + addP.txtDOB.Text + "','"
                    + addP.txtSSN.Text + "','"
                    + addP.txtPhone.Text + "','"
                    + addP.cbGender.Text + "','"
                    + addP.cbVeteran.Text + "','"
                    + addP.cbHealthConcern.Text + "','"
                    + addP.txtDescr.Text + "')";
                SQLiteCommand cmd = new SQLiteCommand(Query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("SAVED!");
                addP.txtFname.Text = "";
                addP.txtLname.Text = "";
                addP.txtAddress.Text = "";
                addP.txtDOB.Text = "";
                addP.txtSSN.Text = "";
                addP.txtPhone.Text = "";
                addP.cbGender.Text = "";
                addP.cbVeteran.Text = "";
                addP.cbHealthConcern.Text = "";
                addP.txtDescr.Text = "";
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Close();
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
           
            

           
            /**
                 * I need your help here JOVY because 
                 * I don't know the column names in the 
                 * database table patientinfo 
                 */

            /* ****************DATABASE INFO******************
             * database: hospital.sqlite
             * table name: patientinfo
             * columns: fname,lname,address,dob,ssn,phone,gender,veteran,healthConcern,descr
            */

            //if this person is in the Database this if statement will excute.
          /*   con = new SQLiteConnection(dbConnectionString);
            try
            {
                con.Open();
                
                string query = "SELECT * FROM patientinfo where username = '" + txtFirstName.Text + "' and username ='" + txtLastName.Text + "'";
          
                cmd = new SQLiteCommand(query, con);
               
               
                sqlite_datareader = cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    firstName = sqlite_datareader.GetString(0);
                    lastName = sqlite_datareader.GetString(1);
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

            if ((UCHeaderTextboxes.txtFirstName.Text == "") && (UCHeaderTextboxes.txtLastName.Text == ""))
            {
                MessageBox.Show("Search box can not be empty");

            }//end of first if statement 
            else if ((UCHeaderTextboxes.txtFirstName.Text == "Tia") && (UCHeaderTextboxes.txtLastName.Text == "Herring"))
            {
                MessageBox.Show("Person Found.");
                /**
                 * This Database Data will Go into the Content of the Tab
                 * Right HHHHHHEEEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRREEEEEEEEEEEEEEEE
                 * 
                 * 
                 * 
                 * 
                 *******************DATABASE STUFF****************************/
                UCViewPat.tabMenuTab.Content = UCHeaderTextboxes.txtFirstName.Text + "\r" + UCHeaderTextboxes.txtLastName.Text;
                UCHeaderTextboxes.txtFirstName.Text = "";
                UCHeaderTextboxes.txtLastName.Text = "";
            } //end of if else statement
            else 
            {
                MessageBox.Show("No Record of That Person");           
            }//end of else
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //This event will update in database then go to tab Control.

            //Navigation Code 
            MenuGrid.Children.Remove(UCsearch);
            MenuGrid.Children.Add(UCInfo);
           
            /*   if (firstName == seaSimmigon.txtFName.Text && lastName == seaSimmigon.txtLName.Text)
               {
                 //MessageBox.Show("Name Matches");
                   Menu m = new Menu();
                   //  m.tabItem1.Content = new patientInfo();   
               }
               else
               {
                  // MessageBox.Show("Invaild Name");
               }*/

          //  var firstName = "Simmigon";
         //   var lastName = "Flagg";
            // var TestuserNameDonotMatches = "WrongNameinDatabaseAccessDenied";
         /*   if (firstName == seaSimmigon.txtFName.Text && lastName == seaSimmigon.txtLName.Text)
            {
              //MessageBox.Show("Name Matches");
                Menu m = new Menu();
                //  m.tabItem1.Content = new patientInfo();   
            }
            else
            {
               // MessageBox.Show("Invaild Name");
            }*/


        }


        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            //Navigation Code
            MenuGrid.Children.Remove(UCsearch);
            MenuGrid.Children.Remove(UCadd);
            MenuGrid.Children.Remove(UCViewPat);
            MenuGrid.Children.Remove(UCHeaderTextboxes);
            MenuGrid.Children.Add(UCadd);
            btnSearch.Visibility = Visibility.Hidden;
            btnFind.Visibility = Visibility.Visible;
           // ourTabControl.Visibility = Visibility.Hidden;
            
            btnSave.IsEnabled = true;
            btnSearch.IsEnabled = true;
            btnUpdate.IsEnabled = false;
        }

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            //Navigation Code
            MessageBox.Show("Health Assessment Complete.");  
        
            MenuGrid.Children.Remove(UCsearch);
            MenuGrid.Children.Remove(UCadd);
            MenuGrid.Children.Add(UCViewPat);

            btnNew.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
          
            
            if (UCadd.txtFname.Text != "" &&
                UCadd.txtLname.Text != "" &&
                UCadd.txtAddress.Text != "" &&
                UCadd.txtDOB.Text != "" &&
                UCadd.txtSSN.Text != "" &&
                UCadd.txtPhone.Text != "" &&
                UCadd.cbGender.Text != "--Select--" &&
                UCadd.cbHealthConcern.Text != "--Select--" &&
                UCadd.cbVeteran.Text != "--Select--"
                )
            {
                MessageBox.Show("New Patient Saved");
                resetAllTextboxDataField();
                //Navigation Code
                MenuGrid.Children.Remove(UCsearch);
                MenuGrid.Children.Remove(UCadd);
                //Gray New button
                btnNew.IsEnabled = false;
                MenuGrid.Children.Add(UCHeaderTextboxes);
                MenuGrid.Children.Add(UCViewPat);                           
            }
            else { 
                MessageBox.Show("Please Fill in all Boxes");            
            }
  
        }
     
    public void resetAllTextboxDataField(){
                UCadd.txtFname.Text = "";
                UCadd.txtLname.Text = "";
                UCadd.txtAddress.Text = "";
                UCadd.txtDOB.Text = "";
                UCadd.txtSSN.Text = "";
                UCadd.txtPhone.Text = "" ;
                UCadd.cbGender.Text = "--Select--" ;
                UCadd.cbVeteran.Text = "--Select--";
                UCadd.cbHealthConcern.Text = "--Select--";
                UCHeaderTextboxes.txtFirstName.Text = "";
                UCHeaderTextboxes.txtLastName.Text = "";
                UCViewPat.tabMenuTab.Content = "";
    }

    private void btnFind_Click(object sender, RoutedEventArgs e)
    {
        //Goes Back to Search

        MenuGrid.Children.Add(UCHeaderTextboxes);
        MenuGrid.Children.Add(UCViewPat);
        MenuGrid.Children.Remove(UCadd);
        UCViewPat.tabMenuTab.Content = "";

        btnFind.Visibility = Visibility.Hidden;
        btnSave.IsEnabled = false;
        btnSearch.Visibility = Visibility.Visible;
        btnFind.Visibility = Visibility.Hidden;
       
    }
  }

}

