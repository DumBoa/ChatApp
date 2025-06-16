using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Themes
{
    internal class CustomWindow
    {
     
            [DllImport("user32.dll")]
            private static extern bool ReleaseCapture();

            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

            private const int WM_NCLBUTTONDOWN = 0xA1;
            private const int HT_CAPTION = 0x2;

            public void EnableDrag(Form targetForm)
            {
                targetForm.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        ReleaseCapture();
                        SendMessage(targetForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                    }
                };
            }
        public void ApplyRoundedRegion(Form targetForm, int cornerRadius)
        {
            if (targetForm == null || cornerRadius <= 0)
                return;

            Rectangle bounds = targetForm.ClientRectangle;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90); // Top-left
                path.AddArc(bounds.Width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90); // Top-right
                path.AddArc(bounds.Width - cornerRadius * 2, bounds.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90); // Bottom-right
                path.AddArc(0, bounds.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90); // Bottom-left
                path.CloseFigure();

                targetForm.Region = new Region(path);
            }
        }
    }

}
