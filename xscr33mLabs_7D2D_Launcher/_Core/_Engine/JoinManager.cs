using FontAwesome.Sharp;
using IWshRuntimeLibrary;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using xscr33mLabs_7D2D_Launcher._Core._Forms;

namespace xscr33mLabs_7D2D_Launcher._Core._Engine
{
    /// <summary>
    /// Verwaltet die Erstellung und Ausführung von Verknüpfungen zum Beitreten eines Servers.
    /// </summary>
    internal class JoinManager
    {
        /// <summary>
        /// Erstellt eine Verknüpfung, um einem Server beizutreten, und startet diese Verknüpfung.
        /// </summary>
        /// <param name="ip">Die IP-Adresse des Servers.</param>
        /// <param name="port">Der Port des Servers.</param>
        /// <param name="password">Das Passwort für den Server.</param>
        /// <param name="gamePath">Der Pfad zur Executable des Spiels.</param>
        public static void JoinServer(string ip, string port, string password, string gamePath)
        {
            // Überprüfe, ob der Pfad zur Executable des Spiels korrekt ist
            if (!System.IO.File.Exists(gamePath))
            {
                // Zeige eine Fehlermeldung an, wenn die Datei nicht gefunden wird
                MessageBox.Show("Der angegebene Pfad zur 7 Days to Die-Executable ist ungültig.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Bestimme den Pfad für den AppData-Ordner, in dem die Verknüpfung gespeichert wird
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "7D2D_Launcher");

            // Stelle sicher, dass der AppData-Ordner existiert, wenn nicht, erstelle ihn
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            // Bestimme den Pfad zur .lnk-Datei basierend auf der IP-Adresse und dem Port
            string shortcutFileName = $"Join_{ip.Replace('.', '_')}_{port}.lnk";
            string shortcutFilePath = Path.Combine(appDataPath, shortcutFileName);

            // Erstelle den Inhalt der Verknüpfung
            string arguments = $"+connect {ip}:{port} +password {password}";

            try
            {
                // Erstelle die Verknüpfung
                CreateShortcut(shortcutFilePath, gamePath, arguments);

                // Starte die Verknüpfung
                Process.Start(shortcutFilePath);
            }
            catch (IOException ex)
            {
                // Fehlerbehandlung, wenn das Erstellen der Verknüpfung fehlschlägt
                CustomMessage errorMessage = new CustomMessage();
                SystemSounds.Exclamation.Play();
                errorMessage.ButtonOkay.Visible = true;
                errorMessage.ButtonOkay.Text = "OK";
                errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                errorMessage.IconPictureBox.IconColor = Color.Red;
                errorMessage.LabelMessageContent.Text = $"Fehler beim Erstellen der Verknüpfung: {ex.Message}\n";
                errorMessage.Text = "Fehler!";
                errorMessage.ButtonNo.Visible = false;
                errorMessage.ButtonYes.Visible = false;
                errorMessage.ShowDialog();
            }
            catch (Win32Exception ex)
            {
                // Fehlerbehandlung, wenn das Starten der Verknüpfung fehlschlägt
                CustomMessage errorMessage = new CustomMessage();
                SystemSounds.Exclamation.Play();
                errorMessage.ButtonOkay.Visible = true;
                errorMessage.ButtonOkay.Text = "OK";
                errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                errorMessage.IconPictureBox.IconColor = Color.Red;
                errorMessage.LabelMessageContent.Text = $"Fehler beim Starten der Verknüpfung: {ex.Message}\n";
                errorMessage.Text = "Fehler!";
                errorMessage.ButtonNo.Visible = false;
                errorMessage.ButtonYes.Visible = false;
                errorMessage.ShowDialog();
            }
            catch (Exception ex)
            {
                // Allgemeine Fehlerbehandlung für unerwartete Fehler
                CustomMessage errorMessage = new CustomMessage();
                SystemSounds.Exclamation.Play();
                errorMessage.ButtonOkay.Visible = true;
                errorMessage.ButtonOkay.Text = "OK";
                errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                errorMessage.IconPictureBox.IconColor = Color.Red;
                errorMessage.LabelMessageContent.Text = $"Ein unerwarteter Fehler ist aufgetreten: {ex.Message}\n";
                errorMessage.Text = "Fehler!";
                errorMessage.ButtonNo.Visible = false;
                errorMessage.ButtonYes.Visible = false;
                errorMessage.ShowDialog();
            }
        }

        /// <summary>
        /// Erstellt eine Verknüpfung (.lnk-Datei) mit den angegebenen Eigenschaften.
        /// </summary>
        /// <param name="shortcutPath">Der Pfad, an dem die Verknüpfung gespeichert wird.</param>
        /// <param name="targetPath">Der Pfad zur Executable des Spiels.</param>
        /// <param name="arguments">Die Befehlszeilenargumente für die Verknüpfung.</param>
        private static void CreateShortcut(string shortcutPath, string targetPath, string arguments)
        {
            // Erstelle ein Shell-Link-Objekt
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            // Setze die Eigenschaften des Links
            shortcut.TargetPath = targetPath; // Pfad zur Executable
            shortcut.Arguments = arguments; // Befehlszeilenargumente
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath); // Arbeitsverzeichnis
            shortcut.Save(); // Speichere die Verknüpfung
        }
    }
}
