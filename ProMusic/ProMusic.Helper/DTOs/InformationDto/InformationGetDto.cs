using System;
namespace ProMusic.Helper.DTOs.InformationDto
{
    public class InformationGetDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool IsDeleted { get; set; }
    }
}
