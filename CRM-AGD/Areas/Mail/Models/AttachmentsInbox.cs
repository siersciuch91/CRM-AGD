using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_AGD.Areas.Mail.Models
{
  public class AttachmentsInbox
  {
    public int AttachmentsInboxId { get; set; }
    public int InboxId { get; set; }
    [Column(TypeName = "image")]
    public Byte[] AttachmentData { get; set; }
  }
}
