﻿using System;
using System.ComponentModel.DataAnnotations;
using Bit.Core.Utilities;

namespace Bit.Core.Entities
{
    public class Collection : ITableObject<Guid>
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        [MaxLength(300)]
        public string ExternalId { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime RevisionDate { get; set; } = DateTime.UtcNow;

        public void SetNewId()
        {
            Id = CoreHelpers.GenerateComb();
        }
    }
}
