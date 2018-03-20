using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Send_Email
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        string Path;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SMTPServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(textBox1.Text);
                mail.To.Add(textBox2.Text);
                mail.Subject = textBox3.Text;
                mail.Body = textBox4.Text;
                if (Path != "")
                {
                    Attachment attachment = new System.Net.Mail.Attachment(Path);
                    mail.Attachments.Add(attachment);
                }
                

                SMTPServer.Port = 587;
                SMTPServer.Credentials = new System.Net.NetworkCredential(textBox1.Text, textBox5.Text);
                SMTPServer.EnableSsl = true;
                SMTPServer.Send(mail);
                MessageBox.Show("Mail Sent...", "Success!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error. The reason is --> " + ex.Message, "Error!", MessageBoxButtons.OK);
            }
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox5.PasswordChar = '\0'; 
            }
            else if (checkBox1.Checked == false)
            {
                textBox5.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    Path = fd.FileName;
                    label6.Text = "The File Attached";
                }
                else
                {
                    label6.Text = "Couldn't Attach the File.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reason --> "+ex.Message, "Error!!", MessageBoxButtons.OK);
            }
            
        }
    }

}
