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
            string zipPath = @".\result.zip";

            Console.WriteLine("Provide path where to extract the zip file:");
            string extractPath = Console.ReadLine();

            // Normalizes the path.
            extractPath = Path.GetFullPath(extractPath);

            // Ensures that the last character on the extraction path
            // is the directory separator char.
            // Without this, a malicious zip file could try to traverse outside of the expected
            // extraction path.
            if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                extractPath += Path.DirectorySeparatorChar;

            ZipArchive archive = ZipFile.OpenRead(zipPath);

            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                DosyaAyikla(entry);
            }

        }

        private static string HedefDosya = "/örnek/Tetser/";

        public void DosyaAyikla(ZipArchiveEntry SikistilmisDosya)
        {
            
            string destinationPath = Path.Combine(HedefDosya, SikistilmisDosya.FullName);

            SikistilmisDosya.ExtractToFile(destinationPath);
        }
    }


}