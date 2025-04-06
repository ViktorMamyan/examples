const int WM_NCHITTEST = 0x84;
const int HTCLIENT = 1;
const int HTCAPTION = 2;

protected override void WndProc(ref Message m)
{
    base.WndProc(ref m);

    switch (m.Msg)
    {
        case WM_NCHITTEST:
            {
                if (m.Result == (IntPtr)HTCLIENT)
                    m.Result = (IntPtr)HTCAPTION;
                break;
            }
    }
}
protected override CreateParams CreateParams
{
    get
    {
        CreateParams cp = base.CreateParams;
        cp.Style = cp.Style | 0x40000;
        return cp;
    }
}

private void Form2_Load(object sender, EventArgs e)
{
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
}