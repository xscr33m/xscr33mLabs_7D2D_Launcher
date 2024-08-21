namespace xscr33mLabs_7D2D_Launcher._Core._Engine
{
    /// <summary>
    /// Stellt Methoden zum Speichern und Laden von Verbindungsdaten bereit.
    /// Diese Daten werden in den Anwendungseinstellungen gespeichert.
    /// </summary>
    internal class ConnectionData
    {
        /// <summary>
        /// Speichert die Verbindungsdaten in den Anwendungseinstellungen.
        /// </summary>
        /// <param name="serverIP">Die IP-Adresse des Servers.</param>
        /// <param name="serverPort">Der Port des Servers.</param>
        /// <param name="gamePath">Der Pfad zum Spiel.</param>
        /// <param name="serverPass">Das Passwort für den Server.</param>
        public static void SaveConnectionData(string serverIP, string serverPort, string gamePath, string serverPass)
        {
            // Setze die Werte in den Anwendungseinstellungen
            Properties.Settings.Default.ServerIP = serverIP;
            Properties.Settings.Default.ServerPort = serverPort;
            Properties.Settings.Default.GamePath = gamePath;
            Properties.Settings.Default.ServerPass = serverPass;

            // Speichere die Änderungen an den Anwendungseinstellungen
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Lädt die gespeicherten Verbindungsdaten aus den Anwendungseinstellungen.
        /// </summary>
        /// <param name="serverIP">Die IP-Adresse des Servers.</param>
        /// <param name="serverPort">Der Port des Servers.</param>
        /// <param name="gamePath">Der Pfad zum Spiel.</param>
        /// <param name="serverPass">Das Passwort für den Server.</param>
        public static void LoadConnectionData(out string serverIP, out string serverPort, out string gamePath, out string serverPass)
        {
            // Hole die Werte aus den Anwendungseinstellungen
            serverIP = Properties.Settings.Default.ServerIP;
            serverPort = Properties.Settings.Default.ServerPort;
            gamePath = Properties.Settings.Default.GamePath;
            serverPass = Properties.Settings.Default.ServerPass;
        }
    }
}
