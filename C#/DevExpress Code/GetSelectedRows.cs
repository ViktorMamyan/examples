DataRow rowData;
int[] listRowList = GridView1.GetSelectedRows();
for (int i = 0; i < listRowList.Length; i++)
{
	rowData = GridView1.GetDataRow(listRowList[i]);
	CL.RemoveAll((x) => x.ID == Convert.ToInt32(rowData["ID"].ToString()));
}