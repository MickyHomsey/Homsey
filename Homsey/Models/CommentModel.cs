using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Homsey.Core.Entities;

namespace Homsey.Models
{
  public class CommentModel
  {
    [DisplayName("Name")]
    [Required(ErrorMessage = "Please provide your name")]
    public string Name { get; set; }

    [DisplayName("Email")]
    [Required(ErrorMessage = "Please provide your email")]
    public string Email { get; set; }

    [DisplayName("Comment")]
    [Required(ErrorMessage = "Please leave a comment")]
    public string Remark { get; set; }

    [DisplayName("Date Stamp")]
    public DateTime DateStamp { get; set; }
  }
}