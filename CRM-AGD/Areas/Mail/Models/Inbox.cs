using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_AGD.Areas.Mail.Models
{
  public class Inbox
  {
    public int InboxId { get; set; }
    public string MailFrom { get; set; }
    public string MailTo { get; set; }
    public DateTime Date { get; set;}
    public string Tittle { get; set; }
    public string Message { get; set; }
    public string MessageHtml { get; set; }
  }
}
