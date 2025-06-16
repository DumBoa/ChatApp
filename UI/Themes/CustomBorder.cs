using System.Drawing.Drawing2D;
namespace Themes
{
    internal class CustomBorder
    {
        public void SetRoundedCornersPanel(Panel panel, int borderRadius)
        {
            if (borderRadius <= 0)
            {
                panel.Region = null;
                return;
            }

            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle bounds = panel.ClientRectangle;
                path.AddArc(bounds.X, bounds.Y, borderRadius, borderRadius, 180, 90); // Top-left
                path.AddArc(bounds.Right - borderRadius, bounds.Y, borderRadius, borderRadius, 270, 90); // Top-right
                path.AddArc(bounds.Right - borderRadius, bounds.Bottom - borderRadius, borderRadius, borderRadius, 0, 90); // Bottom-right
                path.AddArc(bounds.X, bounds.Bottom - borderRadius, borderRadius, borderRadius, 90, 90); // Bottom-left
                path.CloseAllFigures();

                panel.Region = new Region(path);
            }
        }

        public void SetRoundedCornersText(TextBox text, int textRadius)
        {
            if(textRadius <= 0)
            {
                text.Region = null;
                return;
            }
            int borderRadius = 20;
            using (Graphics gr = text.CreateGraphics())
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle bounds = text.ClientRectangle;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(bounds.X, bounds.Y, borderRadius, borderRadius, 180, 90);
                    path.AddArc(bounds.Right - borderRadius, bounds.Y, borderRadius, borderRadius, 270, 90);
                    path.AddArc(bounds.Right - borderRadius, bounds.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
                    path.AddArc(bounds.X, bounds.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
                    path.CloseAllFigures();
                    text.Region = new Region(path);
                }
            }
        }

        public void SetRoundedCornersButton(Button button, int buttonRadius)
        {
            if (buttonRadius <= 0)
            {
                button.Region = null;
                return;
            }

            Rectangle bounds = button.ClientRectangle;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, buttonRadius, buttonRadius, 180, 90);
                path.AddArc(bounds.Right - buttonRadius, bounds.Y, buttonRadius, buttonRadius, 270, 90);
                path.AddArc(bounds.Right - buttonRadius, bounds.Bottom - buttonRadius, buttonRadius, buttonRadius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - buttonRadius, buttonRadius, buttonRadius, 90, 90);
                path.CloseAllFigures();
                button.Region = new Region(path);
            }
        }

    }
}
