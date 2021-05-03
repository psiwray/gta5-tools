using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gta5_tools
{
    class HotKey
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public enum Modifier : int
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Meta = 8,
        }

        public const int HOTKEY_MSG_ID = 0x312;

        private Form form;
        private int id;

        private int key;
        private int modifiers;

        public int Key
        {
            get { return key; }
        }

        public int Modifiers
        {
            get { return modifiers; }
        }

        public HotKey(int key, int modifiers, Form form)
        {
            this.key = key;
            this.modifiers = modifiers;

            this.id = key ^ modifiers ^ form.Handle.ToInt32();
            this.form = form;
        }

        public void Register()
        {
            RegisterHotKey(form.Handle, id, modifiers, key);
        }

        public void Unregister()
        {
            UnregisterHotKey(form.Handle, id);
        }

        public bool MatchesWithMsg(int key, int modifiers)
        {
            return this.key == key && this.modifiers == modifiers;
        }
    }
}
