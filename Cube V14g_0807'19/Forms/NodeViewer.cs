using Cube_V11.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cube_V11.Forms
{
    public partial class NodeViewer : Form
    {
        public NodeViewer(List<Node> list)
        {
            InitializeComponent();

            dataGridView1.DataSource = list;
        }
    }
}
