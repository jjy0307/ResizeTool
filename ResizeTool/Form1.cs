using OpenCvSharp;

namespace ResizeTool {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = @"";
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e) {

        }
       
        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {   

            // 저장경로 생성
            string newFolderPath = @"C:\ResizedImages";
            Directory.CreateDirectory(newFolderPath);

            string[] filePaths = Directory.GetFiles(textBox1.Text);

            foreach (string filePath in filePaths) {
                Mat src = Cv2.ImRead(filePath);
                Mat dst = new Mat();

                //사이즈 설정
                // Cv2.Resize(src, dst, new OpenCvSharp.Size(Width,Height));
                Cv2.Resize(src, dst, new OpenCvSharp.Size(3000, 3000));

                string newFilePath = Path.Combine(newFolderPath, Path.GetFileName(filePath));
                Cv2.ImWrite(newFilePath, dst);
            }

            MessageBox.Show("resized completed");

            //경로 열기
            System.Diagnostics.Process.Start("explorer.exe", newFolderPath);
        }



        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e) {

        }
    }
}