using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    public partial class NewButton : Button
    {
        public NewButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (base.Enabled)
            {
                base.OnPaint(pe);
            }
            else
            {
                // Calling the base class OnPaint
                base.OnPaint(pe);
                //// Drawing the button yoursel. The background is gray
                //pe.Graphics.FillRectangle(new SolidBrush(base.BackColor), pe.ClipRectangle);
                //// Draw the line around the button
                //pe.Graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, base.Width - 1, base.Height - 1);
                //// Draw the text in the button in red
                pe.Graphics.DrawString(base.Text, base.Font,
                    new SolidBrush(base.ForeColor), (base.Width - pe.Graphics.MeasureString(base.Text, base.Font).Width) / 2, (base.Height / 2) -
                    (pe.Graphics.MeasureString(base.Text, base.Font).Height / 2));
            }
        }
    }
}
