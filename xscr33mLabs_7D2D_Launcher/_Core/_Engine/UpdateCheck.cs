using FontAwesome.Sharp;
using Octokit;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using xscr33mLabs_7D2D_Launcher._Core._Forms;

namespace xscr33mLabs_7D2D_Launcher._Core._Engine
{
    /// <summary>
    /// Führt eine Überprüfung auf Updates durch und verwaltet das Herunterladen neuer Versionen.
    /// </summary>
    internal class UpdateCheck
    {
        // Pfad zum Ordner für Log-Dateien
        readonly static string LogFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        // Pfad zur Log-Datei für Fehler
        readonly static string ErrorLogFilePath = Path.Combine(LogFolderPath, "ErrorLog.txt");

        /// <summary>
        /// Überprüft auf Updates und informiert den Benutzer über verfügbare Updates.
        /// </summary>
        public static async Task CheckForUpdates()
        {
            try
            {
                // Erstelle einen GitHub-Client für den Zugriff auf die GitHub-API
                var github = new GitHubClient(new ProductHeaderValue("xscr33mLabs_7D2D_Launcher"));

                string owner = "xscr33m";
                string repo = "xscr33mLabs_7D2D_Launcher";

                try
                {
                    // Hole alle Releases des Repositories
                    var releases = await github.Repository.Release.GetAll(owner, repo);

                    // Sortiere die Releases nach Veröffentlichungsdatum absteigend
                    var sortedReleases = releases.OrderByDescending(r => r.PublishedAt);

                    // Hole die aktuelle Version der Anwendung
                    Version currentVersion = Assembly.GetEntryAssembly().GetName().Version;
                    // Hole die neueste Version aus den Releases
                    Version latestVersion = new Version(sortedReleases.FirstOrDefault()?.TagName.TrimStart('v'));

                    // Vergleiche aktuelle Version mit der neuesten Version
                    if (latestVersion != null && latestVersion > currentVersion)
                    {
                        // Zeige eine Nachricht an, dass ein Update verfügbar ist
                        CustomMessage popUpMessage = new CustomMessage();
                        SystemSounds.Exclamation.Play();
                        popUpMessage.ButtonOkay.Visible = false;
                        popUpMessage.IconPictureBox.IconChar = IconChar.Warning;
                        popUpMessage.IconPictureBox.IconColor = Color.Yellow;
                        popUpMessage.LabelMessageContent.Text = "Eine neue Version ist verfügbar! \n\nMöchtest Du sie jetzt herunterladen? ";
                        popUpMessage.Text = "Update verfügbar!";
                        popUpMessage.ButtonNo.Visible = true;
                        popUpMessage.ButtonYes.Visible = true;
                        popUpMessage.ButtonNo.Text = "Nein";
                        popUpMessage.ButtonYes.Text = "Ja";
                        DialogResult updateDialog = popUpMessage.ShowDialog();

                        // Wenn der Benutzer zustimmt, öffne die Download-URL
                        if (updateDialog == DialogResult.Yes)
                        {
                            string downloadUrl = string.Format("https://github.com/{0}/{1}/releases/download/{2}/7Days2Die_ServerLauncher.zip", owner, repo, sortedReleases.FirstOrDefault()?.TagName);
                            string changelogUrl = string.Format("https://github.com/{0}/{1}/releases/", owner, repo);

                            try
                            {
                                Process.Start(downloadUrl); // Starte den Browser zum Download
                                Process.Start(changelogUrl); // Starte den Browser zum Changelog
                            }
                            catch (Exception ex)
                            {
                                // Fehlerbehandlung, wenn der Browser nicht gestartet werden konnte
                                if (!Directory.Exists(LogFolderPath))
                                {
                                    Directory.CreateDirectory(LogFolderPath);
                                }

                                File.AppendAllText(ErrorLogFilePath, $"{DateTime.Now}: " + "Der Browser konnte nicht gestartet werden: " + $"{ex.Message}\n");

                                CustomMessage errorMessage = new CustomMessage();
                                SystemSounds.Exclamation.Play();
                                errorMessage.ButtonOkay.Visible = true;
                                errorMessage.ButtonOkay.Text = "OK";
                                errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                                errorMessage.IconPictureBox.IconColor = Color.Red;
                                errorMessage.LabelMessageContent.Text = $"Der Browser konnte nicht gestartet werden: " + $"{ex.Message}\n";
                                errorMessage.Text = "Fehler!";
                                errorMessage.ButtonNo.Visible = false;
                                errorMessage.ButtonYes.Visible = false;
                                errorMessage.ShowDialog();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Fehlerbehandlung bei Problemen mit dem GitHub-API-Aufruf
                    if (!Directory.Exists(LogFolderPath))
                    {
                        Directory.CreateDirectory(LogFolderPath);
                    }

                    File.AppendAllText(ErrorLogFilePath, $"{DateTime.Now}: " + "Fehler bei der Suche nach Updates: " + $"{ex.Message}\n");

                    CustomMessage errorMessage = new CustomMessage();
                    SystemSounds.Exclamation.Play();
                    errorMessage.ButtonOkay.Visible = true;
                    errorMessage.ButtonOkay.Text = "OK";
                    errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                    errorMessage.IconPictureBox.IconColor = Color.Red;
                    errorMessage.LabelMessageContent.Text = $"Fehler bei der Suche nach Updates: " + $"{ex.Message}\n";
                    errorMessage.Text = "Fehler!";
                    errorMessage.ButtonNo.Visible = false;
                    errorMessage.ButtonYes.Visible = false;
                    errorMessage.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // Allgemeine Fehlerbehandlung für unerwartete Fehler
                CustomMessage popUpMessage = new CustomMessage();
                SystemSounds.Exclamation.Play();
                popUpMessage.ButtonOkay.Visible = true;
                popUpMessage.ButtonOkay.Text = "OK";
                popUpMessage.IconPictureBox.IconChar = IconChar.Xmark;
                popUpMessage.IconPictureBox.IconColor = Color.Red;
                popUpMessage.LabelMessageContent.Text = "Fehler bei der Suche nach Updates: " + ex.Message;
                popUpMessage.Text = "Fehler!";
                popUpMessage.ButtonNo.Visible = false;
                popUpMessage.ButtonYes.Visible = false;
                if (popUpMessage.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(LogFolderPath))
                    {
                        Directory.CreateDirectory(LogFolderPath);
                    }

                    File.AppendAllText(ErrorLogFilePath, $"{DateTime.Now}: " + "Fehler bei der Suche nach Updates: " + $"{ex.Message}\n");

                    CustomMessage errorMessage = new CustomMessage();
                    SystemSounds.Exclamation.Play();
                    errorMessage.ButtonOkay.Visible = true;
                    errorMessage.ButtonOkay.Text = "OK";
                    errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                    errorMessage.IconPictureBox.IconColor = Color.Red;
                    errorMessage.LabelMessageContent.Text = $"Fehler bei der Suche nach Updates: " + $"{ex.Message}\n";
                    errorMessage.Text = "Fehler!";
                    errorMessage.ButtonNo.Visible = false;
                    errorMessage.ButtonYes.Visible = false;
                    errorMessage.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Zwingt die Überprüfung auf Updates durchzuführen, ohne vorhandene Ergebnisse zu berücksichtigen.
        /// </summary>
        public static async Task ForceCheckForUpdates()
        {
            try
            {
                // Erstelle einen GitHub-Client für den Zugriff auf die GitHub-API
                var github = new GitHubClient(new ProductHeaderValue("xscr33mLabs_7D2D_Launcher"));

                string owner = "xscr33m";
                string repo = "xscr33mLabs_7D2D_Launcher";

                try
                {
                    // Hole alle Releases des Repositories
                    var releases = await github.Repository.Release.GetAll(owner, repo);

                    // Sortiere die Releases nach Veröffentlichungsdatum absteigend
                    var sortedReleases = releases.OrderByDescending(r => r.PublishedAt);

                    // Hole die aktuelle Version der Anwendung
                    Version currentVersion = Assembly.GetEntryAssembly().GetName().Version;
                    // Hole die neueste Version aus den Releases
                    Version latestVersion = new Version(sortedReleases.FirstOrDefault()?.TagName.TrimStart('v'));

                    // Vergleiche aktuelle Version mit der neuesten Version
                    if (latestVersion != null && latestVersion > currentVersion)
                    {
                        // Zeige eine Nachricht an, dass ein Update verfügbar ist
                        CustomMessage popUpMessage = new CustomMessage();
                        SystemSounds.Exclamation.Play();
                        popUpMessage.ButtonOkay.Visible = false;
                        popUpMessage.IconPictureBox.IconChar = IconChar.Warning;
                        popUpMessage.IconPictureBox.IconColor = Color.Yellow;
                        popUpMessage.LabelMessageContent.Text = "Eine neuere Version ist verfügbar! \n\nMöchtest Du sie jetzt herunterladen ?";
                        popUpMessage.Text = "Update verfügbar!";
                        popUpMessage.ButtonNo.Visible = true;
                        popUpMessage.ButtonYes.Visible = true;
                        popUpMessage.ButtonNo.Text = "Nein";
                        popUpMessage.ButtonYes.Text = "Ja";
                        DialogResult updateDialog = popUpMessage.ShowDialog();

                        // Wenn der Benutzer zustimmt, öffne die Download-URL
                        if (updateDialog == DialogResult.Yes)
                        {
                            string downloadUrl = string.Format("https://github.com/{0}/{1}/releases/download/{2}/7Days2Die_ServerLauncher.zip", owner, repo, sortedReleases.FirstOrDefault()?.TagName);
                            string changelogUrl = string.Format("https://github.com/{0}/{1}/releases/", owner, repo);

                            try
                            {
                                Process.Start(downloadUrl); // Starte den Browser zum Download
                                Process.Start(changelogUrl); // Starte den Browser zum Changelog
                            }
                            catch (Exception ex)
                            {
                                // Fehlerbehandlung, wenn der Browser nicht gestartet werden konnte
                                if (!Directory.Exists(LogFolderPath))
                                {
                                    Directory.CreateDirectory(LogFolderPath);
                                }

                                File.AppendAllText(ErrorLogFilePath, $"{DateTime.Now}: " + "Der Browser konnte nicht gestartet werden: " + $"{ex.Message}\n");

                                CustomMessage errorMessage = new CustomMessage();
                                SystemSounds.Exclamation.Play();
                                errorMessage.ButtonOkay.Visible = true;
                                errorMessage.ButtonOkay.Text = "OK";
                                errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                                errorMessage.IconPictureBox.IconColor = Color.Red;
                                errorMessage.LabelMessageContent.Text = $"Der Browser konnte nicht gestartet werden: " + $"{ex.Message}\n";
                                errorMessage.Text = "Fehler!";
                                errorMessage.ButtonNo.Visible = false;
                                errorMessage.ButtonYes.Visible = false;
                                errorMessage.ShowDialog();
                            }
                        }
                    }
                    else
                    {
                        // Informiere den Benutzer, wenn kein neues Update gefunden wurde
                        CustomMessage popUpMessage = new CustomMessage();
                        SystemSounds.Exclamation.Play();
                        popUpMessage.ButtonOkay.Visible = true;
                        popUpMessage.ButtonOkay.Text = "OK";
                        popUpMessage.IconPictureBox.IconChar = IconChar.Info;
                        popUpMessage.IconPictureBox.IconColor = Color.Blue;
                        popUpMessage.LabelMessageContent.Text = "Es wurde kein neues Update gefunden!";
                        popUpMessage.Text = "Information";
                        popUpMessage.ButtonNo.Visible = false;
                        popUpMessage.ButtonYes.Visible = false;
                        popUpMessage.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    // Fehlerbehandlung bei Problemen mit dem GitHub-API-Aufruf
                    if (!Directory.Exists(LogFolderPath))
                    {
                        Directory.CreateDirectory(LogFolderPath);
                    }

                    File.AppendAllText(ErrorLogFilePath, $"{DateTime.Now}: " + "Fehler bei der Suche nach Updates: " + $"{ex.Message}\n");

                    CustomMessage errorMessage = new CustomMessage();
                    SystemSounds.Exclamation.Play();
                    errorMessage.ButtonOkay.Visible = true;
                    errorMessage.ButtonOkay.Text = "OK";
                    errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                    errorMessage.IconPictureBox.IconColor = Color.Red;
                    errorMessage.LabelMessageContent.Text = $"Fehler bei der Suche nach Updates: " + $"{ex.Message}\n";
                    errorMessage.Text = "Fehler!";
                    errorMessage.ButtonNo.Visible = false;
                    errorMessage.ButtonYes.Visible = false;
                    errorMessage.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                // Allgemeine Fehlerbehandlung für unerwartete Fehler
                CustomMessage popUpMessage = new CustomMessage();
                SystemSounds.Exclamation.Play();
                popUpMessage.ButtonOkay.Visible = true;
                popUpMessage.ButtonOkay.Text = "OK";
                popUpMessage.IconPictureBox.IconChar = IconChar.Xmark;
                popUpMessage.IconPictureBox.IconColor = Color.Red;
                popUpMessage.LabelMessageContent.Text = "Fehler bei der Suche nach Updates: " + ex.Message;
                popUpMessage.Text = "Fehler!";
                popUpMessage.ButtonNo.Visible = false;
                popUpMessage.ButtonYes.Visible = false;
                if (popUpMessage.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(LogFolderPath))
                    {
                        Directory.CreateDirectory(LogFolderPath);
                    }

                    File.AppendAllText(ErrorLogFilePath, $"{DateTime.Now}: " + "Fehler bei der Suche nach Updates: " + $"{ex.Message}\n");

                    CustomMessage errorMessage = new CustomMessage();
                    SystemSounds.Exclamation.Play();
                    errorMessage.ButtonOkay.Visible = true;
                    errorMessage.ButtonOkay.Text = "OK";
                    errorMessage.IconPictureBox.IconChar = IconChar.Xmark;
                    errorMessage.IconPictureBox.IconColor = Color.Red;
                    errorMessage.LabelMessageContent.Text = $"Fehler bei der Suche nach Updates: " + $"{ex.Message}\n";
                    errorMessage.Text = "Fehler!";
                    errorMessage.ButtonNo.Visible = false;
                    errorMessage.ButtonYes.Visible = false;
                    errorMessage.ShowDialog();
                }
            }
        }
    }
}
