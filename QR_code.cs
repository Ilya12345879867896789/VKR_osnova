using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using ZXing;
using ZXing.Rendering;
using ZXing.QrCode;
using ZXing.Common;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;

namespace Sklad_mebeli
{
    public partial class QR_code : Form
    {
        public QR_code(object id)
        {
            InitializeComponent();

            Codirovka.DropDownStyle = ComboBoxStyle.DropDown;
        }
    public static Image CreateCode(string text, int w, int h, BarcodeFormat format)
    {
        try
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = format,
                Options = new QrCodeEncodingOptions
                {
                    Width = w,
                    Height = h,
                    CharacterSet = "UTF-8"
                },
                Renderer = new BitmapRenderer()
            };

            return writer.Write(text); // зашифровать текст в необходимый графический код.
        }
        catch (Exception) { }

        return null;
    }
    public static string[] CodeScan(Bitmap bmp)
    {
        try
        {
            BarcodeReader reader = new BarcodeReader
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new DecodingOptions
                {
                    TryHarder = true
                }
            };
            Result[] results = reader.DecodeMultiple(bmp);

            if (results != null)
                return results.Where(x => x != null && !string.IsNullOrEmpty(x.Text)).Select(x => x.Text).ToArray();
        }
        catch (Exception) { }

        return null;
    }
    public static string DecodeImage(Image img)
    {
        // Декодирует код с изображения

        string outString = "";

        string[] results = CodeScan((Bitmap)img);

        if (results != null)
            outString = string.Join(Environment.NewLine + Environment.NewLine, results);

        return outString;
    }

    private BarcodeFormat GetFormat()
    {
        // Возвращает выбранный формат кода

        switch (Codirovka.Text)
        {
            case "CODEBAR": return BarcodeFormat.CODABAR;
            case "CODE_39": return BarcodeFormat.CODE_39;
            case "CODE_93": return BarcodeFormat.CODE_93;
            case "CODE_128": return BarcodeFormat.CODE_128;
            case "QR_CODE": return BarcodeFormat.QR_CODE;
            case "MSI": return BarcodeFormat.MSI;
            case "DATA_MATRIX": return BarcodeFormat.DATA_MATRIX;
            default: return BarcodeFormat.CODABAR;
        }
    }


        private void Zagruz_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = openFileDialog1.ShowDialog();

                if (dialog == DialogResult.OK)
                    Code.Image = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex) { }
        }

        private void Rashifr_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(DecodeImage(Code.Image));
            }
            catch (Exception ex) { }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "img.png";
                DialogResult dialog = saveFileDialog1.ShowDialog();


                if (dialog == DialogResult.OK)
                    Code.Image.Save(saveFileDialog1.FileName);



                string base64 = Convert.ToBase64String(File.ReadAllBytes("image.jpg"));


            string connectionString = "Data Source=. \\SQLEXPRESS; Initial Catalog=Sklad_Mebeli;Integrated Security=true";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string sql = "INSERT INTO Tablet (Gotovaya_prodykcia) VALUES ('" + base64 + "')";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.ExecuteNonQuery();

            sql = "SELECT Gotovaya_prodykcia FROM Sklad WHERE ID = 14";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            string base64FromDataBase = sqlCommand.ExecuteScalar().ToString();









            var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(base64FromDataBase)));

            image.Save("1.jpg", ImageFormat.Jpeg);
            }
            catch (Exception ex) { }
        }

        private void Textick_TextChanged(object sender, EventArgs e)
        {
            Code.Image = CreateCode(Textick.Text, Code.Width, Code.Height, GetFormat());
        }
    }
}
