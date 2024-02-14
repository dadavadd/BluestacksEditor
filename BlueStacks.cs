using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using Loader.CustomFont;
using System.Drawing;

using dnlib.DotNet;
using dnlib.DotNet.Writer;
using dnlib.DotNet.Resources;
using dnlib.DotNet.Emit;
using System.Linq;
using System.Windows.Media;
using System.Text;

namespace Loader
{
    public partial class BlueStacks : Form
    {
        static ModuleContext modCtx = ModuleDef.CreateModuleContext();
        static ModuleDefMD _moduleHD_Common = ModuleDefMD.Load(BSFileOpened._bsFile_HD_Common, modCtx);
        ModuleDefMD _moduleBluestacks = ModuleDefMD.Load(BSFileOpened._bsFile_BluestacksExe, modCtx);


        public BlueStacks()
        {
            InitializeComponent();

            System.Drawing.FontFamily customFontFamily = FontManager.GetFont();
            if (customFontFamily != null)
            {
                foreach (Control c in this.Controls)
                {
                    Font oldFont = c.Font;
                    c.Font = new Font(customFontFamily, oldFont.Size, oldFont.Style);
                }
            }
        }

        private void BlueStacks_Load(object sender, EventArgs e)
        {
            
        }

        private void _bsCustomNameConfirm_Click(object sender, EventArgs e)
        {

            string filepath = BSFileOpened._bsFile_BluestacksExe;
            byte[] pattern = { 0x34, 0x2E, 0x31, 0x39 };
            int patternIndex = 0;
            bool patternFound = false;

            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                int hexIn;

                for (int i = 0; (hexIn = fs.ReadByte()) != -1; i++)
                {

                    if (hexIn == pattern[patternIndex])
                    {
                        patternIndex++;

                        if (patternIndex == pattern.Length)
                        {
                            patternFound = true;
                            break;
                        }
                    }
                    else
                    {
                        patternIndex = 0;
                    }
                }
            }

            if (patternFound)
            {

                TypeDef _nameSpaceAndClass = _moduleHD_Common.Find("BlueStacks.Common.Strings", false);
                MethodDef _cctor = _nameSpaceAndClass.FindStaticConstructor();

                foreach (Instruction instruction in _cctor.Body.Instructions)
                {
                    if (instruction.OpCode == OpCodes.Ldstr)
                    {
                        if (instruction.Offset == 0x00AC)
                        {
                            instruction.Operand = _bsCustomName.Text;
                        }
                    }
                }
            }
            else
            {
                TypeDef _nameSpaceAndClass = _moduleHD_Common.Find("BlueStacks.Common.Strings", false);
                MethodDef _productName = _nameSpaceAndClass.FindMethod("get_ProductDisplayName");


                CilBody body = new CilBody();
                body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, _bsCustomName.Text));
                body.Instructions.Add(Instruction.Create(OpCodes.Ret));

                _productName.Body = body;
            }
        }

        private void _customVersionConfirm_Click(object sender, EventArgs e)
        {
            TypeDef _namespaceAndClass = _moduleBluestacks.Find("BlueStacks.BlueStacksUI.TopBar", false);
            MethodDef _ctor = _namespaceAndClass.FindDefaultConstructor();

            if (_ctor != null)
            {
                for (int i = _ctor.Body.Instructions.Count - 1; i >= 0; i--)
                {
                    Instruction instruction = _ctor.Body.Instructions[i];

                    if (instruction.Offset == 0x019B)
                    {
                        if (instruction.OpCode == OpCodes.Call)
                        {
                            instruction.OpCode = OpCodes.Ldstr;
                            instruction.Operand = _customVersionBox.Text;
                        }
                    }

                    if (instruction.Offset == 0x01A0)
                    {
                        if (instruction.OpCode == OpCodes.Callvirt)
                        {
                            _ctor.Body.Instructions.Remove(instruction);
                        }
                    }
                }
            }
        }

        private void _customFontConfirm_Click(object sender, EventArgs e)
        {
            string fontName = null;

            TypeDef _nameSpaceAndClass = _moduleHD_Common.Find("BlueStacks.Common.CustomWindow", false);
            MethodDef _ctor = _nameSpaceAndClass.FindDefaultConstructor();

            AssemblyRef presentCore = _moduleHD_Common.GetAssemblyRef("PresentationCore");
            TypeRefUser presetCoreCtor = new TypeRefUser(_moduleHD_Common, "System.Windows.Media", "FontFamily", presentCore);
            IMethod presentCoreFontFamilyCtor = presetCoreCtor.ResolveTypeDef().FindMethod(".ctor");

            AssemblyRef presentFrame = _moduleHD_Common.GetAssemblyRef("PresentationFramework");
            TypeRefUser presentFrameControl = new TypeRefUser(_moduleHD_Common, "System.Windows.Controls", "Control", presentFrame);
            IMethod setFont = presentFrameControl.ResolveTypeDef().FindMethod("set_FontFamily");


            foreach (System.Windows.Media.FontFamily fontFamily in Fonts.GetFontFamilies(@_customFont.Text))
            {
                fontName = fontFamily.ToString().Split('#')[fontFamily.ToString().Split('#').Count() - 1];
            }

            if (_ctor != null)
            {
                for (int i = 0; i < _ctor.Body.Instructions.Count(); i++)
                {
                    _ctor.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call,
                        _moduleHD_Common.Import(typeof(AppDomain).GetMethod("get_CurrentDomain", new Type[] { }))));

                    _ctor.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt,
                        _moduleHD_Common.Import(typeof(AppDomain).GetMethod("get_BaseDirectory", new Type[] { }))));

                    _ctor.Body.Instructions.Insert(i + 5, new Instruction(OpCodes.Call, _moduleHD_Common.Import(typeof(System.Text.Encoding).GetMethod("get_UTF8", new Type[] { }))));

                    _ctor.Body.Instructions.Insert(i + 6, new Instruction(OpCodes.Ldstr, Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes("Properties/#")) + 
                        Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(fontName))));

                    _ctor.Body.Instructions.Insert(i + 7, new Instruction(OpCodes.Call, _moduleHD_Common.Import(typeof(System.Convert).GetMethod("FromBase64String", new Type[] { typeof(string) }))));

                    _ctor.Body.Instructions.Insert(i + 8, new Instruction(OpCodes.Callvirt, _moduleHD_Common.Import(typeof(System.Text.Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) }))));

                    _ctor.Body.Instructions.Insert(i + 9, new Instruction(OpCodes.Call,
                        _moduleHD_Common.Import(typeof(String).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }))));

                    _ctor.Body.Instructions.Insert(i + 10, new Instruction(OpCodes.Newobj,
                        _moduleHD_Common.Import(presentCoreFontFamilyCtor)));

                    _ctor.Body.Instructions.Insert(i + 11, new Instruction(OpCodes.Call,
                        _moduleHD_Common.Import(setFont)));

                    _ctor.Body.Instructions.Insert(i + 12, new Instruction(OpCodes.Ldarg_0));
                    break;
                }

                string newPropertiesPath = Path.Combine(Path.GetDirectoryName(
                    BSFileOpened._bsFile_BluestacksExe), "Properties");

                if (!Directory.Exists(newPropertiesPath))
                {
                    Directory.CreateDirectory(newPropertiesPath);
                }

                string fontFilePath = @_customFont.Text;
                string destFilePath = Path.Combine(newPropertiesPath, Path.GetFileName(fontFilePath));

                if (!File.Exists(destFilePath))
                {
                    File.Copy(fontFilePath, destFilePath);
                }

            }
        }

        private void _isPremiumConfirm_Click(object sender, EventArgs e)
        {
            TypeDef _nameSpaceClass = _moduleHD_Common.Find("BlueStacks.Common.RegistryManager", false);
            MethodDef _isPremium_get = _nameSpaceClass.FindMethod("get_IsPremium");

            _isPremium_get.Body = new CilBody();
            _isPremium_get.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4_1));
            _isPremium_get.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
        }

        private void _adBlockConfirm_Click(object sender, EventArgs e)
        {
            TypeDef _nameSpaceAndClass = _moduleBluestacks.Find("BlueStacks.BlueStacksUI.PromotionManager", false);
            MethodDef _getPromotionData = _nameSpaceAndClass.FindMethod("GetPromotionData");

            MessageBox.Show("После сохранения измененного блюстакса, удалите папку Promo в папке " +
                "Client у Bluestacks.");

            if (_getPromotionData != null)
            {
                _getPromotionData.Body = new CilBody();
                _getPromotionData.Body.Instructions.Clear();

                CilBody cilBody = new CilBody();
                cilBody.Instructions.Add(Instruction.Create(OpCodes.Ret));
                _getPromotionData.Body = cilBody;
            }
        }

        private void _telemetryOff_Click(object sender, EventArgs e)
        {
            TypeDef _nameSpaceClass = _moduleBluestacks.Find("BlueStacks.BlueStacksUI.ClientStats", false);
            MethodDef _sendClientClick = _nameSpaceClass.FindMethod("SendClientStatsAsync");
            MethodDef _sendFrontedClick = _nameSpaceClass.FindMethod("SendFrontendClickStats");
            MethodDef _sendCalendarStats = _nameSpaceClass.FindMethod("SendCalendarStats");
            MethodDef _sendStatsSync = _nameSpaceClass.FindMethod("SendStatsSync");
            MethodDef _sendGPPlayClick = _nameSpaceClass.FindMethod("SendGPlayClickStats");
            MethodDef _sendMiscellPopubStatsAsync = _nameSpaceClass.FindMethod("SendMiscellaneousStatsAsync");
            MethodDef _sendKeyMappingUIStats = _nameSpaceClass.FindMethod("SendKeyMappingUIStatsAsync");
            MethodDef _sendQuitStatsAsync = _nameSpaceClass.FindMethod("SendLocalQuitPopupStatsAsync");
            MethodDef _sendBSUpdateStatsAsync = _nameSpaceClass.FindMethod("SendBluestacksUpdaterUIStatsAsync");
            MethodDef _sendBrowserStatsASync = _nameSpaceClass.FindMethod("SendPopupBrowserStatsInMiscASync");
            MethodDef _sendGeneralStats = _nameSpaceClass.FindMethod("SendGeneralStats");
            MethodDef _sendStatsAsync = _nameSpaceClass.FindMethod("SendStatsAsync");
            MethodDef _sendPromotionAppClick = _nameSpaceClass.FindMethod("SendPromotionAppClickStatsAsync");
            MethodDef _sendStats = _nameSpaceClass.FindMethod("SendStats");

            if (_nameSpaceClass != null)
            {
                _sendClientClick.Body = new CilBody();
                _sendFrontedClick.Body = new CilBody();
                _sendCalendarStats.Body = new CilBody();
                _sendStatsSync.Body = new CilBody();
                _sendGPPlayClick.Body = new CilBody();
                _sendMiscellPopubStatsAsync.Body = new CilBody();
                _sendKeyMappingUIStats.Body = new CilBody();
                _sendQuitStatsAsync.Body = new CilBody();
                _sendBSUpdateStatsAsync.Body = new CilBody();
                _sendBrowserStatsASync.Body = new CilBody();
                _sendGeneralStats.Body = new CilBody();
                _sendStatsAsync.Body = new CilBody();
                _sendPromotionAppClick.Body = new CilBody();
                _sendStats.Body = new CilBody();

                _sendClientClick.Body.Instructions.Clear();
                _sendFrontedClick.Body.Instructions.Clear();
                _sendCalendarStats.Body.Instructions.Clear();
                _sendStatsSync.Body.Instructions.Clear();
                _sendGPPlayClick.Body.Instructions.Clear();
                _sendMiscellPopubStatsAsync.Body.Instructions.Clear();
                _sendKeyMappingUIStats.Body.Instructions.Clear();
                _sendQuitStatsAsync.Body.Instructions.Clear();
                _sendBSUpdateStatsAsync.Body.Instructions.Clear();
                _sendBrowserStatsASync.Body.Instructions.Clear();
                _sendGeneralStats.Body.Instructions.Clear();
                _sendStatsAsync.Body.Instructions.Clear();
                _sendPromotionAppClick.Body.Instructions.Clear();
                _sendStats.Body.Instructions.Clear();

                CilBody cilBody = new CilBody();
                cilBody.Instructions.Add(Instruction.Create(OpCodes.Ret));
                _sendClientClick.Body = cilBody;
                _sendFrontedClick.Body = cilBody;
                _sendCalendarStats.Body = cilBody;
                _sendStatsSync.Body = cilBody;
                _sendGPPlayClick.Body = cilBody;
                _sendMiscellPopubStatsAsync.Body = cilBody;
                _sendKeyMappingUIStats.Body = cilBody;
                _sendQuitStatsAsync.Body = cilBody;
                _sendBSUpdateStatsAsync.Body = cilBody;
                _sendBrowserStatsASync.Body = cilBody;
                _sendGeneralStats.Body = cilBody;
                _sendStatsAsync.Body = cilBody;
                _sendPromotionAppClick.Body = cilBody;
                _sendStats.Body = cilBody;
            }
        }

        private void _dpiConfirm_Click(object sender, EventArgs e)
        {
            TypeDef _nameSpaceAndClass = _moduleHD_Common.Find("BlueStacks.Common.DisplaySettingConstants", false);

            if (_nameSpaceAndClass != null)
            {
                FieldDef _dpiValueOne = _nameSpaceAndClass.FindField("Dpi160");
                FieldDef _dpiValueTwo = _nameSpaceAndClass.FindField("Dpi240");
                FieldDef _dpiValueThree = _nameSpaceAndClass.FindField("Dpi320");

                if (_dpiValueOne != null)
                {
                    _dpiValueOne.Constant.Value = _dpiFirstValue.Text;
                }
                if (_dpiValueTwo != null)
                {
                    _dpiValueTwo.Constant.Value = _dpiTwoValue.Text;
                }
                if (_dpiValueThree != null)
                {
                    _dpiValueThree.Constant.Value = _dpiThreeValue.Text;
                }
            }
        }

        private void _fpsConfirm_Click(object sender, EventArgs e)
        {
            TypeDef _namespaceAndClass = _moduleHD_Common.Find("BlueStacks.Common.EngineSettingBaseViewModel", false);
            MethodDef _method = _namespaceAndClass.FindMethod("set_EnableHighFrameRates");

            if (_method != null)
            {
                foreach (Instruction instruction in _method.Body.Instructions)
                {
                    if (instruction.OpCode == OpCodes.Ldc_I4)
                    {
                        if (_fpsCount.Text == string.Empty)
                        {
                            MessageBox.Show("Для анлока FPS надо указать количество в FpsCount");
                        }
                        else
                        {
                            instruction.Operand = Convert.ToInt32(_fpsCount.Text);
                        }
                    }
                }
            }
        }

        private void _bsCustomRamConfirm_Click(object sender, EventArgs e)
        {
            TypeDef _nameSpaceAndClass = _moduleHD_Common.Find("BlueStacks.Common.EngineSettingBaseViewModel", false);
            MethodDef _setRam = _nameSpaceAndClass.FindMethod("SetRam");

            if (_setRam != null)
            {
                if (_bsRamCount.Text != null)
                {
                    for (int i = 0; i < _setRam.Body.Instructions.Count; i++)
                    {
                        Instruction instruction = _setRam.Body.Instructions[i];

                        if (instruction.OpCode == OpCodes.Ldc_I4)
                        {
                            instruction.Operand = Convert.ToInt32(_bsRamCount.Text);
                        }
                    }
                }
            }
        }

        private void _supportLinkConfirm_Click(object sender, EventArgs e)
        {
            if (_moduleBluestacks.HasGResources())
            {
                var _resources = _moduleBluestacks.gResources();
                foreach (var element in _resources.Elements)
                {
                    var _resourcesRead = _resources.Read(element.Name);
                    foreach (var record in _resourcesRead.Document)
                    {
                        if (record.Type == BamlRecordType.PropertyWithConverter)
                        {
                            PropertyWithConverterRecord _pwcr = record as PropertyWithConverterRecord;
                            _pwcr.Value = _pwcr.Value.Replace("https://support.bluestacks.com", _customSupport.Text);
                        }
                        else if (record.Type == BamlRecordType.Text)
                        {
                            TextRecord textRecord = record as TextRecord;
                            textRecord.Value = textRecord.Value.Replace("support.bluestacks.com", _customSupport.Text);
                        }
                    }
                    _resources.Write(_resourcesRead);
                }
                _moduleBluestacks.RemoveGResources();
                _moduleBluestacks.Resources.Add(_resources.GetAsEmbeddedResource());
            }
        }

        private void _siteCustomConfirm_Click(object sender, EventArgs e)
        {
            if (_moduleBluestacks.HasGResources())
            {
                var _resources_ = _moduleBluestacks.gResources();
                foreach (var element in _resources_.Elements)
                {
                    var _resourcesRead = _resources_.Read(element.Name);
                    foreach (var record in _resourcesRead.Document)
                    {
                        if (record.Type == BamlRecordType.PropertyWithConverter)
                        {
                            PropertyWithConverterRecord _pwcr = record as PropertyWithConverterRecord;
                            _pwcr.Value = _pwcr.Value.Replace("www.bluestacks.com", _customWebsite.Text);
                        }
                        else if (record.Type == BamlRecordType.Text)
                        {
                            TextRecord textRecord = record as TextRecord;
                            textRecord.Value = textRecord.Value.Replace("www.bluestacks.com", _customWebsite.Text);
                        }
                    }
                    _resources_.Write(_resourcesRead);
                }
                _moduleBluestacks.RemoveGResources();
                _moduleBluestacks.Resources.Add(_resources_.GetAsEmbeddedResource());
            }
        }

        private void _emailCustomConfirm_Click(object sender, EventArgs e)
        {
            if (_moduleBluestacks.HasGResources())
            {
                var _resources = _moduleBluestacks.gResources();
                foreach (var element in _resources.Elements)
                {
                    var _resourcesRead = _resources.Read(element.Name);
                    foreach (var record in _resourcesRead.Document)
                    {
                        if (record.Type == BamlRecordType.PropertyWithConverter)
                        {
                            PropertyWithConverterRecord _pwcr_ = record as PropertyWithConverterRecord;
                            _pwcr_.Value = _pwcr_.Value.Replace("mailto:support@bluestacks.com", _customEmail.Text);
                        }
                        else if (record.Type == BamlRecordType.Text)
                        {
                            TextRecord _textRecord = record as TextRecord;
                            _textRecord.Value = _textRecord.Value.Replace("support@bluestacks.com", _customEmail.Text);
                        }
                    }
                    _resources.Write(_resourcesRead);
                }
                _moduleBluestacks.RemoveGResources();
                _moduleBluestacks.Resources.Add(_resources.GetAsEmbeddedResource());
            }
        }

        private void _customTermsOfViewConfirm_Click(object sender, EventArgs e)
        {

        }

        private void _appExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _telegramLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/ouringg_official");
        }

        private void _changeSaving_Click(object sender, EventArgs e)
        {
            string _newPath_HD_Common = Path.GetFullPath(BSFileOpened._bsFile_HD_Common + "_saved.dll");
            string _newPath_Bluestacks = Path.GetFullPath(BSFileOpened._bsFile_BluestacksExe + "_saved.exe");
            _moduleHD_Common.Write(_newPath_HD_Common, new ModuleWriterOptions(_moduleHD_Common)
            {
                MetadataOptions = { Flags = MetadataFlags.PreserveAll },
                PEHeadersOptions = { NumberOfRvaAndSizes = 0x10 },
                Logger = DummyLogger.ThrowModuleWriterExceptionOnErrorInstance,
                WritePdb = true
            });
            _moduleBluestacks.Write(_newPath_Bluestacks, new ModuleWriterOptions(_moduleBluestacks)
            {
                MetadataOptions = { Flags = MetadataFlags.PreserveAll },
                PEHeadersOptions = { NumberOfRvaAndSizes = 0x10 },
                Logger = DummyLogger.ThrowModuleWriterExceptionOnErrorInstance,
                WritePdb = true
            });
        }
    }
}