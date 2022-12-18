using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace LectureProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Code_OnClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            var result = dlg.ShowDialog();
            if (result == true)
            {
                var filepath = dlg.FileName;
                var fileName = dlg.FileName.Split('\\')[dlg.FileName.Split('\\').Length - 1];
                var tp = fileName.Split('.')[1];
                var targetPath = Path.Combine(Directory.GetCurrentDirectory(), $@"..\..\lzss-master\source.{tp}");
                File.Copy(filepath,targetPath,true);
                using (var process = new Process())
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        WorkingDirectory =  Path.Combine(Directory.GetCurrentDirectory(), $@"..\..\lzss-master"),
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                    };

                    process.StartInfo = startInfo;
                    process.Start();
                    process.StandardInput.WriteLine($"sample -c -i source.{tp} -o compress.{tp}");
                    process.StandardInput.WriteLine($"exit");
                    process.WaitForExit();
                    if (process.ExitCode == 0)
                    {
                        File.Delete(targetPath);
                        var compressPath = Path.Combine(Directory.GetCurrentDirectory(),
                            $@"..\..\lzss-master\compress.{tp}");
                        var targetCompressPath = Path.Combine(Directory.GetCurrentDirectory(),
                            $@"..\..\CompressResult\compress_{fileName}");
                        File.Copy(compressPath, targetCompressPath, true);
                        File.Delete(compressPath);
                        MessageBox.Show("Закодированный файл успешно сохранен в папку CompressResult");
                    }
                }
            }
        }

        private void Decode_OnClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),
                $@"..\..\CompressResult"));
            var result = dlg.ShowDialog();
            if (result == true)
            {
                var filepath = dlg.FileName;
                var fileName = dlg.FileName.Split('\\')[dlg.FileName.Split('\\').Length - 1];
                var tp = fileName.Split('.')[1];
                var targetPath = Path.Combine(Directory.GetCurrentDirectory(), $@"..\..\lzss-master\compress_source.{tp}");
                File.Copy(filepath,targetPath,true);
                using (var process = new Process())
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        WorkingDirectory =  Path.Combine(Directory.GetCurrentDirectory(), $@"..\..\lzss-master"),
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                    };

                    process.StartInfo = startInfo;
                    process.Start();
                    process.StandardInput.WriteLine($"sample -d -i compress_source.{tp} -o source.{tp}");
                    process.StandardInput.WriteLine($"exit");
                    process.WaitForExit();
                    if (process.ExitCode == 0)
                    {
                        File.Delete(targetPath);
                        var decompressPath = Path.Combine(Directory.GetCurrentDirectory(),
                            $@"..\..\lzss-master\source.{tp}");
                        var sourceName = fileName.Split('_')[1];
                        var targetDecompressPath = Path.Combine(Directory.GetCurrentDirectory(),
                            $@"..\..\DecompressResult\{sourceName}");
                        File.Copy(decompressPath, targetDecompressPath, true);
                        File.Delete(decompressPath);
                        MessageBox.Show("Раскодированный файл успешно сохранен в папку DecompressResult");
                    }
                }
            }
        }
    }
}