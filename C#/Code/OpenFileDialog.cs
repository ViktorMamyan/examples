internal class Helper
{
	//show open file dialog and return selected file path
	internal string RetrieveFilePath()
	{
		OpenFileDialog fd = new OpenFileDialog { Multiselect = false };
		DialogResult result = fd.ShowDialog();

		if (result != DialogResult.OK || String.IsNullOrEmpty(fd.FileName))
		{
			return null;
		}
		else
		{
			return @fd.FileName;
		}
	}
}

//usage
Helper helper = new Helper();
string filePath = String.Empty;
filePath = helper.RetrieveFilePath();
if (filePath == null) { return; }