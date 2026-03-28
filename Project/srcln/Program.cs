////////////////////////////////////////////////////////////
//
//    Библиотека: Line Counter
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System.Linq;

int totalNumOfLines = 0;
// Umesto /Users/ljubomir/Library/Mobile Documents/com~apple~CloudDocs/Documents/Гимназија/Project/Project relativnu adrsu
string[] fileNames = System.IO.Directory.GetFiles(@"../");
if (System.IO.File.Exists(@"srcln.txt")) System.IO.File.Delete(@"srcln.txt");
foreach (var file in fileNames) if (file.EndsWith(".cs")) {
    int numOfLines = 0;
    using (System.IO.StreamReader sr = new System.IO.StreamReader(file)) {
        while(!sr.EndOfStream) {
            sr.ReadLine();
            numOfLines++;
        }
    }

    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"srcln.txt", true)) {
        sw.WriteLine(file);
        sw.WriteLine("Broj linija:\t" + numOfLines);
        sw.WriteLine("--------------------------------------------");
        totalNumOfLines += numOfLines;
    }
}

using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"srcln.txt", true)) {
    sw.WriteLine("UKUPNO");
    sw.WriteLine("Broj linija:\t" + totalNumOfLines);
}
