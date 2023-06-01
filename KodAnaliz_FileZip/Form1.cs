using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.IO.Compression;


namespace KodAnaliz_FileZip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string HedefDosya = "/örnek/Tetser/";

        public void DosyaAyikla(IEnumerator<ZipArchiveEntry> SikistilmisDosya)
        {
            ZipArchiveEntry entry = SikistilmisDosya.Current;
            string destinationPath = Path.Combine(HedefDosya, entry.FullName);

            entry.ExtractToFile(destinationPath);
        }
    }


}