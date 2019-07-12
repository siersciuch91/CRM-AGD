using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRM_AGD.Areas.Mail.Models
{
  public class Inbox
  {
    public int InboxId { get; set; }

    [DisplayName("Mail from")]
    [StringLength(50)]
    public string MailFrom { get; set; }

    [DisplayName("Mail to")]
    [StringLength(50)]
    public string MailTo { get; set; }

    [DisplayName("Date")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [DisplayName("Tittle")]
    [StringLength(255)]
    public string Tittle { get; set; }

    [DisplayName("Message")]
    public string Message { get; set; }

    public string MessageHtml { get; set; }

    public int? ClientId { get; set; }

    [DisplayName("Client")]
    public CRM_AGD.Areas.Client.Models.Client client { get; set; }
  }
}
