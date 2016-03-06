using System;
using System.Diagnostics;
using System.IO;

namespace CSScriptNpp
{
    /// <summary>
    /// Of course XML based config is more natural, however ini file reading (just a few values) is faster.
    /// </summary>
    public class Config : IniFile
    {
        public static string Location = Plugin.ConfigDir;

        public static Shortcuts Shortcuts = new Shortcuts();
        public static Config Instance { get { return instance ?? (instance = new Config()); } }
        public static Config instance;

        public string Section = "Generic";

        public Config()
        {
            base.file = Path.Combine(Location, "settings.ini");
            Open();
        }

        public string GetFileName()
        {
            return base.file;
        }

        public bool ClasslessScriptByDefault = false;
        public bool DistributeScriptAsScriptByDefault = true;
        public bool DistributeScriptAsWindowApp = false;
        public bool InterceptConsole = false;
        public bool UseEmbeddedEngine = true;
        public string UseCustomEngine = "";
        public bool QuickViewAutoRefreshAvailable = false;
        public bool NavigateToRawCodeOnDblClickInOutput = false;
        //public bool BuildOnF7 = true;
        public bool BreakOnException = false;
        public bool UpdateAfterExit = false;
        public string UpdateMode = "custom";
        public bool CheckUpdatesOnStartup = true;
        public bool CheckPrereleaseUpdates = false;
        public bool UseRoslynProvider = false;
        public bool StartRoslynServerAtStartup = false;
        public bool ImproveWin10ListVeiwRendering = true;
        public bool WordWrapInVisualizer = true;
        public bool ListManagedProcessesOnly = true;
        public bool RunExternalInDebugMode = true;
        public bool FloatingPanelsWarningAlreadyPropted = false;
        public string TargetVersion = "v4.0.30319";
        public string SkipUpdateVersion = "";
        //public string ScriptEngineLocation = "";
        public string CsSConsoleEncoding = "utf-8";
        public string HotkeyDocumentsExclusions = ".cmd;.bat;.test";
        public string LastExternalProcess = "";
        public string LastExternalProcessArgs = "";
        public int LastExternalProcessCpu = 0;
        public string ReleaseNotesViewedFor = "";
        public string LastUpdatesCheckDate = DateTime.MinValue.ToString("yyyy-MM-dd");
        public string ScriptHistory = "";
        public string DebugStepPointColor = "Yellow";
        public string DebugStepPointForeColor = "Black";
        public int SciptHistoryMaxCount = 10;
        public int CollectionItemsInTooltipsMaxCount = 15;
        public int CollectionItemsInVisualizersMaxCount = 1000;
        public int DebugPanelInitialTab = 0;
        public bool ShowLineNuberInCodeMap = false;
        public bool ShowProjectPanel = false;
        public bool ShowOutputPanel = false;
        public bool DebugAsConsole = true;
        public bool HandleSaveAs = true;
        public bool ShowDebugPanel = false;
        public int OutputPanelCapacity = 10000; //num of characters
        public bool LocalDebug = true;

        public void Save()
        {
            lock (typeof(Config))
            {
                try
                {
                   // Debug.WriteLine("---> Config.Save");
                    File.WriteAllText(this.file, ""); //clear to get rid of all obsolete values

                    SetValue(Section, nameof(ShowProjectPanel), ShowProjectPanel);
                    SetValue(Section, nameof(ShowOutputPanel), ShowOutputPanel);
                    SetValue(Section, nameof(DebugAsConsole), DebugAsConsole);
                    SetValue(Section, nameof(HandleSaveAs), HandleSaveAs);
                    SetValue(Section, nameof(ShowLineNuberInCodeMap), ShowLineNuberInCodeMap);
                    SetValue(Section, nameof(ShowDebugPanel), ShowDebugPanel);
                    SetValue(Section, nameof(WordWrapInVisualizer), WordWrapInVisualizer);
                    SetValue(Section, nameof(ListManagedProcessesOnly), ListManagedProcessesOnly);
                    SetValue(Section, nameof(RunExternalInDebugMode), RunExternalInDebugMode);
                    SetValue(Section, nameof(OutputPanelCapacity), OutputPanelCapacity);
                    SetValue(Section, nameof(HotkeyDocumentsExclusions), HotkeyDocumentsExclusions);
                    SetValue(Section, nameof(NavigateToRawCodeOnDblClickInOutput), NavigateToRawCodeOnDblClickInOutput);
                    SetValue(Section, nameof(QuickViewAutoRefreshAvailable), QuickViewAutoRefreshAvailable);
                    SetValue(Section, nameof(InterceptConsole), InterceptConsole);
                    SetValue(Section, nameof(UseEmbeddedEngine), UseEmbeddedEngine);
                    SetValue(Section, nameof(UseCustomEngine), UseCustomEngine);
                    SetValue(Section, nameof(ReleaseNotesViewedFor), ReleaseNotesViewedFor);
                    SetValue(Section, nameof(ScriptHistory), ScriptHistory);
                    SetValue(Section, nameof(DebugStepPointColor), DebugStepPointColor);
                    SetValue(Section, nameof(DebugStepPointForeColor), DebugStepPointForeColor);
                    SetValue(Section, nameof(SciptHistoryMaxCount), SciptHistoryMaxCount);
                    SetValue(Section, nameof(CollectionItemsInTooltipsMaxCount), CollectionItemsInTooltipsMaxCount);
                    SetValue(Section, nameof(CollectionItemsInVisualizersMaxCount), CollectionItemsInVisualizersMaxCount);
                    SetValue(Section, nameof(DebugPanelInitialTab), DebugPanelInitialTab);
                    SetValue(Section, nameof(LocalDebug), LocalDebug);
                    SetValue(Section, nameof(BreakOnException), BreakOnException);
                    SetValue(Section, nameof(UpdateAfterExit), UpdateAfterExit);
                    SetValue(Section, nameof(LastUpdatesCheckDate), LastUpdatesCheckDate);
                    SetValue(Section, nameof(CheckUpdatesOnStartup), CheckUpdatesOnStartup);
                    SetValue(Section, nameof(CheckPrereleaseUpdates), CheckPrereleaseUpdates);
                    SetValue(Section, nameof(SkipUpdateVersion), SkipUpdateVersion);
                    SetValue(Section, nameof(UseRoslynProvider), UseRoslynProvider);
                    SetValue(Section, nameof(StartRoslynServerAtStartup), StartRoslynServerAtStartup);
                    SetValue(Section, nameof(ImproveWin10ListVeiwRendering), ImproveWin10ListVeiwRendering);
                    SetValue(Section, nameof(UpdateMode), UpdateMode);
                    SetValue(Section, nameof(FloatingPanelsWarningAlreadyPropted), FloatingPanelsWarningAlreadyPropted);
                    SetValue(Section, nameof(LastExternalProcess), LastExternalProcess);
                    SetValue(Section, nameof(LastExternalProcessArgs), LastExternalProcessArgs);
                    SetValue(Section, nameof(LastExternalProcessCpu), LastExternalProcessCpu);
                    SetValue(Section, nameof(TargetVersion), TargetVersion);
                    SetValue(Section, nameof(CsSConsoleEncoding), CsSConsoleEncoding);
                    SetValue(Section, nameof(ClasslessScriptByDefault), ClasslessScriptByDefault);
                    SetValue(Section, nameof(DistributeScriptAsScriptByDefault), DistributeScriptAsScriptByDefault);
                    SetValue(Section, nameof(DistributeScriptAsWindowApp), DistributeScriptAsWindowApp);

                    CSScriptIntellisense.Config.Instance.Save();

                    Shortcuts.Save();
                }
                catch 
                {
                    Debug.Assert(false);
                    throw;
                }
                Debug.WriteLine("<--- Config.Save");
            }
        }

        public void Open()
        {
            lock (typeof(Config))
            {
                //Debug.Assert(false);
                Debug.WriteLine("---> Config.Open");
                ShowLineNuberInCodeMap = GetValue(Section, nameof(ShowLineNuberInCodeMap), ShowLineNuberInCodeMap);
                ShowProjectPanel = GetValue(Section, nameof(ShowProjectPanel), ShowProjectPanel);
                ShowOutputPanel = GetValue(Section, nameof(ShowOutputPanel), ShowOutputPanel);
                DebugAsConsole = GetValue(Section, nameof(DebugAsConsole), DebugAsConsole);
                HandleSaveAs = GetValue(Section, nameof(HandleSaveAs), HandleSaveAs);
                WordWrapInVisualizer = GetValue(Section, nameof(WordWrapInVisualizer), WordWrapInVisualizer);
                ListManagedProcessesOnly = GetValue(Section, nameof(ListManagedProcessesOnly), ListManagedProcessesOnly);
                RunExternalInDebugMode = GetValue(Section, nameof(RunExternalInDebugMode), RunExternalInDebugMode);
                //ShowDebugPanel = GetValue(Section, nameof(ShowDebugPanel), ShowDebugPanel); //ignore; do not show Debug panel as it is heavy. It will be displayed at the first debug step anyway.
                DebugStepPointColor = GetValue(Section, nameof(DebugStepPointColor), DebugStepPointColor, 1024 * 4);
                DebugStepPointForeColor = GetValue(Section, nameof(DebugStepPointForeColor), DebugStepPointForeColor, 1024 * 4);
                ScriptHistory = GetValue(Section, nameof(ScriptHistory), ScriptHistory, 1024 * 40);
                SciptHistoryMaxCount = GetValue(Section, nameof(SciptHistoryMaxCount), SciptHistoryMaxCount);
                CollectionItemsInTooltipsMaxCount = GetValue(Section, nameof(CollectionItemsInTooltipsMaxCount), CollectionItemsInTooltipsMaxCount);
                CollectionItemsInVisualizersMaxCount = GetValue(Section, nameof(CollectionItemsInVisualizersMaxCount), CollectionItemsInVisualizersMaxCount);
                DebugPanelInitialTab = GetValue(Section, nameof(DebugPanelInitialTab), DebugPanelInitialTab);
                OutputPanelCapacity = GetValue(Section, nameof(OutputPanelCapacity), OutputPanelCapacity);
                HotkeyDocumentsExclusions = GetValue(Section, nameof(HotkeyDocumentsExclusions), HotkeyDocumentsExclusions);
                NavigateToRawCodeOnDblClickInOutput = GetValue(Section, nameof(NavigateToRawCodeOnDblClickInOutput), NavigateToRawCodeOnDblClickInOutput);
                InterceptConsole = GetValue(Section, nameof(InterceptConsole), InterceptConsole);
                UseEmbeddedEngine = GetValue(Section, nameof(UseEmbeddedEngine), UseEmbeddedEngine);
                UseCustomEngine = GetValue(Section, nameof(UseCustomEngine), UseCustomEngine);
                //QuickViewAutoRefreshAvailable = GetValue(Section, nameof(QuickViewAutoRefreshAvailable), QuickViewAutoRefreshAvailable); //disable until auto-refresh approach is finalized
                LocalDebug = GetValue(Section, nameof(LocalDebug), LocalDebug);
                TargetVersion = GetValue(Section, nameof(TargetVersion), TargetVersion);
                CsSConsoleEncoding = GetValue(Section, nameof(CsSConsoleEncoding), CsSConsoleEncoding);
                LastExternalProcess = GetValue(Section, nameof(LastExternalProcess), LastExternalProcess);
                LastExternalProcessArgs = GetValue(Section, nameof(LastExternalProcessArgs), LastExternalProcessArgs);
                LastExternalProcessCpu = GetValue(Section, nameof(LastExternalProcessCpu), LastExternalProcessCpu);
                ReleaseNotesViewedFor = GetValue(Section, nameof(ReleaseNotesViewedFor), ReleaseNotesViewedFor);
                BreakOnException = GetValue(Section, nameof(BreakOnException), BreakOnException);
                UpdateAfterExit = GetValue(Section, nameof(UpdateAfterExit), UpdateAfterExit);
                LastUpdatesCheckDate = GetValue(Section, nameof(LastUpdatesCheckDate), LastUpdatesCheckDate);
                CheckUpdatesOnStartup = GetValue(Section, nameof(CheckUpdatesOnStartup), CheckUpdatesOnStartup);
                CheckPrereleaseUpdates = GetValue(Section, nameof(CheckPrereleaseUpdates), CheckPrereleaseUpdates);
                SkipUpdateVersion = GetValue(Section, nameof(SkipUpdateVersion), SkipUpdateVersion);
                UseRoslynProvider = GetValue(Section, nameof(UseRoslynProvider), UseRoslynProvider);
                StartRoslynServerAtStartup = GetValue(Section, nameof(StartRoslynServerAtStartup), StartRoslynServerAtStartup);
                ImproveWin10ListVeiwRendering = GetValue(Section, nameof(ImproveWin10ListVeiwRendering), ImproveWin10ListVeiwRendering);
                UpdateMode = GetValue(Section, nameof(UpdateMode), UpdateMode);
                FloatingPanelsWarningAlreadyPropted = GetValue(Section, nameof(FloatingPanelsWarningAlreadyPropted), FloatingPanelsWarningAlreadyPropted);
                ClasslessScriptByDefault = GetValue(Section, nameof(ClasslessScriptByDefault), ClasslessScriptByDefault);
                DistributeScriptAsScriptByDefault = GetValue(Section, nameof(DistributeScriptAsScriptByDefault), DistributeScriptAsScriptByDefault);
                DistributeScriptAsWindowApp = GetValue(Section, nameof(DistributeScriptAsWindowApp), DistributeScriptAsWindowApp);

                CSScriptIntellisense.Config.Instance.Open();
                Debug.WriteLine("<--- Config.Open");
            }
        }
    }
}