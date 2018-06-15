using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;

[assembly: XmlnsDefinition("http://jamsoft.co.uk/wpf/windows", "JamSoft.Wpf.Windows"),
           XmlnsPrefix("http://jamsoft.co.uk/wpf/windows", "jswindows")]

namespace JamSoft.Wpf.Windows
{
    /// <summary>
    ///     Persists a Window's Size, Location and WindowState to UserScopeSettings
    /// </summary>
    public sealed class WindowSettings
    {
        /// <summary>
        ///     Register the "Save" attached property and the "OnSaveInvalidated" callback
        /// </summary>
        public static readonly DependencyProperty SaveProperty
            = DependencyProperty.RegisterAttached("Save", typeof(bool), typeof(WindowSettings),
                new FrameworkPropertyMetadata(OnSaveInvalidated));

        private Window _window;

        private WindowApplicationSettings _windowApplicationSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowSettings"/> class.
        /// </summary>
        /// <param name="window">The window.</param>
        public WindowSettings(Window window)
        {
            _window = window;
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        [Browsable(false)]
        internal WindowApplicationSettings Settings
        {
            get
            {
                if (_windowApplicationSettings == null)
                    _windowApplicationSettings = CreateWindowApplicationSettingsInstance();
                return _windowApplicationSettings;
            }
        }

        /// <summary>
        /// Sets the window placement.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpwndpl">The LPWNDPL.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// Gets the window placement.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpwndpl">The LPWNDPL.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// Sets the save.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        public static void SetSave(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(SaveProperty, enabled);
        }

        /// <summary>
        ///     Called when Save is changed on an object.
        /// </summary>
        private static void OnSaveInvalidated(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var window = dependencyObject as Window;
            if (window == null || !(bool) e.NewValue) return;
            var settings = new WindowSettings(window);
            settings.Attach();
        }

        /// <summary>
        ///     Load the Window Size Location and State from the settings object
        /// </summary>
        private void LoadWindowState()
        {
            Settings.Reload();

            if (Settings.Placement == null) return;
            try
            {
                // Load window placement details for previous application session from application settings
                // if window was closed on a monitor that is now disconnected from the computer,
                // SetWindowPlacement will place the window onto a visible monitor.
                var wp = Settings.Placement.Value;

                wp.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                wp.flags = 0;
                wp.showCmd = wp.showCmd == SW_SHOWMINIMIZED ? SW_SHOWNORMAL : wp.showCmd;
                var hwnd = new WindowInteropHelper(_window).Handle;
                SetWindowPlacement(hwnd, ref wp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to load window state:\r\n{0}", ex);
            }
        }

        /// <summary>
        ///     Save the Window Size, Location and State to the settings object
        /// </summary>
        private void SaveWindowState()
        {
            WINDOWPLACEMENT wp;
            var hwnd = new WindowInteropHelper(_window).Handle;
            GetWindowPlacement(hwnd, out wp);
            Settings.Placement = wp;
            Settings.Save();
        }

        private void Attach()
        {
            if (_window == null) return;
            _window.Closing += WindowClosing;
            _window.SourceInitialized += WindowSourceInitialized;
        }

        private void WindowSourceInitialized(object sender, EventArgs e)
        {
            LoadWindowState();
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            SaveWindowState();
            _window.Closing -= WindowClosing;
            _window.SourceInitialized -= WindowSourceInitialized;
            _window = null;
        }

        internal WindowApplicationSettings CreateWindowApplicationSettingsInstance()
        {
            return new WindowApplicationSettings(this);
        }

        internal class WindowApplicationSettings : ApplicationSettingsBase
        {
            public WindowApplicationSettings(WindowSettings windowSettings) : base(windowSettings._window.GetType()
                .FullName)
            {
            }

            [UserScopedSetting]
            public WINDOWPLACEMENT? Placement
            {
                get
                {
                    if (this["Placement"] != null) return (WINDOWPLACEMENT) this["Placement"];
                    return null;
                }
                set => this["Placement"] = value;
            }
        }

        // ReSharper disable InconsistentNaming
        private const int SW_SHOWNORMAL = 1;

        private const int SW_SHOWMINIMIZED = 2;
        // ReSharper restore InconsistentNaming
    }


    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        private int _left;
        private int _top;
        private int _right;
        private int _bottom;

        /// <summary>
        /// Initializes a new instance of the <see cref="RECT"/> struct.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        // ReSharper disable UnusedMember.Global
        public RECT(int left, int top, int right, int bottom)// ReSharper restore UnusedMember.Global
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is RECT)
            {
                var rect = (RECT) obj;

                return rect._bottom == _bottom &&
                       rect._left == _left &&
                       rect._right == _right &&
                       rect._top == _top;
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return _bottom.GetHashCode() ^
                   _left.GetHashCode() ^
                   _right.GetHashCode() ^
                   _top.GetHashCode();
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(RECT a, RECT b)
        {
            return a._bottom == b._bottom &&
                   a._left == b._left &&
                   a._right == b._right &&
                   a._top == b._top;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(RECT a, RECT b)
        {
            return !(a == b);
        }

        // ReSharper disable UnusedMember.Global
        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>
        /// The left.
        /// </value>
        public int Left
        {
            get => _left;
            set => _left = value;
        }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>
        /// The top.
        /// </value>
        public int Top
        {
            get => _top;
            set => _top = value;
        }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        /// <value>
        /// The right.
        /// </value>
        public int Right
        {
            get => _right;
            set => _right = value;
        }

        /// <summary>
        /// Gets or sets the bottom.
        /// </summary>
        /// <value>
        /// The bottom.
        /// </value>
        public int Bottom
        {
            get => _bottom;
            set => _bottom = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        private int _x;
        private int _y;

        /// <summary>
        /// Initializes a new instance of the <see cref="POINT"/> struct.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public POINT(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y
            // ReSharper restore UnusedMember.Global
        {
            get => _y;
            set => _y = value;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is POINT)
            {
                var point = (POINT) obj;

                return point._x == _x && point._y == _y;
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode();
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(POINT a, POINT b)
        {
            return a._x == b._x && a._y == b._y;
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(POINT a, POINT b)
        {
            return !(a == b);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPLACEMENT
    {
        // ReSharper disable InconsistentNaming
        public int length;
        public int flags;
        public int showCmd;
        public POINT minPosition;
        public POINT maxPosition;

        public RECT normalPosition;
        // ReSharper restore InconsistentNaming
    }
}