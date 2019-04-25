using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_AGD.Areas.Mail.Models
{
    public class AttachmentsInbox
  {
    public int AttachmentsInboxId { get; set; }
    public int InboxId { get; set; }
    [Column(TypeName = "image")]
    public Byte[] AttachmentData { get; set; }

    public Inbox inbox { get; set; }
  }
}
