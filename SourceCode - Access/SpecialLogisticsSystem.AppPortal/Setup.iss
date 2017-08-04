; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "易运专线物流系统"
#define MyAppVersion "1.5"
#define MyAppPublisher "易运科技"
#define MyAppURL "http://www.elwst.com/"
#define MyAppExeName "MyProg.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{DB36052B-632B-4EB2-A948-8BC5B29E143C}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\inetpub\wwwroot\SpecialLogisticsSystem
DefaultGroupName={#MyAppName}
OutputBaseFilename=setup
SetupIconFile=E:\SpecialLogisticsSystem\SourceCode\SpecialLogisticsSystem.AppPortal\favicon.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "chinese"; MessagesFile: "compiler:Languages\ChineseSimp.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: no; Description: 否; GroupDescription: 是否安装增强插件（百度搜霸、多多表情、中文上网）; Flags: exclusive unchecked

[Code]
const
SQLServerName = '.';
SQLDMOGrowth_MB = 0;
IISServerName = 'localhost';
IISServerNumber = '678';

var
selectIisSqlPage: TInputOptionWizardPage;
inputPortPage : TInputQueryWizardPage;
//createIISPage : TOutputMsgWizardPage;
 procedure iisButtonOnClick(Sender: TObject);
begin

if MsgBox('系统将要在IIS上面创建WEB站点,要继续吗?', mbInformation, mb_YesNo) = idNo then
    Exit;
end;

procedure sqlButtonOnClick(Sender: TObject);
begin
MsgBox('This demo shows some features of the WizardForm object and the various VCL classes.', mbInformation, mb_Ok);
end;

procedure CreateData(Sender: TObject);
var
  SQLServer, Database, DBFile, LogFile: Variant;
  ResultStr,oRestore,db_path: Variant;
begin
  try
    SQLServer := CreateOleObject('SQLDMO.SQLServer');
  except
    RaiseException('请您先安装sql server2008.'#13#13'(错误''' + GetExceptionMessage + ''' 退出)');
  end;
  { Connect to the Microsoft SQL Server }
  SQLServer.LoginSecure := True;
  SQLServer.Connect(SQLServerName);
    try
      SQLServer.Databases.Break('councildb');
      SQLServer.Databases.Remove('councildb');
      except
    end;
    try

      oRestore := CreateOleObject('SQLDMO.Restore');      //创建还原对象
      oRestore.Database := 'LogisticsManagement';          //还原的数据库名称
      db_path:=expandConstant('E:\SpecialLogisticsSystem\DataBase\');          //备份文件的路径
      MsgBox(db_path,mbinformation,mb_ok);            //测试一下看路径对不对
      oRestore.files :=db_path;              //指定备份文件
      oRestore.replacedatabase := true;
      oRestore.sqlrestore(sqlserver);      //执行还原操作
      MsgBox('数据库还原成功!',mbinformation,mb_ok);
    except
      MsgBox('数据库还原失败!,请重试或查阅帮助文档进行手动配置!',mbinformation,mb_ok);
    end;
end;

function NextButtonClick(CurPageID: Integer): Boolean;
var
//I: Integer;
IIS, WebSite, WebServer, WebFilters , WebRoot: Variant;
randNum,ErrorCode: Integer;

begin
{ 当选择创建站点时执行动作 }
if CurPageID = inputPortPage.ID then begin

    if selectIisSqlPage.SelectedValueIndex = 0 then
      begin
        //MsgBox(inputPortPage.Values[0], mbError, MB_OK);
        //MsgBox(WizardDirValue, mbError, MB_OK);
        {---开始创建IIS站点---}
        try
          IIS :=CreateOleObject('IISNamespace');
        except
          RaiseException('请先安装IIS！.(Error ''' + GetExceptionMessage + ''' occurred)');
        end;

        WebSite := IIS.GetObject('IIsWebService', GetComputerNameString() + '/w3svc');

        //Randomize;
        randNum := 100+Random(900);

        try

          WebServer := WebSite.Create('IIsWebServer',inttostr(randNum));
          WebServer.ServerComment := 'szts';
          WebServer.AuthFlags := '0';
          WebServer.LogPluginClsid := '{FF160663-DE82-11CF-BC0A-00AA006111E0}';
          WebServer.ServerAutoStart := 'TRUE';
          WebServer.Serverbindings := ':' + inputPortPage.Values[0] + ':';
          WebServer.defaultDoc := 'index.htm,index.html,index.asp,Default.htm,Default.asp,Default.aspx,admin.asp,login.asp,admin_login.asp,admins_login.asp';
          WebServer.SetInfo();

          WebServer := WebSite.GetObject('IIsWebServer', inttostr(randNum));
          WebFilters := WebServer.Create('IIsFilters', 'filters');
          WebFilters.SetInfo();

          WebServer := WebSite.GetObject('IIsWebServer', inttostr(randNum));
          WebRoot := WebServer.Create('IIsWebVirtualDir', 'Root');
          WebRoot.Path := WizardDirValue;
          WebRoot.AccessSource :=    TRUE;
          WebRoot.AccessScript :=    TRUE;
          WebRoot.AccessExecute := False;
          WebRoot.AccessRead :=    TRUE;
          WebRoot.AppFriendlyName := '默认应用程序';
          WebRoot.AppIsolated := '2';
          WebRoot.AppRoot := '/LM/W3SVC/' + inttostr(randNum) + '/Root';
          WebRoot.AuthAnonymous := TRUE;
          WebRoot.AuthNTLM := TRUE;
          WebRoot.EnableDirBrowsing := TRUE;
          WebRoot.DirBrowseShowDate := TRUE;
          WebRoot.DirBrowseShowTime := TRUE;
          WebRoot.DirBrowseShowSize := TRUE;
          WebRoot.DirBrowseShowExtension := TRUE;
          WebRoot.DirBrowseShowLongDate := TRUE;
          WebRoot.EnableDefaultDoc := TRUE;
          WebRoot.SetInfo();

          {---创建后测试----}
          if MsgBox('站点创建成功,是否需要查看测试页面？', mbInformation, mb_YesNo) = idYes then
            begin
              ShellExec('open', 'http://localhost:' + inputPortPage.Values[0] + '/Default.aspx', '', '', SW_SHOWNORMAL, ewNoWait, ErrorCode)
            end;

        except

            if MsgBox('站点创建失败，请检查端口是否占用,要继续创建吗?', mbInformation, mb_YesNo) = idYes then
               begin
                Result := False;
                exit;
               end ;
        end; {end try}

      end; {end if selectIisSqlPage.SelectedValueIndex = 0 then}

end;
Result := True;
end;

function ShouldSkipPage(PageID: Integer): Boolean;
begin
{ 判断是否跳转 }
//MsgBox(inttostr(selectIisSqlPage.SelectedValueIndex), mbInformation, mb_Ok);
if (PageID = inputPortPage.ID) and (selectIisSqlPage.SelectedValueIndex = -1) then
    Result := True
//else if (PageID = createIISPage.ID) and (selectIisSqlPage.SelectedValueIndex = -1) then
// Result := True
else
    Result := False;
end;

procedure URLLabelOnClick(Sender: TObject);
var
   ErrorCode: Integer;
begin
   ShellExec('open', 'http://www.ewlxt.com/','','', SW_SHOWNORMAL, ewNoWait, ErrorCode);
end;

procedure AboutButtonOnClick(Sender: TObject);
begin
   MsgBox('易运专线物流系统 易运科技有限公司版权所有 (C)  All Rights Reserved.', mbInformation, MB_OK);
end;

var
AboutButton, CancelButton: TButton;
URLLabel: TNewStaticText;

procedure InitializeWizard();
begin
   { Create the pages }
WizardForm.PAGENAMELABEL.Font.Color:= clred;
WizardForm.PAGEDESCRIPTIONLABEL.Font.Color:= clBlue;
WizardForm.WELCOMELABEL1.Font.Color:= clGreen;
WizardForm.WELCOMELABEL2.Font.Color:= clblack;

CancelButton := WizardForm.CancelButton;
    AboutButton := TButton.Create(WizardForm);
    AboutButton.Left := WizardForm.ClientWidth - CancelButton.Left - CancelButton.Width;
    AboutButton.Top := CancelButton.Top;
    AboutButton.Width := CancelButton.Width;
    AboutButton.Height := CancelButton.Height;
    AboutButton.Caption := '&关于';
    AboutButton.OnClick := @AboutButtonOnClick;
    AboutButton.Parent := WizardForm;

   URLLabel := TNewStaticText.Create(WizardForm);
URLLabel.Caption := '访问www.ewlxt.com';
URLLabel.Cursor := crHand;
URLLabel.OnClick := @URLLabelOnClick;
URLLabel.Parent := WizardForm;
{ Alter Font *after* setting Parent so the correct defaults are inherited first }
URLLabel.Font.Style := URLLabel.Font.Style + [fsUnderline];
URLLabel.Font.Color := clBlue;
URLLabel.Top := AboutButton.Top + AboutButton.Height - URLLabel.Height - 2;
URLLabel.Left := AboutButton.Left + AboutButton.Width + ScaleX(20);
{ 创建安装IIS及数据库页面 }

selectIisSqlPage := CreateInputOptionPage(wpInstalling,
     '执行安装后任务', '是否在此创建站点?',
    '您可以在程序安装完成后手动创建站点,但是推荐在此创建,否则请点击下一步',
    False, False);
selectIisSqlPage.Add('创建WEB站点');


inputPortPage := CreateInputQueryPage(selectIisSqlPage.ID,
    '创建WEB站点', '请录入创建WEB站点端口',
    '请录入创建WEB站点端口,IP地址默认为localhost，请确认端口未被占用,点击下一步继续');
inputPortPage.Add('iisport:', False);

inputPortPage.Values[0] := '8080';
end;


[Files]
;Source: "C:\Program Files\Inno Setup 5\Examples\MyProg.exe"; DestDir: "{app}"; Flags: ignoreversion
;Source: "E:\SpecialLogisticsSystem\SourceCode\SpecialLogisticsSystem.AppPortal\Documents\ChromeStandaloneSetup.exe"; DestDir: "{app}"; Flags: ignoreversion
;Source: "E:\SpecialLogisticsSystem\SourceCode\SpecialLogisticsSystem.AppPortal\Documents\install_lodop32.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\SpecialLogisticsSystem\SourceCode\SpecialLogisticsSystem.AppPortal\*"; DestDir: {app}; Excludes:*.webinfo,*.vspscc, \obj,Thumbs.db,CVS,*.pdb,*.cs,*.scc,*.bak,*.csproj,*.log,*.Old,*.user,*.lic,*.sln,*.suo,8.rar; Flags: recursesubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

