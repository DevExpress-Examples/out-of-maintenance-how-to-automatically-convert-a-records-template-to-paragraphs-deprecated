' Developer Express Code Central Example:
' How to automatically convert a record's template to paragraphs when a field is inserted into a report
' 
' This example demonstrates how the default record template (Table) can be
' converted to paragraphs automatically when a field is dragged and dropped from
' the Data Explorer.
' In this example, this functionality is implemented in the
' SnapDocument.PrepareSnList
' (http://documentation.devexpress.com/#WindowsForms/DevExpressSnapCoreAPISnapDocument_PrepareSnListtopic)
' event handler.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4903


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace AsParagraphs
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace
