<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128608547/20.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4903)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to automatically convert a record's template to paragraphs when a field is inserted into a report

> **Note**
>
> As you may already know, the [WinForms Snap control](https://docs.devexpress.com/WindowsForms/11373/controls-and-libraries/snap) and [Snap Report API](https://docs.devexpress.com/OfficeFileAPI/15188/snap-report-api) are now in maintenance support mode. No new features or capabilities are incorporated into these products. We recommend that you use [DevExpress Reporting](https://docs.devexpress.com/XtraReports/2162/reporting) tool to generate, edit, print, and export your business reports/documents.

<p>This example demonstrates how the default record template (Table) can be converted to paragraphs automatically when a field is dragged and dropped from the Data Explorer.</p><p>In this example, this functionality is implemented in the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressSnapCoreAPISnapDocument_PrepareSnListtopic">SnapDocument.PrepareSnList</a> event handler.</p>

<br/>


