using System;
using System.Collections.Generic;
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
using Forms = System.Windows.Forms;
using MCAssetsDOWNA;

namespace GUI版
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_click(object sender, RoutedEventArgs e)
        {
            var dlg = new Forms.FolderBrowserDialog();
            dlg.Description = "フォルダーを選択してください。";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // 選択されたフォルダーパスをメッセージボックスに表示
                PathTextbox.Text = dlg.SelectedPath;
            }
        }

        private void StartButton_click(object sender, RoutedEventArgs e)
        {
            if (PathTextbox.Text=="")
            {
                MessageBox.Show("パスを入れるんだ");
                return;

            }
            if (VerTextBox.Text=="")
            {
                MessageBox.Show("バージョンを入れるんだ!");
                return;

            }
            string outpath3 = PathTextbox.Text.TrimEnd('\\', '"');
            Core ASCore = new Core();
            ASCore.Assets(VerTextBox.Text, outpath3);
            MessageBox.Show("終了!");

        }

        private void VerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
