﻿namespace BookingProject.Application.Features.CQRS.Results.ContactResults
{
    public class GetContactQueryResult
    {
        public int ContactID { get; set; }
        public string NameSurname { get; set; }
        public string Subject { get; set; }
        public string Mail { get; set; }
        public string MessageContent { get; set; }
        public DateTime SendDate { get; set; }
    }
}
