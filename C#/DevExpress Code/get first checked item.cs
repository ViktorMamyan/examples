int ID = Convert.ToInt32(GridView1.GetDataRow(GridView1.GetSelectedRows()[0]).ItemArray[0]);
string Name = GridView1.GetDataRow(GridView1.GetSelectedRows()[0]).ItemArray[1].ToString();

DateTime? BirdDate = (GridView1.GetDataRow(GridView1.GetSelectedRows()[0]).ItemArray[3] == DBNull.Value)
	? (DateTime?)null
	: ((DateTime)GridView1.GetDataRow(GridView1.GetSelectedRows()[0]).ItemArray[3]);