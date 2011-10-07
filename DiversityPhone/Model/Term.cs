﻿namespace DiversityPhone.Model
{
    using System;
    using System.Data.Linq.Mapping;
    using Microsoft.Phone.Data.Linq.Mapping;

    [Table]
    [Index(Columns = "LastUsed", IsUnique = false, Name = "term_lastusage")]
    [Index(Columns = "ParentCode", IsUnique = false, Name = "term_inheritance")]
    public class Term
    {
        public static readonly DateTime DefaultLastUsed = new DateTime(2009, 01, 01); // DateTime.MinValue creates an overflow on insert.

        public Term()
        {
            this.ParentCode = null;
            this.LastUsed = DefaultLastUsed;
        }

        [Column(IsPrimaryKey = true)]
        public string Code { get; set; }

        [Column(IsPrimaryKey = true)]
        public int SourceID { get; set; }

        [Column]
        public string Description { get; set; }

        [Column]
        public string DisplayText { get; set; }

        [Column]
        public string ParentCode { get; set; }

        [Column]
        public DateTime LastUsed { get; set; }
    }
}
