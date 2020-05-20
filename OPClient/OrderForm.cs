using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPClient.OrderProcessingService;



namespace OPClient
{
    public partial class OrderForm : Form
    {

        private OrderClient mdb;
        bool adding;

        public OrderForm()
        {
            InitializeComponent();
            mdb = new OrderClient();
            adding = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String nm = mdb.getCustomer("1");
            tbxCName.Text = nm;
            tbxCid.Text = "1";

            btnBuy.Enabled = false;
            btnCancel.Enabled = false;

            string [] p = mdb.getProductIds();
            foreach (String s in p)
            {
                cmbPid.Items.Add(s);
            }
            cmbPid.SelectedIndex = 0;

        }

        private void cmbOid_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstOrders.Items.Clear();
            String item = cmbOid.Text;
            String [] l = mdb.getOrderDetails(item);

            foreach (String s in l)
                lstOrders.Items.Add(s);

        }

        private void cmbPid_SelectedIndexChanged(object sender, EventArgs e)
        {
            String item = (String)cmbPid.SelectedItem;
            String s = mdb.getProductDetail(item);
            String[] fs = s.Split(',');
            tbxDescription.Text = fs[0];
            float p = float.Parse(fs[1]);
            tbxPrice.Text = String.Format("{0:f2}", p);
            tbxOnhand.Text = fs[2];
            tbxQuantity.Text = "1";
        }

        private void tbxCid_TextChanged(object sender, EventArgs e)
        {
            cmbOid.Items.Clear();
            String id = tbxCid.Text;
            if (id.Length > 0)
            {
                String [] o = mdb.getCustomerOrders(id);
                foreach (String s in o)
                    cmbOid.Items.Add(s);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!adding)
            {
                btnBuy.Enabled=true;
                btnCancel.Enabled=true;
                
                cmbOid.Enabled = false;
                lstOrders.Items.Clear();
            }
            String s = String.Format("{0},{1},{2},{3}", cmbPid.SelectedItem.ToString(), tbxDescription.Text, tbxPrice.Text, tbxQuantity.Text);
            lstOrders.Items.Add(s);
            adding = true;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String nm = mdb.getCustomer(tbxCid.Text);
            tbxCName.Text = nm;
            cmbOid.Items.Clear();
            String id = tbxCid.Text;
            if (id.Length > 0)
            {
                String []  o = mdb.getCustomerOrders(id);
                foreach (String s in o)
                    cmbOid.Items.Add(s);
                cmbOid.SelectedIndex = 0;
            }
            
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            String [] od = new String[lstOrders.Items.Count];

            for (int i = 0; i < lstOrders.Items.Count; i++)
                od[i] = lstOrders.Items[i].ToString();
            mdb.Purchase(tbxCid.Text, od);
            btnBuy.Enabled = false;
            btnCancel.Enabled = false;
            cmbOid.Enabled = true;

            btnSearch_Click(this, null);
            cmbOid.SelectedIndex = cmbOid.Items.Count - 1;
            adding = false;
        }
    }
}
