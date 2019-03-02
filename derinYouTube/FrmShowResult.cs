using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using derinYouTube.Extensions;
using derinYouTube.ViewModels;

namespace derinYouTube
{
    public partial class FrmShowResult : Form
    {
        private List<ChatsViewModel> _items;

        public FrmShowResult(List<ChatsViewModel> list)
        {
            InitializeComponent();
            _items = list;
            this.dgwResult.DoubleBuffered(true);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void FrmShowResult_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dgwResult.DataSource = _items.OrderBy(x => x.PublishedAt).ToSortableGridList();
            dgwResult.FormatGrid();
            dgwResult.Columns["AuthorChannelId"].Visible = false;
            dgwResult.Columns["AuthorChannelUrl"].Visible = false;
            this.Cursor = Cursors.Default;
        }
    }
}
