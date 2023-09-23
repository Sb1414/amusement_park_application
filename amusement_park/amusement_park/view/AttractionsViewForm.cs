using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amusement_park.view
{
    public partial class AttractionsViewForm : Form
    {
        string connectionString = "Data Source=sb.db;Version=3;";
        public AttractionsViewForm()
        {
            InitializeComponent();
            LoadAttractionsData();
        }

        private void LoadAttractionsData()
        {
            string query = "SELECT a.name, a.description, a.capacity, a.ticket_price, a.time_work, GROUP_CONCAT(l.age_person) as limitations " +
                           "FROM attractions a " +
                           "LEFT JOIN limitations l ON a.id = l.attraction_id " +
                           "GROUP BY a.id";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        Panel attractionPanel = new Panel();
                        attractionPanel.AutoSize = true;

                        Label attractionLabel = new Label
                        {
                            Text = $"\n   {row["name"]}  \n" +
                            $"  {row["description"]}  \n  Вместимость: {row["capacity"]}  \n  Цена: {row["ticket_price"]}\n" +
                                $"  Продолжительность одного проката: {row["time_work"]}  \n  Ограничение в возрасте: {row["limitations"]}  \n\n",
                            AutoSize = true,
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            ForeColor = Color.White 
                        };

                        attractionPanel.BackgroundImage = Properties.Resources.backgroundAtraction_1;
                        attractionPanel.BackgroundImageLayout = ImageLayout.Stretch;

                        attractionPanel.Controls.Add(attractionLabel);

                        flowLayoutPanel1.Controls.Add(attractionPanel);
                    }
                }
            }
        }


    }

}
