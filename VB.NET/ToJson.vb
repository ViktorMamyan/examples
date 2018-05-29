Imports Newtonsoft.Json

Friend Function ToJson(O As Object) As String
	Dim json As String = JsonConvert.SerializeObject(O, Formatting.Indented)
	Return json
End Function