#Application CustomizeExportAction.Win
#Application CustomizeExportAction.Web



*Action Navigation(Contact)
*Action Export to(Text File)

#IfDef CustomizeExportAction.Win
*CheckFieldValues
 File name: = Contact_06.25.12
#EndIf

*FillForm
 File name: = C:\Contact_06.25.12

*Action Save

*Sleep 500

#IfDef CustomizeExportAction.Win
*HandleDialog
 Respond = Yes

*Sleep 500

*HandleDialog
 Respond = No

*Sleep 500
#EndIf


*CheckFileExists C:\Contact_06.25.12.txt
*DeleteFile C:\Contact_06.25.12.txt