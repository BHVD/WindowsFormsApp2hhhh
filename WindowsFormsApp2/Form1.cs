using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Security.Policy;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile1.xml");
            doc.Load("XMLFile2.xml");
            XmlNode root = doc.DocumentElement;
            // Tìm kiếm theo mã lớp và trả về danh sách nút tìm được
            XmlNodeList nodeList = root.SelectNodes("descendant::Sinhvien[@Malop='" + textBox1.Text + "']");
           
            // Tạo bảng chứa kết quả
            DataTable dt = new DataTable();
            dt.Columns.Add("Masv"); 
            dt.Columns.Add("Hoten");
            dt.Columns.Add("Ngaysinh"); 
            dt.Columns.Add("Ten"); 
            dt.Columns.Add("Dien_thoai");
            dt.Columns.Add("Dia_chi");
            dt.Columns.Add("Muc_giam");
            dt.Columns.Add("Ty_le_giam");

            foreach (XmlNode sv in nodeList)
            {
                DataRow row = dt.NewRow();
                row["Masv"] = sv.ChildNodes[0].InnerText;
                row["Hoten"] = sv.ChildNodes[1].InnerText;
                row["Ngaysinh"] = sv.ChildNodes[2].InnerText;
                dt.Rows.Add(row);

            }
            dataGridView1.DataSource = dt;


        }
        public static void Transform(string sXmlPath, string sXslPath)
        {
            string filename = "d:\\Ketqua.html";
            try
            {//load the Xml doc
                XPathDocument myXPathDoc = new XPathDocument(sXmlPath);
                XslTransform myXslTrans = new XslTransform();
                //load the Xsl 
                myXslTrans.Load(sXslPath);
                //Mở file để ghi
                XmlTextWriter myWriter = new XmlTextWriter(filename, null);
                myXslTrans.Transform(myXPathDoc, null, myWriter);
                myWriter.Close();
                MessageBox.Show("Chuyển đổi thành file: " + filename + " Thanh cong");}catch (Exception e)
            {

                    MessageBox.Show("Exception: {0}", e.ToString());
                }
            }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Transform(textBox2.Text, textBox3.Text);

        }
    }
}
