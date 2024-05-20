using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASAHOGAR
{
    internal class DataGridViewPrinter
    {
        private DataGridView dataGridView;
        private PrintDocument printDocument = new PrintDocument();
        private int currentPage = 0;
        private int rowIndex = 0;
        private bool firstPage = true;

        public PrintDocument PrintDocument
        {
            get { return printDocument; }
        }

        public DataGridViewPrinter(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int rowsPerPage = 0;
            int columnsPerPage = 0;

            if (firstPage)
            {
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    if (column.Visible)
                        columnsPerPage++;
                }
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Visible)
                        rowsPerPage++;
                }
                firstPage = false;
            }

            int totalWidth = 0;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Visible)
                    totalWidth += column.Width;
            }

            int totalHeight = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Visible)
                    totalHeight += row.Height;
            }

            int headerHeight = (int)(e.Graphics.MeasureString(dataGridView.Name, dataGridView.Font).Height + 20);
            int rowHeight = (int)dataGridView.Rows[0].Height;
            int startY = headerHeight + (rowIndex * rowHeight);

            RectangleF marginBounds = e.MarginBounds; // Copia local de MarginBounds

            while (rowIndex < dataGridView.Rows.Count)
            {
                if (startY + rowHeight > marginBounds.Height + marginBounds.Top)
                {
                    currentPage++;
                    rowIndex = 0;
                    e.HasMorePages = true;
                    return;
                }

                if (rowIndex == 0)
                {
                    foreach (DataGridViewColumn column in dataGridView.Columns)
                    {
                        if (column.Visible)
                        {
                            e.Graphics.DrawString(column.HeaderText, dataGridView.Font, Brushes.Black, new RectangleF(marginBounds.Left, marginBounds.Top, column.Width, headerHeight), StringFormat.GenericDefault);
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)marginBounds.Left, (int)marginBounds.Top, column.Width, headerHeight));
                            e.Graphics.DrawLine(Pens.Black, new Point((int)marginBounds.Left, (int)marginBounds.Top + headerHeight), new Point((int)marginBounds.Left + totalWidth, (int)marginBounds.Top + headerHeight));
                            marginBounds = new RectangleF(marginBounds.Left + column.Width, marginBounds.Top, marginBounds.Width - column.Width, marginBounds.Height);
                        }
                    }
                }

                DataGridViewRow row = dataGridView.Rows[rowIndex];
                if (row.Visible)
                {
                    int startX = (int)marginBounds.Left;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Visible)
                        {
                            e.Graphics.DrawString(cell.Value.ToString(), dataGridView.Font, Brushes.Black, new RectangleF(startX, startY, cell.OwningColumn.Width, rowHeight), StringFormat.GenericDefault);
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(startX, startY, cell.OwningColumn.Width, rowHeight));
                            startX += cell.OwningColumn.Width;
                        }
                    }
                    startY += rowHeight;
                }
                rowIndex++;
            }

            rowIndex = 0;
            currentPage = 0;
            firstPage = true;
            e.HasMorePages = false;
        }

        public void Print()
        {
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

    }
}
