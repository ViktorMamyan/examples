richTextBox1.Invoke(new Action(() => richTextBox1.Text=string.Empty));
richTextBox1.Invoke(new Action(() => richTextBox1.Text= stringBuilder.ToString()));
richTextBox1.Invoke(new Action(() => richTextBox1.Select(0, 0)));