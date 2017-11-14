﻿namespace SyncPro.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using SyncPro.Adapters;
    using SyncPro.Runtime;

    [Table("HistoryEntries")]
    public class SyncHistoryEntryData
    {
        [Key]
        public int Id { get; set; }

        public int SyncHistoryId { get; set; }

        //[ForeignKey("SyncHistoryId")]
        //public virtual SyncHistoryData HistoryData { get; set; }

        public long SyncEntryId { get; set; }

        [ForeignKey("SyncEntryId")]
        public virtual SyncEntry SyncEntry { get; set; }

        /// <summary>
        /// The size of the entry when it was synced.
        /// </summary>
        public long Size { get; set; }

        public byte[] Sha1Hash { get; set; }

        public EntryUpdateState Result { get; set; }

        [NotMapped]
        public SyncEntryChangedFlags Flags
        {
            get
            {
                unchecked
                {
                    return (SyncEntryChangedFlags)(uint)this.FlagsValue;
                }
            }
            set
            {
                unchecked
                {
                    this.FlagsValue = (int) value;
                }
            }
        }

        public bool HasSyncEntryFlag(SyncEntryChangedFlags flag)
        {
            return (this.Flags & flag) != 0;
        }

        public int FlagsValue { get; set; }

        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The original full path of the item (from the root of the adapter) when it was synced.
        /// </summary>
        public string OriginalPath { get; set; }
    }
}