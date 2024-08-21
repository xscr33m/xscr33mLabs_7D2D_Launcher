using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace xscr33mLabs_7D2D_Launcher._Core._Engine
{
    /// <summary>
    /// Stellt Methoden zur Überprüfung und Verwaltung von Instanzen der Anwendung bereit.
    /// </summary>
    internal class InstanceCheck
    {
        // Importiert die Funktion aus der user32.dll, um das Fenster einer Anwendung in den Vordergrund zu bringen.
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(int hWnd);

        // Importiert die Funktion aus der user32.dll, um den Sichtbarkeitsstatus eines Fensters zu ändern.
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(int hWnd, int nCmdShow);

        // Importiert die Funktion aus der user32.dll, um das Handle des aktuell im Vordergrund stehenden Fensters zu erhalten.
        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();

        // Konstante für das Fensteranzeige-Kommando "Normal".
        private const int SW_SHOWNORMAL = 1;

        /// <summary>
        /// Überprüft, ob bereits eine Instanz der Anwendung läuft. Wenn ja, bringt sie das Fenster der bestehenden Instanz in den Vordergrund.
        /// </summary>
        /// <returns>Ein <see cref="Task"/>, das den Abschluss der asynchronen Überprüfung darstellt.</returns>
        public static async Task CheckForInstance()
        {
            // Hole alle Prozesse mit dem Namen "xscr33mLabs_7D2D_Launcher".
            Process[] processes = Process.GetProcessesByName("xscr33mLabs_7D2D_Launcher");

            // Wenn mehr als eine Instanz gefunden wird
            if (processes.Length > 1)
            {
                // Durchlaufe alle gefundenen Prozesse
                for (int i = 0; i < processes.Length; i++)
                {
                    Process runningProcess = processes[i];

                    // Überprüfe, ob das Fenster der aktuellen Instanz bereits im Vordergrund ist
                    if ((int)runningProcess.MainWindowHandle == GetForegroundWindow())
                    {
                        continue;
                    }
                    else
                    {
                        // Zeige das Fenster der vorhandenen Instanz und bringe es in den Vordergrund
                        ShowWindow((int)runningProcess.MainWindowHandle, SW_SHOWNORMAL);
                        SetForegroundWindow((int)runningProcess.MainWindowHandle);

                        // Beende die aktuelle Anwendung
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }

            // Warte kurz, bevor die Methode abgeschlossen wird
            await Task.Delay(200);
        }
    }
}
