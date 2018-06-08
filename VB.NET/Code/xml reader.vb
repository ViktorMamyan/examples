Imports System.Xml
Imports System.IO

Module Module1

    Sub Main()

        Dim xmlString As String = "<?xml version=""1.0"" encoding=""UTF-8"" ?><XML><Header Version=""1.0""><SomeTag>455654</SomeTag><Response>OK</Response><SID>Some SID</SID></Header></XML>"

        ' Create an XmlReader
        Using reader As XmlReader = XmlReader.Create(New StringReader(xmlString))

            reader.ReadToFollowing("Header")
            reader.MoveToFirstAttribute()

            Dim Header As String = reader.Value
            Console.WriteLine("Header= " + Header)

            reader.ReadToFollowing("SomeTag")
            Console.WriteLine("SomeTag=" + reader.ReadElementContentAsString())

            'reader.ReadToFollowing("Response")
            Console.WriteLine("Response=" + reader.ReadElementContentAsString)

            'reader.ReadToFollowing("SID")
            Console.WriteLine("SID=" + reader.ReadElementContentAsString)

        End Using

        Console.ReadKey()

    End Sub

End Module