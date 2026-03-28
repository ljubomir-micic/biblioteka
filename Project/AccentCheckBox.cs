////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using TAC = System.Boolean;
using DUZINA = System.Int32;

namespace Project
{
    // USEIN: Saveti.cs
	public class AccentCheckBox : CheckBox
	{
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.Clear(this.Parent.BackColor);
        }
    }
}
