using System.Collections.ObjectModel;

namespace Latih8_WinformGrid2
{
    public partial class Form1 : Form
    {
        private List<SiswaModel> _listSiswa;
        private BindingSource _bindingSource;

        public Form1()
        {
            InitializeComponent();
            GenerateData();
        }

        public void GenerateData()
        {
            _listSiswa = new List<SiswaModel>
            {
                new SiswaModel("24001", "Agus Binawan", new DateTime(2010,3,1), "Laki-Laki", "Puri Indah Santoso C4, Bantul", "RPL"),
                new SiswaModel("24002", "Budi Cahyadi", new DateTime(2010,5,11), "Laki-Laki", "Mranggen CT4/211, Jogjakarta", "RPL"),
                new SiswaModel("24003", "Candra Darmawan", new DateTime(2010,9,13), "Laki-Laki", "Jl.Sukun Raya 241, Sleman", "TKJ"),
                new SiswaModel("24004", "Desya Saputri", new DateTime(2010,1,9), "Perempuan", "Perum Kelapa Gadin E/3, Jogjakarta", "TKI"),
                new SiswaModel("24005", "Etik Sukmasari", new DateTime(2010,7,21), "Perempuan", "Prawirotaman MG-V/221, Jogjakarta", "KEU"),
                new SiswaModel("24006", "Firman Sihombing", new DateTime(2010,3,9), "Laki-Laki", "Kraton CT4/212, Jogjakarta", "KEU"),
                new SiswaModel("24007", "Ghina Putri", new DateTime(2010,12,4), "Perempuan", "Jl.Kaliurang Km 3, Sleman", "RPL"),
                new SiswaModel("24008", "Heri Susanto", new DateTime(2010,6,18), "Laki-Laki", "Jl.Kusbini 141, Jogjakarta", "TKJ"),
                new SiswaModel("24009", "Ivan Prasetyo", new DateTime(2010,7,23), "Laki-Laki", "Pelem Legi-1, Parangtritis", "TKI"),
                new SiswaModel("24010", "Jessica Puspita", new DateTime(2010,1,31), "Perempuan", "Suryatmajan GT-V/311, Jogjakarta", "TKI"),
            };
            _bindingSource = new BindingSource();
            _bindingSource.DataSource = _listSiswa;

            comboBox1.Items.Add("Laki-Laki");
            comboBox1.Items.Add("Perempuan");

            comboBox2.Items.Add("RPL");
            comboBox2.Items.Add("TKJ");
            comboBox2.Items.Add("TKI");
            comboBox2.Items.Add("KEU");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _bindingSource;
            dataGridView1.Columns["NIS"].Width = 50;
            dataGridView1.Columns["Nama"].Width = 150;
            dataGridView1.Columns["TglLahir"].Width = 100;
            dataGridView1.Columns["Gender"].Width = 100;
            dataGridView1.Columns["Alamat"].Width = 150;
            dataGridView1.Columns["Jurusan"].Width = 100;
            dataGridView1.Columns["TglLahir"].DefaultCellStyle.Format = "dd-MM-yyyy";
        }

        //  bind selected row to textboxes
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            var nis = dataGridView1.CurrentRow.Cells["NIS"].Value.ToString();
            var siswa = _listSiswa.FirstOrDefault(x => x.NIS == nis);

            textBox1.Text = siswa.NIS;
            textBox2.Text = siswa.Nama;
            dateTimePicker1.Value = siswa.TglLahir;
            comboBox1.Text = siswa.Gender;
            textBox3.Text = siswa.Alamat;
            comboBox2.Text = siswa.Jurusan;
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            _listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).Nama = textBox2.Text;
            dataGridView1.Refresh();
        }


        private void textBox3_Validated(object sender, EventArgs e)
        {
            _listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).Alamat = textBox3.Text;
            dataGridView1.Refresh();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).TglLahir = dateTimePicker1.Value;
            dataGridView1.Refresh();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).Jurusan = comboBox2.Text;
            dataGridView1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _listSiswa.FirstOrDefault(x => x.NIS == textBox1.Text).Gender = comboBox1.Text;
            dataGridView1.Refresh();

        }
    }
}
