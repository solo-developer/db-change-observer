using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDependency.Enums;

namespace sqltabledependency
{
    public partial class Form1 : Form
    {
        Hubs.testDependency testDependency = new Hubs.testDependency();
        public Form1()
        {
            InitializeComponent();
            //initialize sql table dependency
            testDependency.change += TestDependency_change;
            testDependency.start();
        }

        private void TestDependency_change(object sender, TableDependency.EventArgs.RecordChangedEventArgs<Entity.test> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                MessageBox.Show("Table change event occured");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.
    ConnectionStrings["TheConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into test (name, roll) VALUES (@name, @roll)";
                    command.Parameters.AddWithValue("@name", "Niroj");
                    command.Parameters.AddWithValue("@roll", 10);

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
