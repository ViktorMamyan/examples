private void GridView1_RowStyle(object sender, RowStyleEventArgs e)
{
	try
	{
		GridView View = (GridView)sender;
		if (e.RowHandle >= 0)
		{
			string R = View.GetRowCellDisplayText(e.RowHandle, View.Columns["IsActive"]);
			if (R == "Checked")
			{
				e.Appearance.BackColor = Color.FromArgb(255, 153, 153); //Color.Salmon
				e.Appearance.BackColor2 = Color.White; //Color.SeaShell
			}
		}
	}
	catch (Exception)
	{
	}
}