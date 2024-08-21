using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Media;
using System.Net.Http;
using System.Threading.Tasks;
using xscr33mLabs_7D2D_Launcher._Core._Forms;

namespace xscr33mLabs_7D2D_Launcher._Core._Engine
{
    /// <summary>
    /// Stellt Methoden zum Herunterladen von Dateien und Extrahieren von ZIP-Archiven bereit.
    /// </summary>
    internal class Downloader
    {
        /// <summary>
        /// Lädt eine Datei von einer URL herunter und speichert sie an einem angegebenen Speicherort.
        /// </summary>
        /// <param name="url">Die URL der Datei, die heruntergeladen werden soll.</param>
        /// <param name="destinationPath">Der Speicherort, an dem die Datei gespeichert werden soll.</param>
        /// <returns>Ein <see cref="Task"/>, das den Abschluss des asynchronen Downloads darstellt.</returns>
        public static async Task DownloadFileAsync(string url, string destinationPath)
        {
            using (HttpClient client = new HttpClient())
            {
                // Lade die Datei herunter
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                    stream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    // Kopiere den Inhalt der heruntergeladenen Datei in die Zieldatei
                    await contentStream.CopyToAsync(stream);
                }
            }
        }

        /// <summary>
        /// Entpackt eine ZIP-Datei in ein angegebenes Verzeichnis und aktualisiert vorhandene Dateien nur, wenn sie neuer sind.
        /// </summary>
        /// <param name="zipPath">Der Pfad zur ZIP-Datei.</param>
        /// <param name="extractPath">Der Zielpfad, in den die Dateien extrahiert werden sollen.</param>
        public static void ExtractZipFile(string zipPath, string extractPath)
        {
            // Erstelle einen temporären Ordner für die Extraktion der ZIP-Datei
            string tempExtractPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempExtractPath);
            bool updated = false;

            try
            {
                // Extrahiere die ZIP-Datei in den temporären Ordner
                ZipFile.ExtractToDirectory(zipPath, tempExtractPath);

                // Durchlaufe alle extrahierten Dateien im temporären Ordner
                foreach (string tempFilePath in Directory.GetFiles(tempExtractPath, "*", SearchOption.AllDirectories))
                {
                    // Bestimme den relativen Pfad der Datei im ZIP-Archiv
                    string relativePath = GetRelativePath(tempExtractPath, tempFilePath);
                    string targetFilePath = Path.Combine(extractPath, relativePath);

                    // Überprüfe, ob die Datei im Zielverzeichnis existiert
                    if (File.Exists(targetFilePath))
                    {
                        // Vergleiche die Zeitstempel der Dateien
                        DateTime tempFileLastWriteTime = File.GetLastWriteTime(tempFilePath);
                        DateTime targetFileLastWriteTime = File.GetLastWriteTime(targetFilePath);

                        // Ersetze die Datei nur, wenn die extrahierte Datei neuer ist
                        if (tempFileLastWriteTime > targetFileLastWriteTime)
                        {
                            File.Copy(tempFilePath, targetFilePath, true);
                            updated = true;
                        }
                    }
                    else
                    {
                        // Wenn die Datei nicht existiert, kopiere sie einfach
                        Directory.CreateDirectory(Path.GetDirectoryName(targetFilePath));
                        File.Copy(tempFilePath, targetFilePath);
                        updated = true;
                    }
                }
            }
            finally
            {
                // Lösche den temporären Ordner und alle darin enthaltenen Dateien
                if (Directory.Exists(tempExtractPath))
                {
                    Directory.Delete(tempExtractPath, true);
                }

                // Zeige eine Benachrichtigung, wenn Dateien aktualisiert wurden oder bereits aktuell sind
                CustomMessage popUpMessage = new CustomMessage();
                if (updated)
                {
                    SystemSounds.Exclamation.Play();
                    popUpMessage.ButtonOkay.Visible = true;
                    popUpMessage.ButtonOkay.Text = "OK";
                    popUpMessage.IconPictureBox.IconChar = IconChar.Check;
                    popUpMessage.IconPictureBox.IconColor = Color.Green;
                    popUpMessage.LabelMessageContent.Text = "Mods wurden erfolgreich aktualisiert!";
                    popUpMessage.Text = "Information";
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    popUpMessage.ButtonOkay.Visible = true;
                    popUpMessage.ButtonOkay.Text = "OK";
                    popUpMessage.IconPictureBox.IconChar = IconChar.Info;
                    popUpMessage.IconPictureBox.IconColor = Color.Blue;
                    popUpMessage.LabelMessageContent.Text = "Alle Mods sind bereits aktuell!";
                    popUpMessage.Text = "Information";
                }
                popUpMessage.ButtonNo.Visible = false;
                popUpMessage.ButtonYes.Visible = false;
                popUpMessage.ShowDialog();
            }
        }

        /// <summary>
        /// Bestimmt den relativen Pfad einer Datei im Vergleich zu einem Basisverzeichnis.
        /// </summary>
        /// <param name="basePath">Das Basisverzeichnis, von dem der relative Pfad bestimmt werden soll.</param>
        /// <param name="fullPath">Der vollständige Pfad der Datei, dessen relativer Pfad ermittelt werden soll.</param>
        /// <returns>Der relative Pfad der Datei im Vergleich zum Basisverzeichnis.</returns>
        private static string GetRelativePath(string basePath, string fullPath)
        {
            var baseUri = new Uri(basePath.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar);
            var fullUri = new Uri(fullPath);
            var relativeUri = baseUri.MakeRelativeUri(fullUri);
            return Uri.UnescapeDataString(relativeUri.ToString()).Replace('/', Path.DirectorySeparatorChar);
        }
    }
}
