using Microsoft.Data.SqlClient;
using ORM;
using ORM.Interfaces;
using System.Data;
using OfficeOpenXml;
using iTextSharp;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Entities.EntityFabrics
{
    public class AbonentAccountingFabric : IEntityFabric<AbonentAccounting>
    {
        public SqlConnection Connection { get; set; }
        private string _table;
        private BookFabric _bookFabric;
        private AbonentFabric _abonentFabric;
        public AbonentAccountingFabric(SqlConnection connection)
        {
            Connection = connection;
            _bookFabric = new BookFabric(Connection);
            _abonentFabric = new AbonentFabric(Connection);
            var tableAttribute = typeof(AbonentAccounting).GetCustomAttribute<DataTableName>() ?? new DataTableName("AbonentAccountings");
            _table = tableAttribute.Name;
        }

        public void Delete(int id)
        {
            string commandText = $"delete from {_table} where Id={id}";
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.ExecuteNonQuery();
        }
        public void Insert(AbonentAccounting entity)
        {
            string commandText = $"insert into {_table} (AbonentId, BookId, TakeDate, IsBookReturned, BookCondition) " +
                $"values (@abonentId, @bookId, @takeDate, @isBookReturned, @bookCondition)";
            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter abonentId = new SqlParameter("@abonentId", entity.Abonent.Id);
            SqlParameter bookId = new SqlParameter("@bookId", entity.Book.Id);
            SqlParameter takeDate = new SqlParameter("@takeDate", entity.TakeDate);
            SqlParameter isBookReturned = new SqlParameter("@isBookReturned", entity.IsBookReturned);
            SqlParameter bookCondition = new SqlParameter("bookCondition", entity.BookCondition);
            command.Parameters.AddRange(new SqlParameter [] { abonentId, bookId, takeDate, isBookReturned, bookCondition });
            
            command.ExecuteNonQuery();
        }
        public List<AbonentAccounting> ReadAll()
        {
            string commandString = $"select * from {_table}";
            SqlCommand command = new SqlCommand(commandString, Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            List<AbonentAccounting> list = new List<AbonentAccounting>();
            DataRowCollection rows = dataTable.Rows;

            foreach (DataRow row in rows)
            {
                int abonentId = (int)row.ItemArray[1];
                int bookId = (int)row.ItemArray[2];
                DateTime takeDate = (DateTime)row.ItemArray[3];
                bool isBookReturned = (bool)row.ItemArray[4];
                string bookCondition = row.ItemArray[5].ToString();

                AbonentAccounting abonentAccounting = new AbonentAccounting(_abonentFabric.Read(abonentId),
                    _bookFabric.Read(bookId), takeDate, isBookReturned, bookCondition);
                list.Add(abonentAccounting);
            }
            return list;
        }

        public AbonentAccounting Read(int id)
        {
            string commandString = $"select * from {_table} where Id=@id";
            SqlCommand command = new SqlCommand(commandString, Connection);
            command.Parameters.Add(new SqlParameter("@id", id));

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];

            DataRow row = dataTable.Rows[0];
            int abonentId = (int)row.ItemArray[1];
            int bookId = (int)row.ItemArray[2];
            DateTime takeDate = (DateTime)row.ItemArray[3];
            bool isBookReturned = (bool)row.ItemArray[4];
            string bookCondition = row.ItemArray[5].ToString();

            AbonentAccounting abonentAccounting = new AbonentAccounting(_abonentFabric.Read(abonentId),
                _bookFabric.Read(bookId), takeDate, isBookReturned, bookCondition);

            return abonentAccounting;
        }

        public void Update(int id, AbonentAccounting newEntity)
        {
            string commandText = $"update {_table} set AbonentId=@abonentId, BookId=@bookId," +
                $"IsBookReturned=@isBookReturned, BookCondition=@bookCondition where id=@id";

            SqlCommand command = new SqlCommand(commandText, Connection);
            SqlParameter abonentId = new SqlParameter("@abonentId", newEntity.Abonent.Id);
            SqlParameter bookId = new SqlParameter("@bookId", newEntity.Book.Id);
            SqlParameter isBookReturned = new SqlParameter("@isBookReturned", newEntity.IsBookReturned);
            SqlParameter bookCondition = new SqlParameter("@bookCondition", newEntity.BookCondition);
            SqlParameter idParameter = new SqlParameter("@id", id);

            command.Parameters.AddRange(new SqlParameter[] { abonentId, bookId, isBookReturned, bookCondition, idParameter });
            command.ExecuteNonQuery();
        }

        public void GetTextReport(DateTime date1, DateTime date2)
        {
            var dict = GetBookTakeCount(date1, date2);
            
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/report.txt";
            string text = "Book\tCountOfTake";
            foreach(KeyValuePair<string, int> keyValuePair in dict)
            {
                text += "\n" + keyValuePair.Key + "\t" + keyValuePair.Value;
            }
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(text);
            }

        }
        public void GetExcelReport(DateTime date1, DateTime date2)
        {
            var dict = GetBookTakeCount(date1, date2);
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/report.xlsx";

            using(ExcelPackage ep = new ExcelPackage(path))
            {
                ExcelWorksheet excelWorksheet = ep.Workbook.Worksheets.Add("Sheet 1");

                excelWorksheet.Cells[1, 1].Value = "Book";
                excelWorksheet.Cells[1, 2].Value = "CountOfTake";

                int i = 2;
                foreach(KeyValuePair<string, int> keyValuePair in dict)
                {
                    excelWorksheet.Cells[i, 1].Value = keyValuePair.Key;
                    excelWorksheet.Cells[i, 2].Value = keyValuePair.Value;
                    i++;
                }

                FileInfo fi = new FileInfo(path);
                ep.SaveAs(fi);
            }
            
        }
        public void GetPdfReport(DateTime date1, DateTime date2)
        {
            var dict = GetBookTakeCount(date1, date2);
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/report.pdf";

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            PdfPTable pdfPTable = new PdfPTable(2);
            PdfPCell cell = new PdfPCell(new Phrase("List of books and count of their taking"));

            cell.Colspan = 2;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            pdfPTable.AddCell(cell);

            cell = new PdfPCell(new Phrase(new Phrase("Book")));
            pdfPTable.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase("Count of take")));
            pdfPTable.AddCell(cell);

            foreach(KeyValuePair<string, int> keyValuePair in dict)
            {
                pdfPTable.AddCell(new PdfPCell(new Phrase(keyValuePair.Key)));
                pdfPTable.AddCell(new PdfPCell(new Phrase(keyValuePair.Value.ToString())));
            }

            doc.Add(pdfPTable);

            doc.Close();
        }
        public void Dispose()
        {
            Connection.Close();
        }

        private Dictionary<string, int> GetBookTakeCount(DateTime date1, DateTime date2)
        {
            List<AbonentAccounting> list = ReadAll();

            List<AbonentAccounting> sortedList = list.FindAll(x => x.TakeDate > date1 && x.TakeDate < date2).OrderBy(x => x.Book.Genre.Name).ToList();
            BookFabric bookFabric = new BookFabric(Connection);
            List<Book> books = bookFabric.ReadAll();
            Dictionary<string, int> bookAndCount = new Dictionary<string, int>();
            foreach (Book book in books)
            {
                int count = sortedList.FindAll(x => x.Book.Name == book.Name).Count;
                bookAndCount.Add(book.Name, count);
            }
            return bookAndCount;
        }
    }
}
