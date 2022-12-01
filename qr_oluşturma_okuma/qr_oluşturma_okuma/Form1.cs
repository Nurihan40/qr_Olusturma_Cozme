using System.IO;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
namespace qr_oluşturma_okuma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Image karekodOlustur(string giris, int kkduzey)
        {
            var deger = giris;
            MessagingToolkit.QRCode.Codec.QRCodeEncoder qre = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();

            if (radioButton2.Checked == true)
            {
                qre.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
            }
            if (radioButton1.Checked == true)
            {
                qre.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            }
            if (radioButton3.Checked == true)
            {
                qre.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
            }

            qre.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            qre.QRCodeVersion = kkduzey;
            System.Drawing.Bitmap bm = qre.Encode(deger);
            return bm;



        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
                {
                pictureBox1.Image = karekodOlustur(textBox1.Text, 4);
                }
                else
                {
                    MessageBox.Show("Lütfen ENCODE_MODE seçiniz", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {

                throw;
            }
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "karekter sayısı :  " + textBox1.Text.Length.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            karekod_cozumle();

        }
        void karekod_cozumle()
        {
            try
            {
                QRCodeDecoder decoder = new QRCodeDecoder();
                textBox1.Text = decoder.decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
            }
            catch (MessagingToolkit.QRCode.ExceptionHandler.DecodingFailedException ex)
            {

                MessageBox.Show("kare kod çözümlenemiyor..","Hata !",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /*private void karekodKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename;
            try
            {
                filename = "KK-" + textBox1.Lines[0] + ".jpg";
            }
            catch (IndexOutOfRangeException)
            {

                filename = "KK-" + DateTime.Now.ToString() + ".jpg";
            }

            if (pictureBox1.Image != null)
            {
                SaveFileDialog sf = new SaveFileDialog();
                {
                    
                }
            }

        }*/
    }
}