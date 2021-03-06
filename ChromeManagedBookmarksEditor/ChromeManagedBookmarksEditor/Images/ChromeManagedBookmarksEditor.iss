; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "ChromeManagedBookmarksEditor"
#define MyAppVersion "1.0"
#define MyAppPublisher "Northland Controls"
#define MyAppURL "http://www.northlandcontrols.com/"
#define MyAppExeName "ChromeManagedBookmarksEditor.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{FEEC5CFD-AC85-4B79-92F3-B3B6863E0D00}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
OutputDir=C:\Users\tsobieroy\Documents\Output
OutputBaseFilename=ChromeManagedBookmarksEditor
SetupIconFile=C:\Users\tsobieroy\source\repos\ChromeManagedBookMarksEditor\ChromeManagedBookmarksEditor\ChromeManagedBookmarksEditor\Images\chrome-logo.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\tsobieroy\Downloads\New folder\ChromeManagedBookmarksEditor.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\tsobieroy\Downloads\New folder\ChromeManagedBookmarksEditor.application"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\tsobieroy\Downloads\New folder\ChromeManagedBookmarksEditor.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\tsobieroy\Downloads\New folder\ChromeManagedBookmarksEditor.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\tsobieroy\Downloads\New folder\ChromeManagedBookmarksEditor.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\tsobieroy\Downloads\New folder\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\tsobieroy\Downloads\New folder\Newtonsoft.Json.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\tsobieroy\Downloads\New folder\WpfAnimatedGif.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\tsobieroy\Downloads\New folder\WpfAnimatedGif.xml"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

