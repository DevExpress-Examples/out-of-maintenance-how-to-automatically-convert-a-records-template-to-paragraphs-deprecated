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
Imports System.Windows.Forms

Namespace AsParagraphs

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call Application.Run(New Form1())
        End Sub
    End Module
End Namespace
