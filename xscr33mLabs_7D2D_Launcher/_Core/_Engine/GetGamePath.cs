using System.IO;

namespace xscr33mLabs_7D2D_Launcher._Core._Engine
{
    /// <summary>
    /// Stellt Methoden zum Überprüfen der Standardverzeichnisse für das Spiel bereit.
    /// </summary>
    public static class GetGamePath
    {
        // Eine Liste von möglichen Verzeichnissen, in denen sich die Spieldatei befinden könnte.
        private static readonly string[] possibleDirectories = new string[]
        {
            @"C:\Program Files (x86)\Steam\steamapps\common\7 Days To Die\7DaysToDie.exe",
            @"D:\SteamLibrary\steamapps\common\7 Days To Die\7DaysToDie.exe",
            @"E:\SteamLibrary\steamapps\common\7 Days To Die\7DaysToDie.exe",
            @"F:\SteamLibrary\steamapps\common\7 Days To Die\7DaysToDie.exe",
            @"G:\SteamLibrary\steamapps\common\7 Days To Die\7DaysToDie.exe",
            @"H:\SteamLibrary\steamapps\common\7 Days To Die\7DaysToDie.exe",
            @"I:\SteamLibrary\steamapps\common\7 Days To Die\7DaysToDie.exe",
            @"J:\SteamLibrary\steamapps\common\7 Days To Die\7DaysToDie.exe"
        };

        /// <summary>
        /// Überprüft, ob die Datei des Spiels in einem der möglichen Verzeichnisse vorhanden ist.
        /// </summary>
        /// <param name="gamePath">Der Pfad zur Spieldatei, wenn sie gefunden wird. Andernfalls ein leerer String.</param>
        /// <returns>Wahr, wenn die Spieldatei gefunden wurde; andernfalls falsch.</returns>
        public static bool CheckDefaultGamePath(out string gamePath)
        {
            // Durchlaufe alle möglichen Verzeichnisse, um die Spieldatei zu finden.
            foreach (var path in possibleDirectories)
            {
                // Überprüfe, ob die Datei am angegebenen Pfad existiert
                if (File.Exists(path))
                {
                    gamePath = path;
                    return true;
                }
            }

            // Wenn keine der Dateien gefunden wurde, setze gamePath auf einen leeren String und gebe false zurück
            gamePath = string.Empty;
            return false;
        }
    }
}
