Dim req As WebRequest = WebRequest.Create("https://www.crowdsurge.com/store/index.php?storeid=1056&menu=detail&eventid=41815")
Dim doc As New HtmlDocument()
Using res As WebResponse = req.GetResponse()
    doc.Load(res.GetResponseStream())
End Using

Dim nodes = doc.DocumentNode.SelectNodes("//div[@class='ei_value ei_date']")
If nodes IsNot Nothing Then
    For Each var node in nodes
        MsgBox(node.InnerText)
    Next
End IF