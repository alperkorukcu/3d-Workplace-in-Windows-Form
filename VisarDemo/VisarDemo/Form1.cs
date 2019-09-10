using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Threading;
using WinFormsContentLoading;

namespace VisarDemo
{
    public partial class MainForm : Form
    {

        ContentBuilder contentBuilder;
        ContentManager contentManager;

        public MainForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            contentBuilder = new ContentBuilder();

            contentManager = new ContentManager(modelViewerControl1.Services, contentBuilder.OutputDirectory);
        }

        void LoadModel(string fileName)
        {
            Cursor = Cursors.WaitCursor;
            
            // Unload any existing model.
            modelViewerControl1.Model = null;
            contentManager.Unload();

            // Tell the ContentBuilder what to build.
            contentBuilder.Clear();
            contentBuilder.Add(fileName, "Model", null, "ModelProcessor");

            // Build this new model data.
            string buildError = contentBuilder.Build();

            if (string.IsNullOrEmpty(buildError))
            {
                // If the build succeeded, use the ContentManager to
                // load the temporary .xnb file that we just created.
                modelViewerControl1.Model = contentManager.Load<Model>("Model");
            }
            else
            {
                // If the build failed, display an error message.
                MessageBox.Show(buildError, "Error");
            }

            Cursor = Cursors.Arrow;
        }


        //pencereyi hareket ettirmek için
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //--

        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //form ilk yüklenirken controllerin size ve locationları
            this.togglePanel.Visible = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            closeButton.Location = new Point(this.Width - this.closeButton.Size.Width-10, 10);
            maksminButton.Location = new Point(closeButton.Location.X - closeButton.Size.Width - 7, 10);
            minButton.Location = new Point(maksminButton.Location.X - maksminButton.Size.Width - 8, 10);
            saveButton.Location = new Point(minButton.Location.X - saveButton.Size.Width, 10);
            this.maksminButton.BackgroundImage = Properties.Resources.minimize;
            this.leftPanel.Focus();
            this.metroToggle8.Location = new Point(this.Size.Width - this.metroToggle8.Size.Width - 5, this.handButton.Location.Y);
            this.metroToggle8.Theme = MetroFramework.MetroThemeStyle.Dark;

            this.modelViewerControl1.Size = new Size(this.Size.Width - this.leftPanel.Size.Width, this.Size.Height - this.headerLabel.Size.Height + this.colorLabel.Size.Height);

            this.handButton.BringToFront();
            this.moveButton.BringToFront();
            this.turnButton.BringToFront();
            this.buyutButton.BringToFront();
            this.metroToggle8.BringToFront();

            
        }

        

        private void minButton_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void maksminButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized) //tam ekrandan çıkıldığında controllerin size ve locationları
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                this.maksminButton.BackgroundImage = Properties.Resources.square;

                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
                closeButton.Location = new Point(this.Width - this.closeButton.Size.Width - 10, 10);
                maksminButton.Location = new Point(closeButton.Location.X - closeButton.Size.Width - 7, 10);
                minButton.Location = new Point(maksminButton.Location.X - maksminButton.Size.Width - 8, 10);
                saveButton.Location = new Point(minButton.Location.X - saveButton.Size.Width, 10);
                this.metroToggle8.Location = new Point(this.Size.Width - this.metroToggle8.Size.Width - 5, this.handButton.Location.Y);
                this.modelViewerControl1.Size = new Size(this.Size.Width - this.leftPanel.Size.Width, this.Size.Height - this.headerLabel.Size.Height + this.colorLabel.Size.Height);
                this.leftPanel.Focus();
            }
            else //tam ekrana girildiğinde controllerin size ve locationları
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.maksminButton.BackgroundImage = Properties.Resources.minimize;

                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                closeButton.Location = new Point(this.Width - this.closeButton.Size.Width - 10, 10);
                maksminButton.Location = new Point(closeButton.Location.X - closeButton.Size.Width - 7, 10);
                minButton.Location = new Point(maksminButton.Location.X - maksminButton.Size.Width - 8, 10);
                saveButton.Location = new Point(minButton.Location.X - saveButton.Size.Width, 10);
                this.metroToggle8.Location = new Point(this.Size.Width - this.metroToggle8.Size.Width - 5, this.handButton.Location.Y);
                this.modelViewerControl1.Size = new Size(this.Size.Width - this.leftPanel.Size.Width, this.Size.Height - this.headerLabel.Size.Height + this.colorLabel.Size.Height);
                this.leftPanel.Focus();
            }
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            this.maksminButton.BackgroundImage = Properties.Resources.square;            
            closeButton.Location = new Point(this.Width - this.closeButton.Size.Width - 10, 10);
            maksminButton.Location = new Point(closeButton.Location.X - closeButton.Size.Width - 7, 10);
            minButton.Location = new Point(maksminButton.Location.X - maksminButton.Size.Width - 8, 10);
            saveButton.Location = new Point(minButton.Location.X - saveButton.Size.Width, 10);
            this.metroToggle8.Location = new Point(this.Size.Width - this.metroToggle8.Size.Width - 5, this.handButton.Location.Y);
            this.modelViewerControl1.Size = new Size(this.Size.Width - this.leftPanel.Size.Width, this.Size.Height - this.headerLabel.Size.Height + this.colorLabel.Size.Height);
            this.leftPanel.Focus();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            this.maksminButton.BackgroundImage = Properties.Resources.square;            
            closeButton.Location = new Point(this.Width - this.closeButton.Size.Width - 10, 10);
            maksminButton.Location = new Point(closeButton.Location.X - closeButton.Size.Width - 7, 10);
            minButton.Location = new Point(maksminButton.Location.X - maksminButton.Size.Width - 8, 10);
            saveButton.Location = new Point(minButton.Location.X - saveButton.Size.Width, 10);
            this.metroToggle8.Location = new Point(this.Size.Width - this.metroToggle8.Size.Width - 5, this.handButton.Location.Y);
            this.modelViewerControl1.Size = new Size(this.Size.Width - this.leftPanel.Size.Width, this.Size.Height - this.headerLabel.Size.Height + this.colorLabel.Size.Height);
            this.leftPanel.Focus();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.maksminButton.BackgroundImage = Properties.Resources.square;            
            closeButton.Location = new Point(this.Width - this.closeButton.Size.Width - 10, 10);
            maksminButton.Location = new Point(closeButton.Location.X - closeButton.Size.Width - 7, 10);
            minButton.Location = new Point(maksminButton.Location.X - maksminButton.Size.Width - 8, 10);
            saveButton.Location = new Point(minButton.Location.X - saveButton.Size.Width, 10);
            this.metroToggle8.Location = new Point(this.Size.Width - this.metroToggle8.Size.Width - 5, this.handButton.Location.Y);
            this.modelViewerControl1.Size = new Size(this.Size.Width - this.leftPanel.Size.Width, this.Size.Height - this.headerLabel.Size.Height + this.colorLabel.Size.Height);
            this.leftPanel.Focus();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.maksminButton.BackgroundImage = Properties.Resources.square;            
            closeButton.Location = new Point(this.Width - this.closeButton.Size.Width - 10, 10);
            maksminButton.Location = new Point(closeButton.Location.X - closeButton.Size.Width - 7, 10);
            minButton.Location = new Point(maksminButton.Location.X - maksminButton.Size.Width - 8, 10);
            saveButton.Location = new Point(minButton.Location.X - saveButton.Size.Width, 10);
            this.metroToggle8.Location = new Point(this.Size.Width - this.metroToggle8.Size.Width - 5, this.handButton.Location.Y);
            this.modelViewerControl1.Size = new Size(this.Size.Width - this.leftPanel.Size.Width, this.Size.Height - this.headerLabel.Size.Height + this.colorLabel.Size.Height);
            this.leftPanel.Focus();
        }
        

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);

            
        }

        private void metroToggle8_Click(object sender, EventArgs e)
        {
            if (togglePanel.Visible == true)
            {
                togglePanel.Visible = false;
                metroToggle8.SendToBack();
                this.metroToggle8.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.leftPanel.Focus();
                this.metroToggle8.BringToFront();
            }
            else
            {
                togglePanel.Visible = true;
                metroToggle8.BringToFront();
                this.metroToggle8.Theme = MetroFramework.MetroThemeStyle.Light;
                this.togglePanel.BringToFront();
                this.leftPanel.Focus();
                this.metroToggle8.BringToFront();
            }
        }

        

        private void objectButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            // Default to the directory which contains our content files.
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string relativePath = Path.Combine(assemblyLocation, "../../../../Content");
            string contentPath = Path.GetFullPath(relativePath);

            fileDialog.InitialDirectory = contentPath;

            fileDialog.Title = "Load Model";

            fileDialog.Filter = "Model Files (*.fbx;*.x)|*.fbx;*.x|" +
                                "FBX Files (*.fbx)|*.fbx|" +
                                "X Files (*.x)|*.x|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadModel(fileDialog.FileName);
            }
        }
    }
}
