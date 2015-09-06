using System;
using System.ComponentModel.DataAnnotations;

namespace QuestEngine.ViewModels
{
    public class RiddlesViewModel
    {
        public int RiddleNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}")]
        public DateTime StatTime { get; set; }
    }
}