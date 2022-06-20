using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAspNetCore
{
    public partial class Form1 : Form
    {
        private readonly ILogger _logger;

        public Form1(ILogger<Form1> logger)
        {
            InitializeComponent();
            _logger = logger;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async();
            webView21.CoreWebView2.Navigate("http://localhost:5000/swagger/index.html");
        }
    }
}
