private void GetPosibleLineCountsInReachTextBox()
{
	SizeF s = TextRenderer.MeasureText("A", richTextBox1.Font, richTextBox1.Size, TextFormatFlags.WordBreak);
	int letterHeight = Convert.ToInt32(s.Height);
	int displayableLines = richTextBox1.Height / letterHeight;

	this.Text = Convert.ToString(displayableLines);
}