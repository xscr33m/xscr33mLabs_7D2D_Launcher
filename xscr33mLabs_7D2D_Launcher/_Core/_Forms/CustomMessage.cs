using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace xscr33mLabs_7D2D_Launcher._Core._Forms
{
    public partial class CustomMessage : Form
    {
        public CustomMessage()
        {
            InitializeComponent();
        }

        // --- Black TitleBar --- //
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
    }
}
