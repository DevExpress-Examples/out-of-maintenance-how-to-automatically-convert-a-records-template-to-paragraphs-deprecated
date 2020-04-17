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

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.Snap.Core.API

Namespace AsParagraphs
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
			AddDataSource()
			SubscribeEvents()
		End Sub

		Private dataFields As List(Of DataFieldInfo)

		Private Sub snapControl1_DocumentLoaded(ByVal sender As Object, ByVal e As EventArgs) Handles snapControl1.DocumentLoaded
			SubscribeEvents()
		End Sub

		Private Sub SubscribeEvents()
			AddHandler snapControl1.Document.BeforeInsertSnList, AddressOf Document_BeforeInsertSnList
			AddHandler snapControl1.Document.PrepareSnList, AddressOf Document_PrepareSnList
		End Sub

		Private Sub AddDataSource()
			snapControl1.Document.DataSource = New List(Of SampleTestObject)() From {
				New SampleTestObject() With {
					.ID = 1,
					.Name = "Apple",
					.Color = "Green"
				},
				New SampleTestObject() With {
					.ID = 2,
					.Name = "Banana",
					.Color = "Yellow"
				},
				New SampleTestObject() With {
					.ID = 3,
					.Name = "Strawberry",
					.Color = "Red"
				}
			}
		End Sub

		Private Sub Document_BeforeInsertSnList(ByVal sender As Object, ByVal e As BeforeInsertSnListEventArgs)
			Me.dataFields = e.DataFields
		End Sub

		Private Sub Document_PrepareSnList(ByVal sender As Object, ByVal e As PrepareSnListEventArgs)
			For Each field In e.Template.Fields
				Dim list As SnapList = TryCast(e.Template.ParseField(field), SnapList)
				If Object.ReferenceEquals(list, Nothing) Then
					Continue For
				End If
				list.BeginUpdate()
				list.ListHeader.Delete(list.ListHeader.Range)
				Dim template As SnapDocument = list.RowTemplate
				template.Delete(template.Range)
				For Each dataField As DataFieldInfo In Me.dataFields
					template.AppendText(String.Format("{0} = ", dataField.DisplayName))
					template.CreateSnText(template.Range.End, dataField.DataPaths(dataField.DataPaths.Length - 1))
					template.Paragraphs.Append()
				Next dataField
				template.Paragraphs.Append()
				list.EndUpdate()
				Exit For
			Next field
			Me.dataFields = Nothing
		End Sub
	End Class

	Public Class SampleTestObject
		Public Property ID() As Integer
		Public Property Name() As String
		Public Property Color() As String


	End Class
End Namespace
