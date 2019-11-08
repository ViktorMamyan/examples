            DataSet ds = new DataSet();
            ds.ReadXml(@"C:\Seychelles-EURO-rates.xml");

            foreach (DataTable item in ds.Tables)
            {
                richTextBox1.Text += item.TableName + Environment.NewLine;
                richTextBox1.Text += Environment.NewLine;
                
                foreach (DataColumn c in item.Columns)
                {
                    richTextBox1.Text += c.ColumnName.ToString() + Environment.NewLine;
                }

                richTextBox1.Text += "---------------" + Environment.NewLine;
            }