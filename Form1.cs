using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gta5_tools
{
    public partial class Form1 : Form
    {
        [DllImport("ntdll.dll", PreserveSig = false)]
        private static extern void NtSuspendProcess(IntPtr processHandle);

        [DllImport("ntdll.dll", PreserveSig = false)]
        private static extern void NtResumeProcess(IntPtr processHandle);

        private HotKey disconnectNetwork;
        private HotKey freezeGame;

        private Process gameProcess = null;

        private const string GAME_PROCESS_NAME = "GTA5";
        private const string CONFIG_FILE = "config.json";

        private Config config;

        public Form1()
        {
            InitializeComponent();

            disconnectNetwork = new HotKey((int)Keys.F6, (int)HotKey.Modifier.Alt + (int)HotKey.Modifier.Control, this);
            freezeGame = new HotKey((int)Keys.F7, (int)HotKey.Modifier.Alt + (int)HotKey.Modifier.Control, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disconnectNetwork.Register();
            freezeGame.Register();

            timerGame.Tick += TimerGame_Tick;
            timerNetwork.Tick += TimerNetwork_Tick;

            numericUpDownGame.Value = timerGame.Interval / 1000;
            numericUpDownNetwork.Value = timerNetwork.Interval / 1000;

            // Load the NICs available in the system and auto-select one.
            ProcessStartInfo startInfo = new()
            {
                FileName = "netsh",
                Arguments = $"interface show interface",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process command = new()
            {
                StartInfo = startInfo
            };
            command.Start();

            List<string> interfaceNames = new();
            foreach (var line in command.StandardOutput.ReadToEnd().Split("\r\n").Skip(3))
            {
                string trimmedLine = line.Trim();
                if (trimmedLine.Length == 0) continue;

                // Extract the interface name from the line.
                interfaceNames.Add(
                    string.Join(
                        " ", trimmedLine.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Skip(3)
                            .ToArray()
                    )
                );
            }
            command.WaitForExit();

            if (interfaceNames.Count == 0)
            {
                MessageBox.Show(
                    this, "No network adapters found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1
                );
                Application.Exit();
            }

            // Set the interface names in the list.
            listBoxInterface.Items.Clear();
            listBoxInterface.Items.AddRange(interfaceNames.ToArray());
            listBoxInterface.SelectedIndex = 0;

            // Now load the configuration from disk if available.
            if (File.Exists(CONFIG_FILE))
            {
                Debug.WriteLine("Reading config from disk.");

                config = JsonSerializer.Deserialize<Config>(File.ReadAllText(CONFIG_FILE));
                if (config == null)
                {
                    Debug.WriteLine("Config wrong or invalid, recreating.");

                    config = new()
                    {
                        GameFreezeTime = timerGame.Interval / 1000,
                        NetworkDisconnectTime = timerNetwork.Interval / 1000,
                        LastKnownAdapter = listBoxInterface.SelectedItem.ToString(),
                    };
                }
            }
            else
            {
                Debug.WriteLine("Configuration missing.");

                config = new()
                {
                    GameFreezeTime = timerGame.Interval / 1000,
                    NetworkDisconnectTime = timerNetwork.Interval / 1000,
                    LastKnownAdapter = listBoxInterface.SelectedItem.ToString(),
                };
            }

            timerGame.Interval = config.GameFreezeTime * 1000;
            timerNetwork.Interval = config.NetworkDisconnectTime * 1000;
            listBoxInterface.SelectedItem = config.LastKnownAdapter;

            numericUpDownGame.Value = config.GameFreezeTime;
            numericUpDownNetwork.Value = config.NetworkDisconnectTime;
        }

        private void TimerGame_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Resuming the game's process.");

            // Resume the game.
            NtResumeProcess(gameProcess.Handle);
            gameProcess = null;

            timerGame.Stop();
            timerGame.Enabled = false;
        }

        private void TimerNetwork_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("Reconnecting the network adapter.");

            // Re-attach the network adapter.
            ProcessStartInfo startInfo = new()
            {
                FileName = "netsh",
                Arguments = $"interface set interface \"{listBoxInterface.SelectedItem}\" admin=enabled",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process command = new()
            {
                StartInfo = startInfo
            };
            command.Start();

            command.StandardOutput.ReadToEnd();
            command.WaitForExit();

            timerNetwork.Stop();
            timerNetwork.Enabled = false;
        }

        private void HandleHotKey(int key, int modifiers)
        {
            if (disconnectNetwork.MatchesWithMsg(key, modifiers))
            {
                if (DisconnectNetwork())
                {
                    timerNetwork.Enabled = true;
                    timerNetwork.Start();
                }
                else
                {
                    Debug.WriteLine("Failed to disconnect the network via the hot-key.");
                }
            }
            if (freezeGame.MatchesWithMsg(key, modifiers))
            {
                if (FreezeGame())
                {
                    timerGame.Enabled = true;
                    timerGame.Start();
                }
                else
                {
                    Debug.WriteLine("Failed to freeze the game's process via the hot-key.");
                }
            }
        }

        private bool DisconnectNetwork()
        {
            Debug.WriteLine("Disconnecting the network interface.");

            ProcessStartInfo startInfo = new()
            {
                FileName = "netsh",
                Arguments = $"interface set interface \"{listBoxInterface.SelectedItem}\" admin=disabled",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process command = new()
            {
                StartInfo = startInfo
            };
            command.Start();

            command.StandardOutput.ReadToEnd();
            command.WaitForExit();

            return command.ExitCode == 0;
        }

        private bool FreezeGame()
        {
            Debug.WriteLine("Freezing the game's process.");

            Process process = null;
            foreach (var p in Process.GetProcessesByName(GAME_PROCESS_NAME))
            {
                if (p.ProcessName == GAME_PROCESS_NAME)
                {
                    process = p;
                    break;
                }
            }

            if (process == null)
            {
                return false;
            }
            else
            {
                // We've got the game's process ID, freeze it.
                gameProcess = process;
                NtSuspendProcess(process.Handle);
                return true;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == HotKey.HOTKEY_MSG_ID)
            {
                HandleHotKey(
                    ((m.LParam.ToInt32()) >> 16) & 0xffff,
                    (int)m.LParam & 0xffff
                );
            }

            base.WndProc(ref m);
        }

        private void NumericUpDownGame_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Value changed in the game timer.");

            timerGame.Interval = (int)numericUpDownGame.Value * 1000;
            if (config != null)
                config.GameFreezeTime = (int)numericUpDownGame.Value;
        }

        private void NumericUpDownNetwork_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Value changed in the network timer.");

            timerNetwork.Interval = (int)numericUpDownNetwork.Value * 1000;
            if (config != null)
                config.NetworkDisconnectTime = (int)numericUpDownNetwork.Value;
        }

        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            if (DisconnectNetwork())
            {
                timerNetwork.Enabled = true;
                timerNetwork.Start();
            }
            else
            {
                MessageBox.Show(
                    this, "Failed to disconnect the network!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1
                );
            }
        }

        private void ButtonFreeze_Click(object sender, EventArgs e)
        {
            if (FreezeGame())
            {
                timerGame.Enabled = true;
                timerGame.Start();
            }
            else
            {
                MessageBox.Show(
                    this, "Failed to freeze the game!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1
                );
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the configuration.
            Debug.WriteLine("Saving the configuration.");
            File.WriteAllText(CONFIG_FILE, JsonSerializer.Serialize<Config>(config));
        }

        private void ListBoxInterface_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (config != null) config.LastKnownAdapter = listBoxInterface.SelectedItem.ToString();
        }
    }
}
