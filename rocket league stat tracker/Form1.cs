using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rocket_league_stat_tracker
{
    

    public partial class Form1 : Form
    {
        public double games=0,totalScore=0,totalGoals=0,totalAssists=0,totalSaves=0,totalShots=0;
        public double goalAvg = 0.0, assistAvg = 0.0, saveAvg = 0.0, shotAvg = 0.0 , scoreAvg=0.0;
        
        private void button2_Click(object sender, EventArgs e)
        {//save button
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "rlsx files only please|*.rlsx";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                StreamWriter bw = new StreamWriter(File.Create(path));

                bw.Write(games.ToString());
                bw.Write("\n");
                bw.Write(totalScore.ToString());
                bw.Write("\n");
                bw.Write(totalGoals.ToString());
                bw.Write("\n");
                bw.Write(totalAssists.ToString());
                bw.Write("\n");
                bw.Write(totalSaves.ToString());
                bw.Write("\n");
                bw.Write(totalShots.ToString());
                bw.Write("\n");
                bw.Write(label12.Text);
                bw.Write("\n");
                bw.Write(label13.Text);
                bw.Dispose();
            }
        }

        public void update()
        {
            goalAvg = totalGoals / games;
            assistAvg = totalAssists / games;
            saveAvg = totalSaves / games;
            shotAvg = totalShots / games;
            scoreAvg = totalScore / games;

            label5.Text = scoreAvg.ToString();
            label6.Text = goalAvg.ToString();
            label7.Text = assistAvg.ToString();
            label8.Text = saveAvg.ToString();
            label16.Text = shotAvg.ToString();
            label11.Text = games.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {//load button
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "rlsx files only please|*.rlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                games = Convert.ToDouble(sr.ReadLine());
                totalScore = Convert.ToDouble(sr.ReadLine());
                totalGoals = Convert.ToDouble(sr.ReadLine());
                totalAssists = Convert.ToDouble(sr.ReadLine());
                totalSaves = Convert.ToDouble(sr.ReadLine());
                totalShots = Convert.ToDouble(sr.ReadLine());
                label12.Text = sr.ReadLine();
                label13.Text = sr.ReadLine();

                update();

            }
        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tempScore, tempGoals, tempAssists, tempSaves, tempShots;
            games++;
            Int32.TryParse(textBox1.Text, out tempScore);
            Int32.TryParse(textBox2.Text, out tempGoals);
            Int32.TryParse(textBox3.Text, out tempAssists);
            Int32.TryParse(textBox4.Text, out tempSaves);
            Int32.TryParse(textBox5.Text, out tempShots);

            totalGoals = totalGoals + tempGoals;
            totalScore = totalScore + tempScore;
            totalAssists = totalAssists + tempAssists;
            totalSaves = totalSaves + tempSaves;
            totalShots = totalShots + tempShots;

            update();

            if(radioButton1.Checked == true)
            {
                Int32.TryParse(label12.Text, out int wins);
                wins++;
                label12.Text = wins.ToString();
            }
            else
            {
                Int32.TryParse(label13.Text, out int losses);
                losses++;
                label13.Text = losses.ToString();
            }

        }
    }
}
