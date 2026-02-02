using libraryProject;
using libraryProject.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using User = libraryProject.User;

namespace libraryProject
{

    public partial class FormBook : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormBook(User user, bool guest)
        {
            InitializeComponent();

            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "Фото";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 30;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "Информация";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;



            dgvBook.Columns.AddRange(
            [
                colPhoto, colInfo
            ]);

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.UserName;

            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (var db = new LibraryKiselevContext())
                {
                    var products = db.Books
                       .Include(i => i.BooksLoans)
                       .Include(i => i.Creator)
                       .Include(i => i.Ganre)
                       .Include(i => i.PublishingHouse)
                       .ToList();

                    dgvBook.SuspendLayout();
                    dgvBook.Rows.Clear();

                    foreach (var product in products)
                    {
                        int rowIndex = dgvBook.Rows.Add();
                        var row = dgvBook.Rows[rowIndex];

                        row.Cells["Фото"].Value = LoadProductImage(product.Photo);

                        row.Cells["Информация"].Value = FormatProductInfo(product);
                        ApplyRowStyles(row, product);
                    }

                    dgvBook.ResumeLayout();
                    dgvBook.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRowStyles(DataGridViewRow row, Book product)
        {
            if (product.All == 0)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFCCCC");
            }
            else
            if (product.All == 1 || product.All == 2)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
            }
            else
            {
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
                foreach (var Lons in product.BooksLoans)
                {
                    if (Lons.IdGive == product.Id && Lons.ActualReturnDate == null)
                    {
                        DateOnly dateIssue = Lons.DateOfIssue;

                        int daysDifference = currentDate.DayNumber - dateIssue.DayNumber;
                        if (daysDifference > 30)
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA");
                            break;
                        }
                    }
                }
            } 
        }

        private object? FormatProductInfo(Book product)
        {
            return $"{product.Isbn}" + Environment.NewLine +
                $"Название книги:{product.NameBook}" + Environment.NewLine +
                $"Автор: {product.Creator.Creator1}" + Environment.NewLine +
                $"Жанр: {product.Ganre.GenreBook}" + Environment.NewLine +
                $"Издательство: {product.PublishingHouse.HousePublishing}" + Environment.NewLine +
                $"Год издания{product.YearOfPublication}" + Environment.NewLine +
                $"Страниц: {product.Paper}" + Environment.NewLine +
                $"Всего экземпляр: {product.All}" + Environment.NewLine +
                $"Доступно: {product.Available}" + Environment.NewLine +
                $"Аннотация: {product.Annotation}";
        }

        private Image LoadProductImage(string photoUrl)
        {
            if (!String.IsNullOrEmpty(photoUrl))
            {
                object obj = Resources.ResourceManager.GetObject(photoUrl);
                if (obj is Image i)
                {
                    return i;
                }
            }

            return Resources.picture;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }
    }
}
