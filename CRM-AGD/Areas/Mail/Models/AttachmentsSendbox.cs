using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_AGD.Areas.Mail.Models
{
  public class AttachmentsSendbox
  {
    public int AttachmentsSendboxId { get; set; }
    public int SendboxId { get; set; }
    [Column(TypeName = "image")]
    public Byte[] AttachmentData { get; set; }
  }
}
