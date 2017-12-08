using AutoMapper;
using HM_API_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.IO;
using System.Net.Http.Headers;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace HM_API_V3.Controllers
{
    public class AccountController : BaseController
    {
        #region C R U D

        public Response<IEnumerable<AccountDTO>> Get()
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbVaccines = entities.Accounts.ToList();
                    IEnumerable<AccountDTO> AccountDTOs = Mapper.Map<IEnumerable<AccountDTO>>(dbVaccines);
                    return new Response<IEnumerable<AccountDTO>>(true, null, AccountDTOs);
                }
            }
            catch (Exception e)
            {
                return new Response<IEnumerable<AccountDTO>>(false, GetMessageFromExceptionObject(e), null);
            }
        }

        public Response<AccountDTO> Get(int Id)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbVaccine = entities.Accounts.Where(c => c.Id == Id).FirstOrDefault();
                    AccountDTO AccountDTO = Mapper.Map<AccountDTO>(dbVaccine);
                    return new Response<AccountDTO>(true, null, AccountDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<AccountDTO>(false, GetMessageFromExceptionObject(e), null);
            }

        }

        public Response<AccountDTO> Post(AccountDTO AccountDTO)
        {

            try
            {

                using (HMEntities1 entities = new HMEntities1())
                {
                    Account accountDB = Mapper.Map<Account>(AccountDTO);
                    entities.Accounts.Add(accountDB);
                    entities.SaveChanges();

                    accountDB = entities.Accounts.Where(x => x.Id == accountDB.Id).FirstOrDefault();
                    AccountDTO.Id = accountDB.Id;
                    AccountDTO.Created = accountDB.Created;
                    AccountDTO.Balance = accountDB.Balance;

                    return new Response<AccountDTO>(true, null, AccountDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<AccountDTO>(false, GetMessageFromExceptionObject(e), null);
            }
        }
        public Response<AccountDTO> Put(int Id, AccountDTO AccountDTO)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbVaccine = entities.Accounts.Where(c => c.Id == Id).FirstOrDefault();
                    if (dbVaccine == null)
                        return new Response<AccountDTO>(false, "Account not found", null);
                    dbVaccine = Mapper.Map<AccountDTO, Account>(AccountDTO, dbVaccine);
                    entities.SaveChanges();
                    return new Response<AccountDTO>(true, null, AccountDTO);
                }
            }
            catch (Exception e)
            {
                return new Response<AccountDTO>(false, GetMessageFromExceptionObject(e), null);
            }
        }

        public Response<string> Delete(int Id)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var dbVaccine = entities.Accounts.Where(c => c.Id == Id).FirstOrDefault();
                    entities.Accounts.Remove(dbVaccine);
                    entities.SaveChanges();
                    return new Response<string>(true, null, "record deleted");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                    return new Response<string>(false, "Cannot delete Account because related record exists in database.", null);
                else
                    return new Response<string>(false, GetMessageFromExceptionObject(ex), null);
            }
        }

        #endregion

        [Route("api/account/{id}/transactions")]
        public Response<IEnumerable<TransactionDTO>> GetTransactions(int id)
        {
            try
            {
                using (HMEntities1 entities = new HMEntities1())
                {
                    var account = entities.Accounts.FirstOrDefault(c => c.Id == id);
                    if (account == null)
                        return new Response<IEnumerable<TransactionDTO>>(false, "Account not found", null);
                    else
                    {
                        var dbTransactions = account.Transactions.ToList();
                        var transactionDTOs = Mapper.Map<List<TransactionDTO>>(dbTransactions);
                        return new Response<IEnumerable<TransactionDTO>>(true, null, transactionDTOs);
                    }
                }
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<TransactionDTO>>(false, GetMessageFromExceptionObject(ex), null);
            }
        }

        
        public decimal getRowTotalUsingIndex(int index,long id)
        {
            HMEntities1 entities = new HMEntities1();
            var accounts = entities.Transactions.Where(a => a.AccountID == id).ToList();
            decimal sum = 0;
            for (int i = 0; i <= index; i++)
            {
                sum += accounts[i].Amount;
            }
            return sum;
        }
        [HttpGet]
        //[Route("~/api/child/{id}/Download-Schedule-PDF")]
        [Route("~/api/account/DownloadLogPDF/{id}")]
        public HttpResponseMessage DownloadLogPDF(int id)
        {
            Transaction transaction;

            HMEntities1 entities = new HMEntities1();

            transaction = entities.Transactions.Where(x => x.AccountID == id).FirstOrDefault();

            var stream = CreateSchedulePdf(id);

            return new HttpResponseMessage
            {
                Content = new StreamContent(stream)
                {
                    Headers = {
                                ContentType = new MediaTypeHeaderValue("application/pdf"),
                                ContentDisposition = new ContentDispositionHeaderValue("attachment") {
                                    FileName = transaction.Account.Name.Replace(" ","")+"_Balance Statement_" +DateTime.Now.ToString("MMMM-dd-yyyy")+ ".pdf"
                                }
                            }
                },
                StatusCode = HttpStatusCode.OK
            };
        }

        protected PdfPCell CreateCell(string value, string color, int colpan, string alignment, string table)
        {

            Font font = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            if (color == "bold")
            {
                font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            }

            PdfPCell cell = new PdfPCell(new Phrase(value, font));
            if (color == "backgroudLightGray")
            {
                cell.BackgroundColor = GrayColor.LIGHT_GRAY;
            }
            if (alignment == "right")
            {
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            if (alignment == "left")
            {
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
            }
            if (alignment == "center")
            {
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
            }
            cell.Colspan = colpan;
            if (table == "description")
            {
                cell.Border = 0;
                cell.Padding = 2f;
            }
            return cell;

        }

        private static void GetPDFHeading(Document document, String headingText)
        {
            Font ColFont = FontFactory.GetFont(FontFactory.HELVETICA, 30, Font.BOLD);
            Chunk chunkCols = new Chunk(headingText, ColFont);
            Paragraph chunkParagraph = new Paragraph();
            chunkParagraph.Alignment = Element.ALIGN_CENTER;
            chunkParagraph.Add(chunkCols);
            document.Add(chunkParagraph);
            document.Add(new Paragraph(""));
            document.Add(new Chunk("\n"));
        }


        private Stream CreateSchedulePdf(int AccountId)
        {
            //Access db data
            HMEntities1 entities = new HMEntities1();
            var account = entities.Accounts.SingleOrDefault(a => a.Id == AccountId);

            int count = 0;
            //
            using (var document = new Document(PageSize.A4, 50, 50, 25, 25))
            {
                var output = new MemoryStream();

                var writer = PdfWriter.GetInstance(document, output);
                writer.CloseStream = false;

                document.Open();
                GetPDFHeading(document, "Balance Sheet");

                //Table 1 for description above Schedule table
                PdfPTable upperTable = new PdfPTable(2);
                float[] upperTableWidths = new float[] { 250f, 250f };
                upperTable.HorizontalAlignment = 0;
                upperTable.TotalWidth = 500f;
                upperTable.LockedWidth = true;
                upperTable.SetWidths(upperTableWidths);
                upperTable.AddCell(CreateCell("Date:", "bold", 1, "left", "description"));
                upperTable.AddCell(CreateCell(DateTime.Now.ToString("MMMM-dd-yyyy").ToString(), "", 1, "right", "description"));


                upperTable.AddCell(CreateCell("Name :", "bold", 1, "left", "description"));
                upperTable.AddCell(CreateCell(account.Name, "", 1, "right", "description"));

                upperTable.AddCell(CreateCell("Account #: ", "bold", 1, "left", "description"));

                //upperTable.AddCell(CreateCell("Father: " + dbChild.FatherName, "", 1, "right", "description"));
                upperTable.AddCell(CreateCell(account.Number, "", 1, "right", "description"));

                upperTable.AddCell(CreateCell("Address: ", "bold", 1, "left", "description"));
                upperTable.AddCell(CreateCell(account.Address, "", 1, "right", "description"));

                upperTable.AddCell(CreateCell("Balance: ", "bold", 1, "left", "description"));
                upperTable.AddCell(CreateCell(account.Balance.ToString(), "", 1, "right", "description"));

                //upperTable.AddCell(CreateCell("Child: " + dbChild.Name, "", 1, "right", "description"));
                //upperTable.AddCell(CreateCell(dbChild.User.MobileNumber, "", 1, "right", "description"));

                //upperTable.AddCell(CreateCell("Doctor Ph: " + dbDoctor.PhoneNo, "", 1, "left", "description"));
                //upperTable.AddCell(CreateCell("", "", 1, "right", "description"));
                document.Add(upperTable);
                //
                document.Add(new Paragraph(""));
                document.Add(new Chunk("\n"));
                //Schedule Table
                float[] widths = new float[] { 30f, 100f, 100f, 50f, 50f, 70f, 100f };

                PdfPTable table = new PdfPTable(6);
                table.HorizontalAlignment = 0;
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                // table.SetWidths(widths);

                table.AddCell(CreateCell("S#", "backgroudLightGray", 1, "center", "scheduleRecords"));

                table.AddCell(CreateCell("Transaction Date", "backgroudLightGray", 1, "center", "scheduleRecords"));
                table.AddCell(CreateCell("Description", "backgroudLightGray", 1, "center", "scheduleRecords"));

                table.AddCell(CreateCell("Expense", "backgroudLightGray", 1, "center", "scheduleRecords"));
                table.AddCell(CreateCell("Income", "backgroudLightGray", 1, "center", "scheduleRecords"));
                table.AddCell(CreateCell("Balance", "backgroudLightGray", 1, "center", "scheduleRecords"));

                // var imgPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/img");

                var transactions = entities.Transactions.Where(t => t.AccountID == AccountId).ToList();
                foreach (var t in transactions)
                {
                    //PdfPCell cell = new PdfPCell(new Phrase(schedule.Date.Date.ToString("dd-MM-yyyy")));
                    //cell.Colspan = 2;
                    //cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    //cell.Border = 0;
                    //table.AddCell(cell);


                    count++;
                    table.AddCell(CreateCell(count.ToString(), "", 1, "center", "scheduleRecords"));
                    //table.AddCell(CreateCell(transactions.Name, "", 1, "", "scheduleRecords"));


                    table.AddCell(CreateCell(t.Date.ToString("dd-MM-yyyy"), "", 1, "", "scheduleRecords"));
                    table.AddCell(CreateCell(t.Description.ToString(), "", 1, "", "scheduleRecords"));

                    if (t.Amount < 0)
                    {
                        table.AddCell(CreateCell(t.Amount.ToString(), "", 1, "", "scheduleRecords"));

                    }
                    else
                    {
                        table.AddCell(CreateCell(0.ToString(), "", 1, "", "scheduleRecords"));

                    }



                    if (t.Amount >= 0)
                    {
                        table.AddCell(CreateCell(t.Amount.ToString(), "", 1, "", "scheduleRecords"));

                    }
                    else
                    {
                        table.AddCell(CreateCell(0.ToString(), "", 1, "", "scheduleRecords"));

                    }

                    int index = count - 1;
                    decimal balance = getRowTotalUsingIndex(index, t.AccountID);

                    table.AddCell(CreateCell(balance.ToString(), "", 1, "", "scheduleRecords"));

                    //if (t.Amount < 0)
                    //    table.AddCell(CreateCell(0.ToString(), "", 1, "", "scheduleRecords"));

                    //if (t.Amount >= 0)
                    //    table.AddCell(CreateCell(0.ToString(), "", 1, "", "scheduleRecords"));

                    //table.AddCell(CreateCell(" ", "", 1, "", "scheduleRecords"));





                    //  imageCell.setHorizontalAlignment(Element.ALIGN_CENTER);

                }

                document.Add(table);
                document.Close();

                output.Seek(0, SeekOrigin.Begin);

                return output;
            }
        }

    }
}
