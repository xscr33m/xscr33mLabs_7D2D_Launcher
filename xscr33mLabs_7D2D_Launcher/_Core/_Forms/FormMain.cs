using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using xscr33mLabs_7D2D_Launcher._Core._Engine;
using xscr33mLabs_7D2D_Launcher._Core._Forms;

namespace xscr33mLabs_7D2D_Launcher
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            // Überprüfe, ob bereits eine Instanz der Anwendung läuft und ob Updates verfügbar sind
            await InstanceCheck.CheckForInstance();
            await UpdateCheck.CheckForUpdates();

            // Lade gespeicherte Verbindungsdaten und setze die TextBoxen
            string serverIP, serverPort, gamePath, serverPass;
            ConnectionData.LoadConnectionData(out serverIP, out serverPort, out gamePath, out serverPass);

            TextBoxIP.Text = serverIP;
            TextBoxPort.Text = serverPort;
            TextBoxGamePath.Text = gamePath;
            TextBoxPass.Text = serverPass;

            // Überprüfe, ob der Pfad zum Spiel gesetzt ist oder ob der Standardpfad verwendet werden soll
            if (gamePath == "Hier klicken zum suchen")
            {
                if (GetGamePath.CheckDefaultGamePath(out gamePath))
                {
                    TextBoxGamePath.Text = gamePath;
                }
                else
                {
                    // Zeige eine Fehlermeldung an, wenn der Standardpfad nicht gefunden wurde
                    CustomMessage errorMessage = new CustomMessage();
                    SystemSounds.Exclamation.Play();
                    errorMessage.ButtonOkay.Visible = true;
                    errorMessage.ButtonOkay.Text = "OK";
                    errorMessage.IconPictureBox.IconChar = IconChar.Warning;
                    errorMessage.IconPictureBox.IconColor = Color.Yellow;
                    errorMessage.LabelMessageContent.Text = $"Das Spiel '7 Days To Die' wurde nicht im Standardverzeichnis gefunden. \n\nBitte wähle den Pfad manuell aus.";
                    errorMessage.Text = "Fehler!";
                    errorMessage.ButtonNo.Visible = false;
                    errorMessage.ButtonYes.Visible = false;
                    errorMessage.ShowDialog();
                }
            }
        }

        private void SearchGameFolder_Click(object sender, EventArgs e)
        {
            // Mögliche Verzeichnisse, in denen das Spiel zu finden sein könnte
            string[] possibleDirectories = new string[]
            {
                @"C:\Program Files (x86)\Steam\steamapps\common\7 Days To Die",
                @"D:\SteamLibrary\steamapps\common\7 Days To Die",
                @"E:\SteamLibrary\steamapps\common\7 Days To Die",
                @"F:\SteamLibrary\steamapps\common\7 Days To Die",
                @"G:\SteamLibrary\steamapps\common\7 Days To Die",
                @"H:\SteamLibrary\steamapps\common\7 Days To Die",
                @"I:\SteamLibrary\steamapps\common\7 Days To Die",
                @"J:\SteamLibrary\steamapps\common\7 Days To Die"
            };

            // Bestimme das initiale Verzeichnis für den OpenFileDialog
            string initialDirectory = GetInitialDirectory(possibleDirectories);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = initialDirectory;
                openFileDialog.Filter = "7 Days To Die (7DaysToDie.exe)|7DaysToDie.exe";
                openFileDialog.RestoreDirectory = true;

                // Zeige den OpenFileDialog an und setze den Spielpfad, wenn eine Datei ausgewählt wird
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TextBoxGamePath.Text = openFileDialog.FileName;
                }
            }
        }

        private string GetInitialDirectory(string[] directories)
        {
            // Überprüfe jedes mögliche Verzeichnis und gib das erste gefundene zurück
            foreach (var directory in directories)
            {
                if (Directory.Exists(directory))
                {
                    return directory;
                }
            }
            // Fallback-Verzeichnis, wenn keine der möglichen Pfade gefunden wurde
            return "C:\\";
        }

        private void ButtonShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            // Zeige das Passwort im Klartext an, wenn die Maustaste gedrückt wird
            TextBoxPass.UseSystemPasswordChar = false;
        }

        private void ButtonShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            // Verstecke das Passwort wieder, wenn die Maustaste losgelassen wird
            TextBoxPass.UseSystemPasswordChar = true;
        }

        private void ButtonShowPass_MouseLeave(object sender, EventArgs e)
        {
            // Verstecke das Passwort, wenn die Maus das Element verlässt
            TextBoxPass.UseSystemPasswordChar = true;
        }

        private void ButtonJoin_Click(object sender, EventArgs e)
        {
            // Hole die Daten aus den TextBoxen
            string serverIP = TextBoxIP.Text;
            string serverPort = TextBoxPort.Text;
            string gamePath = TextBoxGamePath.Text;
            string serverPass = TextBoxPass.Text;

            // Verwende JoinManager, um sich mit den Serverdaten zu verbinden
            JoinManager.JoinServer(serverIP, serverPort, serverPass, gamePath);
        }

        private async void LoadServerMods(object sender, EventArgs e)
        {
            // URL zum Herunterladen der Mod-Datei
            string downloadUrl = "https://github.com/xscr33m/seveM/releases/download/m/Client.zip";
            string zipPath = Path.Combine(Path.GetTempPath(), "mods.zip");

            // Pfad zum Entpacken der ZIP-Datei
            string basePath = Path.GetDirectoryName(TextBoxGamePath.Text);
            string extractPath = Path.Combine(basePath, "Mods");

            try
            {
                // Sicherstellen, dass der Mods-Ordner existiert
                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }

                // Download der ZIP-Datei
                await Downloader.DownloadFileAsync(downloadUrl, zipPath);
                Console.WriteLine("ZIP-Datei erfolgreich heruntergeladen.");

                // Entpacken der ZIP-Datei in den Mods-Ordner
                Downloader.ExtractZipFile(zipPath, extractPath);
                Console.WriteLine("ZIP-Datei erfolgreich entpackt.");
            }
            catch (Exception ex)
            {
                // Zeige eine Fehlermeldung an, wenn beim Download oder Entpacken ein Fehler auftritt
                CustomMessage errorMessage = new CustomMessage();
                SystemSounds.Exclamation.Play();
                errorMessage.ButtonOkay.Visible = true;
                errorMessage.ButtonOkay.Text = "OK";
                errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                errorMessage.IconPictureBox.IconColor = Color.Red;
                errorMessage.LabelMessageContent.Text = $"Fehler: {ex.Message}\n";
                errorMessage.Text = "Fehler!";
                errorMessage.ButtonNo.Visible = false;
                errorMessage.ButtonYes.Visible = false;
                errorMessage.ShowDialog();
                Console.WriteLine($"Fehler: {ex.Message}");
            }
            finally
            {
                // Löschen der ZIP-Datei nach dem Entpacken
                if (File.Exists(zipPath))
                {
                    File.Delete(zipPath);
                    Console.WriteLine("ZIP-Datei gelöscht.");
                }
            }
        }

        private void TextBoxFields_TextChanged(object sender, EventArgs e)
        {
            // Überprüfe, ob alle erforderlichen TextBoxen ausgefüllt sind und die IP-Adresse gültig ist
            ButtonJoin.Enabled = AreAllFieldsFilled();
            ButtonMods.Enabled = AreAllFieldsFilled() && IsValidIpAddress(TextBoxIP.Text);
        }

        // Methode zur Überprüfung, ob alle erforderlichen Felder ausgefüllt sind
        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(TextBoxIP.Text) &&
                   !string.IsNullOrWhiteSpace(TextBoxPort.Text) &&
                   !string.IsNullOrWhiteSpace(TextBoxGamePath.Text) &&
                   !string.IsNullOrWhiteSpace(TextBoxPass.Text);
        }

        // Methode zur Überprüfung, ob der Text eine gültige IP-Adresse ist
        private bool IsValidIpAddress(string ipAddress)
        {
            // Beispielhafte IP-Überprüfung (kann angepasst werden)
            return ipAddress == "116.202.117.62";
        }

        // --- Save Connection --- //
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Speichere die aktuellen Verbindungsdaten beim Schließen des Formulars
            ConnectionData.SaveConnectionData(
                TextBoxIP.Text,
                TextBoxPort.Text,
                TextBoxGamePath.Text,
                TextBoxPass.Text
            );
            base.OnFormClosing(e);
        }

        // --- Black TitleBar --- //
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            // Setze den Titelbalken auf schwarz, wenn die Fensterhandhabung erstellt wurde
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
    }
}
