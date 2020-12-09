using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SECCDataImageResizeWPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string path
        {
            get => pathTextBox.Text;
            set => pathTextBox.Text = value;
        }

        public void pathDialog(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpeg;*.jpg;*.png;*.PNG)|*.jpeg;*.jpg;*.png;*.PNG|JPEG files (*.jpeg)|*.jpeg|PNG files (*.PNG)|.PNG|All files (*.*)|*.*";
            bool? res = dialog.ShowDialog();
            if (res != true)
                return;
            path = dialog.FileName;
        }

        private readonly System.Drawing.Size targetSize = new System.Drawing.Size(500, 500);

        public void transBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("파일을 지정하지 않았거나 경로가 존재하지 않습니다.");
                return;
            }
            Bitmap bit = new Bitmap(path);

            Bitmap resize = new Bitmap(bit, targetSize);
            bit.Dispose(); File.Delete(path);
            resize.Save(path);
            resize.Dispose();
            MessageBox.Show($"지정하신 파일의 크기가 {targetSize.ToString()}으로 변경되었습니다.");
        }
    }
}