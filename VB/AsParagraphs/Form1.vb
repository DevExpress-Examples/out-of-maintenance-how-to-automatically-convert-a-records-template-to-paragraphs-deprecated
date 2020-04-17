Imports Microsoft.VisualBasic
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
			snapControl1.Document.DataSource = New List(Of SampleTestObject) (New SampleTestObject() {New SampleTestObject() With {.ID = 1, .Name = "Apple", .Color = "Green"}, New SampleTestObject() With {.ID = 2, .Name = "Banana", .Color = "Yellow"}, New SampleTestObject() With {.ID = 3, .Name = "Strawberry", .Color = "Red"}})
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
		Private privateID As Integer
		Public Property ID() As Integer
			Get
				Return privateID
			End Get
			Set(ByVal value As Integer)
				privateID = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateColor As String
		Public Property Color() As String
			Get
				Return privateColor
			End Get
			Set(ByVal value As String)
				privateColor = value
			End Set
		End Property


	End Class
End Namespace
