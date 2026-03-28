////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace Project
{
	public partial class Form1 : Form
	{
		void KnjigaSeBrise(object sender, EventArgs e) {
			KnjigaInfoUI knjigaInfoUI = (KnjigaInfoUI) sender;

			if (this.postavljaSigurnosnoPitanje) if (MessageBox.Show("Брисање књиге је радња неповратног карактера.\nЈесте ли сигурни да желите да наставите?", "Библиотека: Потврда брисања", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

			// DONE: Izbrisati knjigu iz MenazdmentPodataka
			int idknjige = knjigaInfoUI.id;
			for (int i = 0; i < Knjige.Count; i++) if (Knjige[i].preuzmiID() == idknjige) {
				Knjige.RemoveAt(i);
				this.knjigaInfoUI.RemoveAt(i);
			}
			
			// DONE: Sacuvati izmene
			MenadzmentPodataka.knjigaPodaciCuvanje(Knjige, "knjige");
			
			// DONE: Obrisati knjigaInfoUI komponentu
			knjigaInfoUI.Dispose();
			
			// DONE: Izmeniti redosled knjiga
			for (int i = 0; i < this.knjigaInfoUI.Count; i ++) {
				this.knjigaInfoUI[i].Visible = true;
				IzmenaRedosledaKomponente<KnjigaInfoUI>(this.knjigaInfoUI, i, i);
			}
		}
        
        void AutorSeBrise(object sender, EventArgs e) {
			AutorUI autorUI = (AutorUI) sender;

			if (MessageBox.Show("Брисање аутора је радња неповратног карактера. Свака књига повезана са овим аутором ће такође бити обрисана.\nЈесте ли сигурни да желите да наставите?", "Библиотека: Потврда брисања", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

			this.postavljaSigurnosnoPitanje = false;
			int idautor = autorUI.id;
			
			// DONE: Ne brisu se sve autorove knjige
			{
				KnjigaInfoUI[] knjigaInfoUI1 = new KnjigaInfoUI[0];
				
				foreach (KnjigaInfoUI knjigaInfoUI in this.knjigaInfoUI) {
					Knjiga knjiga = Knjige.Find(x => x.preuzmiID() == knjigaInfoUI.id);

					if (knjiga.preuzmiIDAutora() == idautor) {
						Array.Resize(ref knjigaInfoUI1, knjigaInfoUI1.Length + 1);
						knjigaInfoUI1[knjigaInfoUI1.Length - 1] = knjigaInfoUI;
					}
				}
			
				foreach (var knjigaInfoUI in knjigaInfoUI1) {
					KnjigaSeBrise(knjigaInfoUI, e);
				}
			}
			
			this.postavljaSigurnosnoPitanje = true;
			
			for (int i = 0; i < Autori.Count; i++) if (Autori[i].preuzmiID() == idautor) {
				Autori.RemoveAt(i);
				this.autorUI.RemoveAt(i);
			}

			MenadzmentPodataka.autorPodaciCuvanje(Autori, "autori");

			autorUI.Dispose();

			for (int i = 0; i < this.autorUI.Count; i++) {
				this.autorUI[i].Visible = true;
				IzmenaRedosledaKomponente<AutorUI>(this.autorUI, i, i);
			}
		}

		void IzdavacSeBrise(object sender, EventArgs e) {
			// DONE: Proveriti sintaksu
			IzdavacUI izdavacUI = (IzdavacUI) sender;

			if (MessageBox.Show("Брисање издавача је радња неповратног карактера. Свака књига повезана са овим издавачем ће такође бити обрисана.\nЈесте ли сигурни да желите да наставите?", "Библиотека: Потврда брисања", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

			this.postavljaSigurnosnoPitanje = false;
			int idizdavac = izdavacUI.id;
			
			{
				KnjigaInfoUI[] knjigaInfoUI1 = new KnjigaInfoUI[0];
				
				foreach (KnjigaInfoUI knjigaInfoUI in this.knjigaInfoUI) {
					Knjiga knjiga = Knjige.Find(x => x.preuzmiID() == knjigaInfoUI.id);

					if (knjiga.preuzmiIDIzdavaca() == idizdavac) {
						Array.Resize(ref knjigaInfoUI1, knjigaInfoUI1.Length + 1);
						knjigaInfoUI1[knjigaInfoUI1.Length - 1] = knjigaInfoUI;
					}
				}
			
				foreach (var knjigaInfoUI in knjigaInfoUI1) {
					KnjigaSeBrise(knjigaInfoUI, e);
				}
			}
			
			this.postavljaSigurnosnoPitanje = true;
			
			for (int i = 0; i < Izdavaci.Count; i++) if (Izdavaci[i].preuzmiID() == idizdavac) {
				Izdavaci.RemoveAt(i);
				this.izdavacUI.RemoveAt(i);
			}

			MenadzmentPodataka.izdavacPodaciCuvanje(Izdavaci, "izdavaci");

			izdavacUI.Dispose();

			for (int i = 0; i < this.izdavacUI.Count; i++) {
				this.izdavacUI[i].Visible = true;
				IzmenaRedosledaKomponente<IzdavacUI>(this.izdavacUI, i, i);
			}
		}

    }
}